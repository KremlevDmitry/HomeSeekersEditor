using UnityEngine;

public abstract class MapObject : MonoBehaviour
{
    public Vector3 Position = default;

    public abstract void MakeAction();
}
