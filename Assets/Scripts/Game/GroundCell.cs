using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCell : MonoBehaviour
{
    public Vector3 Position = default;
    private MapObject _mapObject = default;


    public static GroundCell Create(GroundCell prefab, Transform parent, Vector3 position)
    {
        var cell = Instantiate(prefab, position, Quaternion.identity, parent);
        return cell;
    }


    public void OnMouseDown()
    {
        _mapObject?.MakeAction();
    }
}
