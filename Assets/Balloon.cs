using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Balloon : MonoBehaviour
{
    public bool hasGems;
    
    [Space]
    [SerializeField] private Image targetImage;
    [Space]
    [SerializeField] private Sprite gems;
    [SerializeField] private Sprite skull;
    
    
    private bool _opened = false;
    private GameSession _session;
    
    private void Start()
    {
        _session = FindObjectOfType<GameSession>();
    }

    public void OnClick()
    {
        if(_opened) return;

        if (hasGems)
        {
            targetImage.sprite = gems;
            _session.AddGems();
        }
        else
        {
            targetImage.sprite = skull;
            _session.AddScull();
        }

        _opened = true;
    }
}
