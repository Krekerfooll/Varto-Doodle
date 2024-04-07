using UnityEngine;

public class CameraScript : MonoBehaviour
{

    [SerializeField] private Transform _player;
    [SerializeField] private float _speed;


    void Update()
    {
        var targetPosition = new Vector3(transform.position.x, _player.position.y, transform.position.z);

        transform.position = targetPosition;
        transform.position = Vector3.Lerp(transform.position, targetPosition, _speed * Time.deltaTime);
    }
}
