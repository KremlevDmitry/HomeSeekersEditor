using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RockCells : Cells<RockCell, RockCellValue>
{
    [SerializeField]
    private RockCell[] _cellPrefabs = default;
    [SerializeField]
    private string[] _cellNames = default;


    public override void Generate(List<RockCellValue> cellsValues)
    {
        //cellsValues = cellsValues.OrderBy(value => value.YPosition).OrderBy(value => value.XPosition).ToList();

        base.Generate(cellsValues);
    }

    protected override void CreateCell(RockCellValue value)
    {
        RockCell cell = Instantiate(GetCellByName(value.SpriteName), transform);
        cell.Init(_map, this, value, value.SpriteName);
        _cells.Add(cell);
    }

    protected override void CreateCell(RockCellValue value, int index, int count)
    {
        RockCell cell = Instantiate(GetCellByName(value.SpriteName), transform);
        cell.Init(_map, this, value, value.SpriteName, (float)index / count - .5f);
        _cells.Add(cell);
    }

    private RockCell GetCellByName(string name)
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
