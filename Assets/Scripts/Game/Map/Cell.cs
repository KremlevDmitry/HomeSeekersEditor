using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public abstract class Cell<Cs, CValue> : MonoBehaviour
    where CValue : CellValue
{
    protected Map _map = default;
    protected Cs _cells = default;
    protected CValue _value = default;


    public virtual void Init(Map map, Cs cells, CValue value, string spriteName, float zPos = 0)
    {
        _map = map;
        _cells = cells;
        _value = value;

        gameObject.name = value.Id;
        if (UnityEngine.Resources.Load($"{spriteName}") == null)
        {
            Debug.Log($"{spriteName}");
        }
        GetComponent<SpriteRenderer>().sprite = UnityEngine.Resources.Load<Sprite>($"{spriteName}");

        SetPosition(new Vector3(_value.XPosition, _value.YPosition, zPos));
    }

    public void SetPosition(Vector3 position)
    {
        transform.position = position;
        var localPosition = transform.localPosition;
        localPosition.z = position.z;
        transform.localPosition = localPosition;
    }
}
