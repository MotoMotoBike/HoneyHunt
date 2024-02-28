using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class RotationController : MonoBehaviour, IPointerDownHandler,IPointerUpHandler
{
    [SerializeField] private RotationPivot[] pivots;
    public static float speedMultiplyer = 1;
    private int currentPivotID = 0;
    private Direction direction;
    private void Start()
    {
        speedMultiplyer = 1;
        foreach (var pivot in pivots)
        {
            pivot.onRotateFinished += SetNextActivePivot;
        }
    }

    private void SetNextActivePivot()
    {
        if (isBorder)
            ChangeDirection();
        
        if (direction == Direction.DOWN)
        {
            currentPivotID++;
        }
        else
        {
            currentPivotID--;
        }

        pivots[currentPivotID].Enable();
    }

    private void ChangeDirection()
    {
        if (direction == Direction.UP)
        {
            direction = Direction.DOWN;
        }
        else
        {
            direction = Direction.UP;
        }
    }
    private bool isBorder => currentPivotID == 0 || currentPivotID == pivots.Length-1;

    public enum Direction
    {
        UP,DOWN
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        speedMultiplyer = 5;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        speedMultiplyer = 1;
    }
}
