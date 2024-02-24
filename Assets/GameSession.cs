using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = System.Random;

public class GameSession : MonoBehaviour
{
    [SerializeField] private GameObject[] healthIndicators;
    [SerializeField] private Text gemsValueText;
    [SerializeField] private Text scoreValueText;
    [SerializeField] private int health;
    private int gemsCount;

    void Start()
    {
        gemsCount = FindObjectsOfType<Balloon>().Count(e => e.hasGems);
    }

    public void AddGems()
    {
        gemsCount--;
        gemsValueText.text = (Convert.ToInt32(gemsValueText.text) + 10).ToString();
        scoreValueText.text = (Convert.ToInt32(scoreValueText.text) + UnityEngine.Random.Range(10,100)).ToString();
    }
    public void AddScull()
    {
        health--;
        if (health == 0) FindObjectOfType<AppNavigationTool>().ReLoadLevel();
        DisplayHealth();
    }

    void DisplayHealth()
    {
        foreach (var indicator in healthIndicators)
        {
            indicator.SetActive(true);
        }
        for (int i = 0; i < health; i++)
        {
            healthIndicators[i].SetActive(true);
        }
    }
}
