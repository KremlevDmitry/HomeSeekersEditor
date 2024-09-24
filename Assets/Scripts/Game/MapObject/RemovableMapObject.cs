using UnityEngine;

public class RemovableMapObject : MapObject
{
    public override void MakeAction()
    {
        Remove();
    }

    public void Remove()
    {
        Destroy(gameObject);
    }

    //private void OnMouseDown()
    //{
    //    MakeAction();
    //}

    private void OnMouseUpAsButton()
    {
        if (Input.touchCount > 1) { return; }

        MakeAction();
    }
}
