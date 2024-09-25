using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using System.IO;

public class MapValue
{
    public const string OBJECTS = "objects";
    public const string BUILDING = "BuildingCell";
    public const string RESOURCE = "ResourceCell";
    public const string ROCK = "RockCell";
    public const string TILE = "TileCell";
    public const string SPRITE_NAME = "image";
    public const string X_POSITION = "x";
    public const string Y_POSITION = "y";

    public List<BuildingCellValue> Buildings;
    public List<ResourceCellValue> Resources;
    public List<RockCellValue> Rocks;
    public List<TileCellValue> Tiles;


    public static MapValue FromJsonFile(string fileName)
    {
        float delta = 83f;
        //float delta = 1f;
        string filePath = $"{Application.persistentDataPath}/{fileName}";

        MapValue mapValue = new();
        var temporalMap = JsonUtility.FromJson<TemporalMapValue.Application>(File.ReadAllText(filePath));

        mapValue.Buildings = new List<BuildingCellValue>();
        mapValue.Resources = new List<ResourceCellValue>();
        mapValue.Rocks = new List<RockCellValue>();
        mapValue.Tiles = new List<TileCellValue>();

        if (temporalMap.objects.Buildings != null)
            foreach (var value in temporalMap.objects.Buildings)
                mapValue.Buildings.Add(new BuildingCellValue(
                    value.name,
                    value.id,
                    value.placement.local_offset.x / delta,
                    value.placement.local_offset.y / delta));

        if (temporalMap.objects.Characters != null)
            foreach (var value in temporalMap.objects.Characters)
                mapValue.Buildings.Add(new BuildingCellValue(
                    value.name,
                    value.id,
                    value.placement.local_offset.x / delta,
                    value.placement.local_offset.y / delta));

        if (temporalMap.objects.Clouds != null)
            foreach (var value in temporalMap.objects.Clouds)
                mapValue.Buildings.Add(new BuildingCellValue(
                    value.name,
                    value.id,
                    value.placement.local_offset.x / delta,
                    value.placement.local_offset.y / delta));

        if (temporalMap.objects.Decals != null)
            foreach (var value in temporalMap.objects.Decals)
                mapValue.Buildings.Add(new BuildingCellValue(
                    value.name,
                    value.id,
                    value.placement.local_offset.x / delta,
                    value.placement.local_offset.y / delta));

        if (temporalMap.objects.Resources != null)
            foreach (var value in temporalMap.objects.Resources)
            mapValue.Buildings.Add(new BuildingCellValue(
                value.name,
                value.id,
                value.placement.local_offset.x / delta,
                value.placement.local_offset.y / delta));

        if (temporalMap.objects.Roads != null)
            foreach (var value in temporalMap.objects.Roads)
                mapValue.Buildings.Add(new BuildingCellValue(
                    value.name,
                    value.id,
                    value.placement.local_offset.x / delta,
                    value.placement.local_offset.y / delta));

        if (temporalMap.objects.Statics != null)
            foreach (var value in temporalMap.objects.Statics)
                mapValue.Buildings.Add(new BuildingCellValue(
                    value.name,
                    value.id,
                    value.placement.local_offset.x / delta,
                    value.placement.local_offset.y / delta));

        if (temporalMap.objects.Tiles != null)
            foreach (var value in temporalMap.objects.Tiles)
                mapValue.Tiles.Add(new TileCellValue(
                    value.name,
                    value.id,
                    value.placement.local_offset.x / delta,
                    value.placement.local_offset.y / delta));

        return mapValue;
    }

    public static MapValue FromDataSnapshot(DataSnapshot dataSnapshot)
    {
        dataSnapshot = dataSnapshot.Child(OBJECTS);
        MapValue mapValue = new();

        mapValue.Buildings = new();
        var buildings = dataSnapshot.Child(BUILDING);
        foreach (var buildingData in buildings.Children)
        {
            var building = new BuildingCellValue(
                buildingData.Key,
                buildingData.Child(SPRITE_NAME).Value.ToString(),
                DistanceConverter.ToGame(float.Parse(buildingData.Child(X_POSITION).Value.ToString())),
                -DistanceConverter.ToGame(float.Parse(buildingData.Child(Y_POSITION).Value.ToString())));
            mapValue.Buildings.Add(building);
        }

        mapValue.Resources = new();
        var resources = dataSnapshot.Child(RESOURCE);
        foreach (var resourceData in resources.Children)
        {
            var resource = new ResourceCellValue(
                resourceData.Key,
                resourceData.Child(SPRITE_NAME).Value.ToString(),
                DistanceConverter.ToGame(float.Parse(resourceData.Child(X_POSITION).Value.ToString())),
                -DistanceConverter.ToGame(float.Parse(resourceData.Child(Y_POSITION).Value.ToString())));
            mapValue.Resources.Add(resource);
        }

        mapValue.Rocks = new();
        var rocks = dataSnapshot.Child(ROCK);
        foreach (var rockData in rocks.Children)
        {
            var rock = new RockCellValue(
                rockData.Key,
                rockData.Child(SPRITE_NAME).Value.ToString(),
                DistanceConverter.ToGame(float.Parse(rockData.Child(X_POSITION).Value.ToString())),
                -DistanceConverter.ToGame(float.Parse(rockData.Child(Y_POSITION).Value.ToString())));
            mapValue.Rocks.Add(rock);
        }

        mapValue.Tiles = new();
        var tiles = dataSnapshot.Child(TILE);
        foreach (var tileData in tiles.Children)
        {
            var tile = new TileCellValue(
                tileData.Key,
                tileData.Child(SPRITE_NAME).Value.ToString(),
                DistanceConverter.ToGame(float.Parse(tileData.Child(X_POSITION).Value.ToString())),
                -DistanceConverter.ToGame(float.Parse(tileData.Child(Y_POSITION).Value.ToString())));
            mapValue.Tiles.Add(tile);
        }

        return mapValue;
    }

    public static string ToJson(MapValue map)
    {
        return JsonUtility.ToJson(map.Buildings[0]);
    }

    public override string ToString()
    {
        string str = "";

        foreach (var building in Buildings)
        {
            str += building.ToString();
        }
        str += "\n";
        foreach (var resource in Resources)
        {
            str += resource.ToString();
        }
        str += "\n";
        foreach (var rock in Rocks)
        {
            str += rock.ToString();
        }
        str += "\n";
        foreach (var tile in Tiles)
        {
            str += tile.ToString();
        }

        return str;
    }
}
