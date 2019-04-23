using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISwipeable
{
    void OnTouch(ISwipeable swipeable);
    void OnSwipe(SwipeData swipeData);
    void OnTouchMove(DragData dragData);
}
