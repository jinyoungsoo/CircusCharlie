using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private int jumpCount = 0;

    public float jumpForce = 350f;

    public float speed = 5f;

    private Rigidbody2D playerRigidbody;
    private Animator animator;

    private bool isGrounded = false;
    private bool isDead = false;



    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float xSpeed = xInput * speed;

        Vector2 newVelocity = new Vector2(xSpeed, playerRigidbody.velocity.y);

        playerRigidbody.velocity = newVelocity;



        if (Input.GetMouseButtonDown(0) && jumpCount <= 1)
        {
            jumpCount = 0;

            playerRigidbody.velocity = Vector2.zero;

            playerRigidbody.AddForce(new Vector2(0, jumpForce));
        }

        else if (Input.GetMouseButtonDown(0) && playerRigidbody.velocity.y > 0)
        {
            playerRigidbody.velocity = playerRigidbody.velocity * 0.5f;
        }
        animator.SetBool("Grounded", isGrounded);

    }

    private void Die()
    {
        animator.SetTrigger("Die");

        playerRigidbody.velocity = Vector2.zero;

        isDead = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Dead"))
        {
            Die();

        }

        if (collision.tag.Equals("Ring"))
        {
            GameManager.instance.AddScore(5);


        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //� �ݶ��̴��� �������, �浹 ǥ���� ������ ���� ������
        if (collision.contacts[0].normal.y > 0.7f)
        {
            //isGrounded�� true�� �����ϰ�, ���� ���� Ƚ���� 0���� ����
            isGrounded = true;
            jumpCount = 0;
        }
        
        if(collision.collider.tag.Equals("Ring"))
        {
            Die();
        }
       
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }


}
