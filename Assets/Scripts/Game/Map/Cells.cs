using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class Cells<C, CValue> : MonoBehaviour
{
    protected Map _map = default;
    protected List<C> _cells = new();


    public void Init(Map map)
    {
        _map = map;
    }

    public virtual void Generate(List<CValue> cellsValues)
    {
        var count = cellsValues.Count;
        for (int i = 0; i < count; i++)
        {
            CreateCell(cellsValues[i], i, count);
        }
    }

    protected abstract void CreateCell(CValue value);
    protected abstract void CreateCell(CValue value, int index, int count);
}
