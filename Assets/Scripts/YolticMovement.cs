﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YolticMovement : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    public int Health = 5;

    //Audios
    public AudioClip MoveSound;
    public AudioClip JumpSound;
    public AudioClip AttackSound;

    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float Horizontal;
    private bool Grounded;
    private bool isAttack;

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

        //Debug.DrawRay(transform.position, Vector3.down * 0.35f, Color.red);
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

        if (Input.GetKeyDown(KeyCode.J))
        {
            Animator.SetTrigger("Press_J");
            Attack();
            // isAttack = false;
            // Debug.Log(isAttack);
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isAttack)
        {
            GhostController ghost = collision.collider.GetComponent<GhostController>();
            LloronaController llorona = collision.collider.GetComponent<LloronaController>();
            if (ghost != null)
            {
                ghost.Hit();
                isAttack = false;
            }
            if (llorona != null)
            {
                llorona.Hit();
                isAttack = false;
            }
        }
        else isAttack = false;
    }


    //This is when Yoltic recive damage from enemies and die if not have more health
    public void Hit()
    {
        if (!isAttack)
        {
            Health = Health - 1;
        }
        Debug.Log("Yoltic: " + Health);
        if (Health == 0)
        {
            Destroy(gameObject);
            StartCoroutine(waitSeconds());
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
    }

    //Yoltic attack enemies
    public void Attack()
    {
        isAttack = true;
       // Debug.Log(isAttack);
    }

    IEnumerator waitSeconds()
    {
        yield return new WaitForSeconds(5);
    }
}
