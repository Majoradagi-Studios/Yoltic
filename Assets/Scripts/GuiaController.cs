using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuiaController : MonoBehaviour
{
    public GameObject tutorial;
    GameObject Player;
    private Vector3 directionToPlayer;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        // tutorial = GameObject.FindGameObjectWithTag("Tutorial");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Player == null) return;
        Vector3 direction = Player.transform.position - transform.position;
        if (direction.x >= 0.0f)
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        else
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);

        float distance = Mathf.Abs(Player.transform.position.x - transform.position.x);

        if (distance < 0.5f)
        {
            tutorial.SetActive(true);
            //Debug.Log("In range");
        }
        else tutorial.SetActive(false);
        
    }
}
