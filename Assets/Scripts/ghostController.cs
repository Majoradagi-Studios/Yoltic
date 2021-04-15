using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    public float speed;
    GameObject Player;

    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private Vector3 directionToPlayer;
    private int Health;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        Player = GameObject.FindGameObjectWithTag("Player");
   }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 direction = Player.transform.position - transform.position;
        if (direction.x >= 0.0f)
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        else
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);

        float distance = Mathf.Abs(Player.transform.position.x - transform.position.x);
    
        if (distance < 2.0f)
        {
            //Debug.Log("In range");
            MoveEnemy();
        }
    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        YolticMovement yoltic = collision.collider.GetComponent<YolticMovement>();
        if (yoltic != null)
        {
            yoltic.hit();
        }
    }

    private void MoveEnemy()
    {
        directionToPlayer = (Player.transform.position - transform.position).normalized;
        Rigidbody2D.velocity = new Vector2(directionToPlayer.x * speed, Rigidbody2D.velocity.y);
    }

    public void hit()
    {
        Health = Health - 1;
        if (Health == 0) Destroy(gameObject);
    }
}
