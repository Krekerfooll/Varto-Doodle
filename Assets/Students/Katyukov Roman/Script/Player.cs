using UnityEngine;

public class Player : Person
{
    public Vector2 jumpForce = new Vector2(0, 300);
    private bool isGrounded; //
    public float groundCheckDistance = 0.5f;
    public LayerMask groundMask; //
    public Transform groundCheck; // Объект, Raycast

    void Update()
    {
        isGrounded = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, groundMask);

        // Выводим луч для дебага
        Debug.DrawRay(groundCheck.position, Vector2.down * groundCheckDistance, Color.red);

        // Проверяем условие для прыжка: нажатие кнопки "Jump" и наличие земли под объектом "groundCheck"
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);
        transform.position += movement * Speed * Time.deltaTime; // Изменяем позицию игрока
    }

    private void Jump()
    {
        // Применяем силу прыжка
        GetComponent<Rigidbody2D>().AddForce(jumpForce);
    }
}