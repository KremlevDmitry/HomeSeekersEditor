using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CameraMover : MonoBehaviour, IPointerDownHandler, IDragHandler, IDropHandler
{
    public MovableCamera _camera = default;
    private Vector3 _downPosition = default;
    private float _touchesDistance = default;


    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("Down");
        int touchCount = Input.touchCount;
#if UNITY_EDITOR
        if (true)
#else
        if (touchCount == 1)
#endif
        {
            _downPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        else if (touchCount == 2)
        {
            _touchesDistance = Vector2.Distance(
                Input.touches[0].position,
                Input.touches[1].position);

            _downPosition = Camera.main.ScreenToWorldPoint(Vector2.Lerp(Input.touches[0].position, Input.touches[1].position, .5f));
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("Drag");
        int touchCount = Input.touchCount;
#if UNITY_EDITOR
        if (true)
#else
        if (touchCount == 1)
#endif
        {
            _camera.Move(_downPosition - Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
        else if (touchCount == 2)
        {
            float touchesDistance = Vector2.Distance(
                Input.touches[0].position,
                Input.touches[1].position);

            _camera.SetSize((touchesDistance - _touchesDistance) * .01f);
            _camera.Move(_downPosition - Camera.main.ScreenToWorldPoint(Vector2.Lerp(Input.touches[0].position, Input.touches[1].position, .5f)));

            _touchesDistance = touchesDistance;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        //Debug.Log("Drop");
    }
}
