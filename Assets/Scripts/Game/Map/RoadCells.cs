using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoadCells : Cells<RoadCell, RoadCellValue>
{
    [SerializeField]
    private RoadCell _cellPrefab = default;


    public override void Generate(List<RoadCellValue> cellsValues)
    {
        //cellsValues = cellsValues.OrderBy(value => value.YPosition).OrderBy(value => value.XPosition).ToList();

        base.Generate(cellsValues);
    }

    protected override void CreateCell(RoadCellValue value)
    {
        RoadCell cell = Instantiate(_cellPrefab, transform);
        cell.Init(_map, this, value, value.SpriteName);
        _cells.Add(cell);
    }

    protected override void CreateCell(RoadCellValue value, int index, int count)
    {
        RoadCell cell = Instantiate(_cellPrefab, transform);
        cell.Init(_map, this, value, value.SpriteName, (float)index / count - .5f);
        _cells.Add(cell);
    }
}
