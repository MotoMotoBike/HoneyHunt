using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveAtDirection : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] RotationController.Direction direction;
    [SerializeField] float lifeTime;
    float currentLifeTime = 0;

    void Update()
    {
        ChekLifeTime();
        MovePosition();
    }
    
    void MovePosition()
    {
        transform.position += (direction == RotationController.Direction.UP ? Vector3.up : Vector3.down) * (speed * Time.deltaTime);
    }

    void ChekLifeTime()
    {
        currentLifeTime += Time.deltaTime;
        if (currentLifeTime >= lifeTime)
        {
            Destroy(gameObject);
        }
    }
}
