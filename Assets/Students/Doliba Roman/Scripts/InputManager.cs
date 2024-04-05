using UnityEngine;

public class InputManager : MonoBehaviour
{
    private float _direction;
    private bool _isJump; 
    private void Update()
    {
        _isJump = Input.GetKeyDown(KeyCode.W);
        _direction = Input.GetAxis("Horizontal");
    }
    public float MoveInput { get { return _direction; } }
    public bool JumpInput { get { return _isJump; } }

}
