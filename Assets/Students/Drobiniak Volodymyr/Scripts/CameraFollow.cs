using UnityEngine;

namespace Students.Drobiniak_Volodymyr.Scripts
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform playerTarget;
        [SerializeField,Range(0,3)] private float cameraSpeed = 0.5f;
        
        void FixedUpdate()
        {
            if (playerTarget != null)
            {
                // Створюємо новий вектор для позиції камери, враховуючи позицію гравця
                Vector3 desiredPosition = new Vector3(playerTarget.position.x, playerTarget.position.y, transform.position.z);

                // Використовуємо Lerp для плавного руху камери
                Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, cameraSpeed * Time.fixedDeltaTime);

                // Встановлюємо плавну позицію камери
                transform.position = smoothedPosition;
            }
        }
    }
}
