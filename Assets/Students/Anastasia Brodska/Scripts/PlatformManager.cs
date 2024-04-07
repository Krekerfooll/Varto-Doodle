using Doodle.Core;
using UnityEngine;


public class PlatformManager : MonoBehaviour
{
    [SerializeField] private GameObject newPlatformPrefab;
    private PlayerMovement playerMovement; 
    private void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Platform") && playerMovement != null && playerMovement.IsGrounded)
        {
            Instantiate(newPlatformPrefab, collision.transform.position, collision.transform.rotation);
            Destroy(collision.gameObject);
        }
    }
}
