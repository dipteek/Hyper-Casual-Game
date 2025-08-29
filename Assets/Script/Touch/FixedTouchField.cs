using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FixedTouchField : MonoBehaviour , IPointerDownHandler, IPointerUpHandler
{
    [HideInInspector]
    public Vector2 TouchDist;
    public float TouchDistx;
    [HideInInspector]
    public Vector2 PointerOld;
    [HideInInspector]
    protected int PointerId;
    [HideInInspector]


    public float PointerOldx;
    [HideInInspector]
    public bool Presseds;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
            if (Presseds)
            {
        #if UNITY_EDITOR
                TouchDist = (Vector2)Input.mousePosition - PointerOld;
                PointerOld = Input.mousePosition;
                TouchDistx = PointerOld.x;
        #else
                if (PointerId >= 0 && PointerId < Input.touchCount)
                {
                    Touch touch = Input.GetTouch(PointerId);
                    TouchDist = touch.position - PointerOld;
                    PointerOld = touch.position;
                    TouchDistx = touch.position.x;
                }
        #endif
            }
            else
            {
                TouchDist = Vector2.zero;
            }
        

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Presseds = true;
        PointerId = eventData.pointerId;
        PointerOld = eventData.position;
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        Presseds = false;
    }
}
