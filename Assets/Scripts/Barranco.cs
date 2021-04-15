using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Barranco : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        YolticMovement yoltic = collision.collider.GetComponent<YolticMovement>();
        Destroy(yoltic);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
