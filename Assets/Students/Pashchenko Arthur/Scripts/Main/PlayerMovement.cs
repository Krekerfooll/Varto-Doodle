using Artur.Pashchenko.Conditions;
using UnityEngine;
namespace Artur.Pashchenko.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _jumpPower;
        [SerializeField] Rigidbody2D _playerRigidbody;
        [SerializeField] float _movementSpeed;
        [SerializeField] float _rotationSpeed;
        Quaternion _targetRotation;
        [SerializeField] private IsGroudedCondition _isGroudedCondition;

        private void Update()
        {
            Jump();
            Move();
        } 
        private void Jump()
{
            if (InputController.IsJumped && _isGroudedCondition.CheckCondition())
            {
               _playerRigidbody.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
            }
        }
        private void Move()
        {
            if (!_isGroudedCondition.CheckCondition())
            {
                _playerRigidbody.velocity = new Vector2(InputController.Direction * _movementSpeed, _playerRigidbody.velocity.y);

                if (InputController.Direction < 0) 
                {
                    _targetRotation = Quaternion.Euler(this.transform.rotation.x, -180, this.transform.rotation.z);
                    transform.rotation = Quaternion.Lerp(transform.rotation, _targetRotation, _rotationSpeed * Time.deltaTime);
                }
                else if (InputController.Direction > 0)
                {
                    _targetRotation = Quaternion.Euler(this.transform.rotation.x, 0, this.transform.rotation.z);
                    transform.rotation = Quaternion.Lerp(transform.rotation, _targetRotation, _rotationSpeed * Time.deltaTime);
                }
              

               

            }  
        } 
    private void FixedUpdate()
        {
            if (_isGroudedCondition.CheckCondition())
            {
                if (transform.rotation.eulerAngles.y < 90f) transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                else if (transform.rotation.eulerAngles.y >= 90f) transform.rotation = Quaternion.Euler(0f, -180f, 0f);
            }
        }

    }
}