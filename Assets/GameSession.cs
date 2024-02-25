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
    [SerializeField] private int levelID;
    [Space]
    [SerializeField] private GameObject[] healthIndicators;
    [SerializeField] private Text[] gemsValueText;
    [SerializeField] private Text scoreValueText;
    [SerializeField] private int health;
    [SerializeField] private GameObject completeLevelScreen;
    [SerializeField] private GameObject failLevelScreen;
    private int gemsCount;

    void Start()
    {
        gemsCount = FindObjectsOfType<Balloon>().Count(e => e.hasGems);
    }

    public void AddGems()
    {
        gemsCount--;
        foreach (var text in gemsValueText)
        {
            text.text = (Convert.ToInt32(text.text) + 10).ToString();
        }
        scoreValueText.text = (Convert.ToInt32(scoreValueText.text) + UnityEngine.Random.Range(10,100)).ToString();
        if (gemsCount == 0)
        {
            SaveData.SetScoreByLevelID(levelID,Convert.ToInt32(scoreValueText.text));
            completeLevelScreen.SetActive(true);
            Destroy(gameObject);
        }
    }
    public void AddScull()
    {
        health--;
        if (health == 0)
        {
            
            DisplayHealth();
            Destroy(gameObject);
            failLevelScreen.SetActive(true);
        }
        DisplayHealth();
    }

    void DisplayHealth()
    {
        foreach (var indicator in healthIndicators)
        {
            indicator.SetActive(false);
        }
        for (int i = 0; i < health; i++)
        {
            healthIndicators[i].SetActive(true);
        }
    }
}
