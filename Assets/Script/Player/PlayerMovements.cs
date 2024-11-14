using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovements : MonoBehaviour
{

    public float moveSpeed = 5f; 
    private Rigidbody2D rb;

    public Slider sliderHP;

    public float PlayerHealth;

    public float Regeneration;

    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();

        GetComponent<Animator>().SetFloat("Speed", rb.velocity.magnitude);
        sliderHP.value = PlayerHealth;
        if(PlayerHealth < 100)
        {
            PlayerHealth += Regeneration;
        }
    }

    void Move()
    {
        
        float moveX = JoystickLeft.positionX;
        float moveY = JoystickLeft.positionY;

        
        Vector2 moveDirection = new Vector2(moveX, moveY).normalized;

        
        rb.velocity = moveDirection * moveSpeed;
    }

    public void TakeDamage(float damage)
    {
        PlayerHealth -= damage;

        if(PlayerHealth <= 0)
        {
            GameOverUI.GameOver?.Invoke();
        }
    }
}
