using Unity.VisualScripting;
using UnityEngine;

public class CameraStop : MonoBehaviour
{
    [SerializeField] Transform _targetFollow;
    //[SerializeField] private float _speed;


    void LateUpdate()
    {
        if(_targetFollow.position.y > _targetFollow.position.y)
        {
            Vector3 newPosition = new Vector3(transform.position.x,transform.position.y,transform.position.z);
            transform.position = newPosition;
        }
        //transform.position = new Vector3 (Mathf.Clamp(_targetFollow.position.x, -10f, 10f),transform.position.y,transform.position.z);

    }
}
