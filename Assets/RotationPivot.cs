using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationPivot : MonoBehaviour
{
    [SerializeField] private bool isBorder;
    [SerializeField] float speed = 1f; // Скорость движения объекта
    [SerializeField] float radius = 1f; // Радиус окружности
    [SerializeField] Vector3 center; // Центр окружности
    [Space]
    [SerializeField] private GameObject agent;
    private bool isActive;
    private float currentAngle = 0f;
    private bool isMovingDown = true;
    public Action onRotateFinished;
    
    void Update()
    {
        if(!isActive)return;
        // Рассчитываем новую позицию объекта по окружности
        float x = center.x + Mathf.Cos(currentAngle) * radius;
        float y = center.y + Mathf.Sin(currentAngle) * radius;

        if (isMovingDown && currentAngle>=180)
        {
            currentAngle = 180;
            agent.transform.position = new Vector3(x, y, 0);
        }
        
        agent.transform.position = new Vector3(x, y, 0);
    }

    public void Enable()
    {
        isActive = true;
    }
    public void ChekDisable()
    {
        isActive = false;
    }
}

