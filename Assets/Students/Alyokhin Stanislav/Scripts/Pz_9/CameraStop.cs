using Unity.VisualScripting;
using UnityEngine;

public class CameraStop : MonoBehaviour
{
    [SerializeField] Transform _targetFollow;
    [SerializeField] private float _speed;
    private Vector3 offset;
    private float initialX;

    [SerializeField] float minX;
    [SerializeField] float maxX;

    private void Start()
    {
        offset = transform.position - _targetFollow.position;

        initialX = transform.position.x;
    }


    void LateUpdate()
    {
        Vector3 newPosition = _targetFollow.position + offset;

        newPosition.x = Mathf.Clamp(newPosition.x, initialX + minX, initialX + maxX);
        transform.position = Vector3.Lerp(transform.position,newPosition,_speed * Time.deltaTime);

        // if(_targetFollow.position.y > _targetFollow.position.y)
        // {
        //     Vector3 newPosition = new Vector3(transform.position.x,transform.position.y,transform.position.z);
        //     transform.position = newPosition;
        // }
        // transform.position = new Vector3 (Mathf.Clamp(_targetFollow.position.x, -10f, 10f),transform.position.y,transform.position.z);

    }
}
