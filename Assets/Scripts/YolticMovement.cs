using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YolticMovement : MonoBehaviour
{
    public float Speed;
    public float JumpForce;

    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float Horizontal;
    private bool Grounded;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

        //Set false if the player isn't moving and isn't in the ground
        Animator.SetBool("Moving", Horizontal != 0.0f && Grounded == true);

        if (Horizontal < 0.0f)
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (Horizontal > 0.0f)
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        Debug.DrawRay(transform.position, Vector3.down * 0.35f, Color.red);
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.35f))
        {
            Grounded = true;
            Animator.SetBool("Grounded", true);
        }
        else
        {
            Grounded = false;
            Animator.SetBool("Grounded", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && Grounded)
        {
            Animator.SetBool("Grounded", false);
            Jump();
        }

        if (Input.GetKey(KeyCode.J))
        {
            Animator.SetTrigger("Press_J");
        }
    }

    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal * Speed, Rigidbody2D.velocity.y);
    }
}
