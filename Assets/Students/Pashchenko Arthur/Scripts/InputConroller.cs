using UnityEngine;
namespace Doodle.core
{
    public class InputController : MonoBehaviour
    {
        [SerializeField] Rigidbody2D _player;
        private static bool _isJumped = false;
        private static float _direction;

        public void Update()
        {
           _isJumped = Input.GetKeyDown(KeyCode.W);
            _direction = Input.GetAxis("Horizontal");
        }
        public static bool IsJumped { get { return _isJumped;} }
        public static float Direction { get { return _direction; } }
    }
}