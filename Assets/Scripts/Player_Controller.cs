using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller:MonoBehaviour
    {
    [SerializeField, Range(1, 100)] int distance = 5;
    [SerializeField, Range (1, 1000)] float jumpPower = 5f;
    [SerializeField] internal Rigidbody2D playerRb;    
    internal bool isOnGround = true;

    void Update()
    {
        Player_Movement();
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround)
            {
            Player_Jump();
            }
    }

    void Player_Movement()
    {        
      float horizontal = Input.GetAxis("Horizontal");
      transform.Translate(Vector2.right * horizontal * distance * Time.deltaTime);
      float vertical = Input.GetAxis("Vertical");
      transform.Translate(Vector3.forward * vertical * distance * Time.deltaTime);
    }

    void Player_Jump()
        {
        playerRb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);        
        isOnGround = false;
        }
      
        
    void OnCollisionEnter2D(Collision2D collision) 
        {
        isOnGround = true;
        Debug.Log(collision.gameObject.name);
        }
    }
