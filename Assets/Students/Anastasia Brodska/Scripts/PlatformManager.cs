using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [SerializeField] private GameObject newPlatformPrefab;
    [SerializeField] private PlayerMovement playerMovement;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform") && playerMovement != null && playerMovement.IsGrounded)
        {
            GameObject newPlatform = Instantiate(newPlatformPrefab, collision.transform.position, collision.transform.rotation);
            Destroy(collision.gameObject);
            newPlatform.AddComponent<PlatformVisibilityHandler>();
        }
    }
}

public class PlatformVisibilityHandler : MonoBehaviour
{
    private void Update()
    {
        if (!IsVisible())
        {
            Destroy(gameObject);
        }
    }

    private bool IsVisible()
    {
        Camera mainCamera = Camera.main;
        if (mainCamera == null)
            return false;

        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(mainCamera);
        return GeometryUtility.TestPlanesAABB(planes, GetComponent<Renderer>().bounds);
    }
}
