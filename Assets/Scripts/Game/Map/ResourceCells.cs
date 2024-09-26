using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ResourceCells : Cells<ResourceCell, ResourceCellValue>
{
    [SerializeField]
    private ResourceCell[] _cellPrefabs = default;
    [SerializeField]
    private string[] _cellNames = default;


    public override void Generate(List<ResourceCellValue> cellsValues)
    {
        //cellsValues = cellsValues.OrderBy(value => value.YPosition).OrderBy(value => value.XPosition).ToList();

        base.Generate(cellsValues);
    }

    protected override void CreateCell(ResourceCellValue value)
    {
        ResourceCell cell = Instantiate(GetCellByName(value.SpriteName), transform);
        cell.Init(_map, this, value, value.SpriteName);
        _cells.Add(cell);
    }

    protected override void CreateCell(ResourceCellValue value, int index, int count)
    {
        ResourceCell cell = Instantiate(GetCellByName(value.SpriteName), transform);
        cell.Init(_map, this, value, value.SpriteName, (float)index / count - .5f);
        _cells.Add(cell);
    }

    private ResourceCell GetCellByName(string name)
    {
        for (int i = 0; i < _cellNames.Length; i++)
        {
            if (name == _cellNames[i])
            {
                return _cellPrefabs[i];
            }
        }
        return _cellPrefabs[0];
    }
}
