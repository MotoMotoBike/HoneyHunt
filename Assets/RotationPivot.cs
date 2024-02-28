using System;
using UnityEngine;

public class RotationPivot : MonoBehaviour
{
    [SerializeField] float speed = 1f; 
    [SerializeField] float radius = 1f; 
    [SerializeField] private float reqareAngle;
    [Space]
    [SerializeField] private GameObject agent;
    public bool isActive = true;
    public float currentAngle = 0f;
    public float passedAngle = 0f;
    public Action onRotateFinished;
    
    void Update()
    {
        if(!isActive)return;
        var step = speed * Time.deltaTime * RotationController.speedMultiplyer;
        
        currentAngle += step;
        passedAngle += Mathf.Abs(step);

        var radians = step * Mathf.Deg2Rad;
        var X = transform.position.x + Mathf.Cos(radians) * (agent.transform.position.x - transform.position.x) - Mathf.Sin(radians) * (agent.transform.position.y - transform.position.y);
        var Y = transform.position.y + Mathf.Sin(radians) * (agent.transform.position.x - transform.position.x) + Mathf.Cos(radians) * (agent.transform.position.y - transform.position.y);
        if (Mathf.Abs(passedAngle) >= reqareAngle)
        {
            RoundAngle(step);
            passedAngle = 0;
            isActive = false;
            onRotateFinished?.Invoke();
        }
        
        agent.transform.position = new Vector3(X, Y, 0);
    }

    private void RoundAngle(float step)
    {
        currentAngle = Mathf.Abs(currentAngle - 179) >= step ? 180 : 0;
    }
    
    public void Enable()
    {
        isActive = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position,radius);
    }
}

