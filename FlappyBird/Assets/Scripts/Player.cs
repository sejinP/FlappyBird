using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float jumpForce;
    public Animator an;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        an = GetComponent<Animator>();
        rb.AddForce(Vector2.up * jumpForce);
    }
    void Update()
    {
        if(!GameManager.GetInstance().isOver)
        {
            if(Input.GetMouseButtonDown(0)) rb.AddForce(Vector2.up * jumpForce);
            if(rb.velocity.y > 7) rb.velocity = new Vector2(0, 7);
            if(transform.position.y > 7) transform.position = new Vector2(-0.5f, 7);
        }
        if(rb.velocity.y > -4) transform.rotation = Quaternion.Euler(0, 0, 20);
        else transform.rotation = Quaternion.Euler(0, 0, rb.velocity.y * 5);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Pipe") GameManager.GetInstance().score += 1;
        else{
            GameManager.GetInstance().isOver = true;
            an.speed = 0f;
            GameManager.GetInstance().textScore.enabled = false;
            GameManager.GetInstance().gameOverMenu.SetActive(true);
            if(GameManager.GetInstance().score > GameManager.GetInstance().bestScore){
                GameManager.GetInstance().bestScore = GameManager.GetInstance().score;
            }
        }
    }
}
