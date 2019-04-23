using System;
using UnityEngine;
using System.Collections.Generic;
public class SwipeDetector : MonoBehaviour
{
    private Vector2 fingerDownPosition;
    private Vector2 fingerUpPosition;

    [SerializeField]
    private bool detectSwipeOnlyAfterRelease = false;

    [SerializeField]
    private float minDistanceForSwipe = 20f;

    public static event Action<SwipeData> OnSwipe = delegate { };
    public static event Action<ISwipeable> OnTouch = delegate { };
    public static event Action<DragData> OnTouchMove = delegate { };
    public static event Action OnTouchEnd = delegate { };

    Vector3 lastMousePosition;
    private ISwipeable swipedObject;


    private void Update()
    {
        List<Touch> touches = InputHelper.GetTouches();
        foreach (Touch touch in touches)
        {
            HandleTouch(touch);
        }

    }

    private GameObject GetCameraRayHittedGameObject()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit,40f))
        {
            return hit.transform.gameObject;

        }
        return null;
    }
    private void HandleTouch(Touch touch)
    {
        if (touch.phase == TouchPhase.Began)
        {
            fingerUpPosition = touch.position;
            fingerDownPosition = touch.position;

            GameObject obj = GetCameraRayHittedGameObject();
            if (obj != null)
            {
                swipedObject = obj.GetComponent<ISwipeable>();
                if (swipedObject != null)
                    OnTouch(swipedObject);
            }

        }
        if (touch.phase == TouchPhase.Moved)
        {
            fingerDownPosition = touch.position;

            if (!detectSwipeOnlyAfterRelease)
            {
                DetectSwipe();
            }
            OnTouchMove(new DragData { deltaMove = fingerDownPosition - fingerUpPosition, swipeable = swipedObject });
        }

        
        
        if (touch.phase == TouchPhase.Ended)
        {
            fingerDownPosition = touch.position;
            DetectSwipe();
        }

        if (touch.phase == TouchPhase.Canceled || touch.phase ==  TouchPhase.Ended)
        {
            OnTouchEnd();
        }

    }

    private void DetectSwipe()
    {
        if (SwipeDistanceCheckMet())
        {
            if (IsVerticalSwipe())
            {
                var direction = fingerDownPosition.y - fingerUpPosition.y > 0 ? SwipeDirection.Up : SwipeDirection.Down;
                SendSwipe(direction);
            }
            else
            {
                var direction = fingerDownPosition.x - fingerUpPosition.x > 0 ? SwipeDirection.Right : SwipeDirection.Left;
                SendSwipe(direction);
            }
            fingerUpPosition = fingerDownPosition;
        }
    }

    private bool IsVerticalSwipe()
    {
        return VerticalMovementDistance() > HorizontalMovementDistance();
    }

    private bool SwipeDistanceCheckMet()
    {
        return VerticalMovementDistance() > minDistanceForSwipe || HorizontalMovementDistance() > minDistanceForSwipe;
    }

    private float VerticalMovementDistance()
    {
        return Mathf.Abs(fingerDownPosition.y - fingerUpPosition.y);
    }

    private float HorizontalMovementDistance()
    {
        return Mathf.Abs(fingerDownPosition.x - fingerUpPosition.x);
    }

    private void SendSwipe(SwipeDirection direction)
    {
        SwipeData swipeData = new SwipeData()
        {
            swipeable = swipedObject,
            Direction = direction,
            StartPosition = fingerDownPosition,
            EndPosition = fingerUpPosition
        };
        OnSwipe(swipeData);
        swipedObject = null;

    }
}

public struct SwipeData
{
    public ISwipeable swipeable;
    public Vector2 StartPosition;
    public Vector2 EndPosition;
    public SwipeDirection Direction;
}
public struct DragData
{
    public ISwipeable swipeable;
    public Vector2 deltaMove;
    
}
public enum SwipeDirection
{
    Up,
    Down,
    Left,
    Right
}