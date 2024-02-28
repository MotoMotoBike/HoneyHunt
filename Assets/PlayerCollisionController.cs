using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class PlayerCollisionController : MonoBehaviour
{
    [SerializeField] UnityEvent onPlayerDead;
    [SerializeField] UnityEvent<string> onPlayerGetHoney;
    private int score = 0;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Respawn"))
        {
            onPlayerDead?.Invoke();
            gameObject.SetActive(false);
        }

        if (other.transform.CompareTag("honey"))
        {
            score += 1;
            onPlayerGetHoney?.Invoke(score.ToString());
            Destroy(other.gameObject);
        }
    }
}
