using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    public float playerSpeed = 1;
    public float playerJump = 1;
    private float HDIR;
    private float VDIR;
    private Rigidbody2D rb;
    private bool jump = false;
    private bool ground = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        HDIR = Input.GetAxisRaw("Horizontal");
        VDIR = Input.GetAxisRaw("Vertical");
        //transform.position += new Vector3(HDIR, VDIR, 0) * Time.deltaTime * playerSpeed;
        if (Input.GetButtonDown("Jump") && ground)
        {
            jump = true;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(HDIR * playerSpeed, rb.velocity.y);

        if(jump)
        {
            rb.AddForce(Vector2.up * playerJump, ForceMode2D.Impulse);
            jump = false;
            ground = false;
        }




    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Box")
        {
            ground = true;
        }
     
    }
}

