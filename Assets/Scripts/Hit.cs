using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    [SerializeField] int earnedScore = 10;
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
        Score.AddScore(earnedScore);
        if (gameObject.name.Contains("Head"))
        {
            Destroy(gameObject.transform.parent.gameObject);
        }
        Destroy(gameObject);
    }
}
