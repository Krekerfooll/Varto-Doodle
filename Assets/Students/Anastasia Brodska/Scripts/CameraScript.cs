using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraScript : MonoBehaviour
{

    [SerializeField] private Transform _player;
    [SerializeField] private float _speed;


    void Update()
    {
        if (_player != null)
        {
            var targetPosition = new Vector3(transform.position.x, _player.position.y, transform.position.z);

            transform.position = targetPosition;
            transform.position = Vector3.Lerp(transform.position, targetPosition, _speed * Time.deltaTime);
        }
    }
}
