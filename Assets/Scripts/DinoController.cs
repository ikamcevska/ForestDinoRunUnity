using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoController : MonoBehaviour

{
    Rigidbody2D rb;
    public float jumpForce;
    bool gameOver=false;
    bool grounded;

    Animator dinoAnimator;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        dinoAnimator = GetComponent<Animator>();
    }
    

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !gameOver)
        {
            if (grounded)
            {
                Jump();
            }
            
        }
        
    }
    void Jump()

    {
        grounded = false;
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        dinoAnimator.SetTrigger("Jump");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            Destroy(collision.gameObject);
            dinoAnimator.Play("dino death");
            GameManager.instance.GameOver();
            gameOver = true;
        }
    }
}
