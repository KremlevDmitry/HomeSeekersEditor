using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TileCells : Cells<TileCell, TileCellValue>
{
    [SerializeField]
    private TileCell _cellPrefab = default;


    public override void Generate(List<TileCellValue> cellsValues)
    {
        cellsValues = cellsValues.OrderBy(value => value.XPosition).OrderBy(value => value.YPosition).ToList();

        base.Generate(cellsValues);
    }

    protected override void CreateCell(TileCellValue value)
    {
        TileCell cell = Instantiate(_cellPrefab, transform);
        cell.Init(_map, this, value, value.SpriteName);
        _cells.Add(cell);
    }

    protected override void CreateCell(TileCellValue value, int index, int count)
    {
        TileCell cell = Instantiate(_cellPrefab, transform);
        cell.Init(_map, this, value, value.SpriteName, (float)index / count - .5f);
        _cells.Add(cell);
    }
}
