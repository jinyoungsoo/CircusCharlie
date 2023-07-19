using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody2D playerRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (playerRigidbody != null)       //isDead == false
        {
            float xInput = Input.GetAxis("Horizontal");
            float xSpeed = xInput * speed * -1;

            Vector2 newVelocity = new Vector2(xSpeed, playerRigidbody.velocity.y);
            playerRigidbody.velocity = newVelocity;
        }


    }
}
