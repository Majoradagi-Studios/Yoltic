using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class YolticMovement : MonoBehaviour
{
    public float Speed;
    public float JumpForce;

    //health 
    public int Health = 5;
    public Slider slider;

    //Audios
    public AudioClip MoveSound;
    public AudioClip JumpSound;
    public AudioClip AttackSound;
    public AudioClip DamageSound;
    public AudioClip RageSound;

    private AudioSource _audioSource;
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
        _audioSource = GetComponent<AudioSource>();
        slider.maxValue = Health;
        slider.value = Health;

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
            _audioSource.PlayOneShot(JumpSound, 1);
            Jump();
            Animator.SetBool("Grounded", false);

        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            Animator.SetTrigger("Press_J");
            Attack();
            // isAttack = false;
            // Debug.Log(isAttack);
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
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
            _audioSource.PlayOneShot(DamageSound, 1);
            Health = Health - 1;
            slider.value = Health;
        }
        // Debug.Log("Yoltic: " + Health);
        if (Health == 0)
        {
            _audioSource.PlayOneShot(RageSound, 1);
            gameObject.SetActive(false);
            Invoke("RestartGame", 2.0f);
        }
        
    }

    //Yoltic attack enemies
    public void Attack()
    {
        _audioSource.PlayOneShot(AttackSound, 1);
        isAttack = true;
       // Debug.Log(isAttack);
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
