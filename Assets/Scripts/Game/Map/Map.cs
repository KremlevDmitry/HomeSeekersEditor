using System.Collections;
using System.Collections.Generic;
using UnityCommunity.UnitySingleton;
using UnityEngine;

public class Map : MonoSingleton<Map>
{
    public MapValue Value = null;

    [SerializeField]
    private TileCells _tileCells = default;
    [SerializeField]
    private TileCells _roadsCells = default;
    [SerializeField]
    private RockCells _rockCells = default;
    [SerializeField]
    private BuildingCells _buildingCells = default;
    [SerializeField]
    private ResourceCells _resourceCells = default;
    [SerializeField]
    private TileCells _cloudsCells = default;


    protected override void Awake()
    {
        base.Awake();
        Init();


        StartCoroutine(WaitUploadingMap());
    }


    public void Generate()
    {
        Destroy();

        _tileCells.Generate(Value.Tiles);
        _roadsCells.Generate(Value.Roads);
        _rockCells.Generate(Value.Rocks);
        _buildingCells.Generate(Value.Buildings);
        _resourceCells.Generate(Value.Resources);
        _cloudsCells.Generate(Value.Clouds);
    }

    public void Destroy()
    {

    }


    private void Init()
    {
        _tileCells.Init(this);
        _rockCells.Init(this);
        _buildingCells.Init(this);
        _resourceCells.Init(this);
    }


    private IEnumerator WaitUploadingMap()
    {
        yield return new WaitWhile(() => Value == null);
        Generate();
    }
}
