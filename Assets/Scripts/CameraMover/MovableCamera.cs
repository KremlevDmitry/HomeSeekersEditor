using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableCamera : MonoBehaviour
{
    private Camera __camera = null;
    private Camera _camera => __camera ??= GetComponent<Camera>();


    public void Move(Vector3 position)
    {
        transform.position += position;
    }

    public void Move(Vector2 position)
    {
        Vector3 pos = new Vector3(position.x, position.y, 0);
        Move(pos);
    }

    public void SetSize(float delta)
    {
        _camera.orthographicSize -= delta; 
    }
}
