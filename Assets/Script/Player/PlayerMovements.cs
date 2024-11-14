using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{

    public float moveSpeed = 5f; 
    private Rigidbody2D rb; 

    public int PlayerHealth;

    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();

        GetComponent<Animator>().SetFloat("Speed", rb.velocity.magnitude);
    }

    void Move()
    {
        
        float moveX = JoystickLeft.positionX;
        float moveY = JoystickLeft.positionY;

        
        Vector2 moveDirection = new Vector2(moveX, moveY).normalized;

        
        rb.velocity = moveDirection * moveSpeed;
    }

    public void TakeDamage(int damage)
    {
        PlayerHealth -= damage;

        if(PlayerHealth <= 0)
        {
            GameOverUI.GameOver?.Invoke();
        }
    }
}
