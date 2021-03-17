using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ScoreManage.scoreManage.RaiseScore(1);
        gameObject.SetActive(false);

    }
}
