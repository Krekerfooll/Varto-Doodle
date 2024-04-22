using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Animator anim;
    [SerializeField] Rigidbody2D _rigidbody;
    [SerializeField] private float _jumpPower;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _castLength;
    [SerializeField] private float _surroundingCheckRadius;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private PlatformBase _onPlayerDie;
    private bool _isGrounded;
    public bool IsGrounded => _isGrounded;

    public static Action<string> OnPlayerDeath;

    [SerializeField] private string _deathEventName;

    private Vector3 _localScale;

    void Awake()
    {
        anim = GetComponent<Animator>();
        _localScale = transform.localScale;
    }

    private void FixedUpdate()
    {
        _isGrounded = Physics2D.Raycast(transform.position, Vector2.down, _castLength, _groundMask);
        Debug.DrawLine(_rigidbody.transform.position, _rigidbody.transform.position + Vector3.down * _castLength, Color.green);

        Run();
        if (_isGrounded)
        {
            Jump();
        }

        if (!_isGrounded && !CheckSurroundingColliders())
        {
            Die();
        }
    }

    bool CheckSurroundingColliders()
    {
        Collider2D[] results = new Collider2D[5]; // Массив для результатов
        int count = Physics2D.OverlapCircleNonAlloc(transform.position, _surroundingCheckRadius, results, _groundMask);
        for (int i = 0; i < count; i++)
        {
            if (results[i].gameObject != gameObject && results[i].gameObject.layer != LayerMask.NameToLayer("IgnoreRaycast"))
            {
                return true;
            }
        }
        return false;
    }

    void Run()
    {
        var direction = Input.GetAxis("Horizontal");

        _rigidbody.velocity = new Vector2(direction * _moveSpeed, _rigidbody.velocity.y);

        if (direction != 0)
        {
            _localScale.x = Mathf.Abs(_localScale.x) * Mathf.Sign(direction);
            transform.localScale = _localScale;
            anim.SetBool("isRun", true);
        }
        else
        {
            anim.SetBool("isRun", false);
        }
    }

    void Jump()
    {
        if ((Input.GetButtonDown("Jump") || Input.GetAxisRaw("Vertical") > 0) && !anim.GetBool("isJump"))
        {
            anim.SetBool("isJump", true);
            _rigidbody.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
        }
        else if (anim.GetBool("isJump"))
        {
            anim.SetBool("isJump", false);
        }
    }

    void Die()
    {
        Destroy(gameObject);
        FirePlayerDeathEvent(_deathEventName);
    }

    public static void FirePlayerDeathEvent(string eventName)
    {
        OnPlayerDeath?.Invoke(eventName);
    }
}
