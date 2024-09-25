using System;
using System.Collections.Generic;

namespace TemporalMapValue
{
    [Serializable]
    public class Local_offset
    {
        public float x;
        public float y;

    }
    [Serializable]
    public class Scale
    {
        public float x;
        public float y;

    }
    [Serializable]
    public class Placement
    {
        public bool flipX;
        public bool flipY;
        public Local_offset local_offset;
        public float rotation_rad;
        public Scale scale;

    }
    [Serializable]
    public class Resources
    {
        public List<float> entry;
        public string id;
        public string name;
        public Placement placement;

    }
    [Serializable]
    public class Objects
    {
        public List<Resources> Buildings;
        public List<Resources> Characters;
        public List<Resources> Clouds;
        public List<Resources> Decals;
        public List<Resources> Resources;
        public List<Resources> Roads;
        public List<Resources> Statics;
        public List<Resources> Tiles;

    }
    [Serializable]
    public class Application
    {
        public IList<string> metadata;
        public Objects objects;

    }
}

namespace Temp
{
    [Serializable]
    public class BuildingCell
    {
        public string image;
        public float x;
        public float y;

    }
    [Serializable]
    public class CloudCell
    {
        public string image;
        public float x;
        public float y;

    }
    [Serializable]
    public class ResourceCell
    {
        public string image;
        public float x;
        public float y;

    }
    [Serializable]
    public class StaticCell
    {
        public string image;
        public float x;
        public float y;

    }
    [Serializable]
    public class TileCell
    {
        public string image;
        public float x;
        public float y;

    }
    [Serializable]
    public class Objects
    {
        public List<BuildingCell> BuildingCell;
        public List<CloudCell> CloudCell;
        public List<ResourceCell> ResourceCell;
        public List<StaticCell> StaticCell;
        public List<TileCell> TileCell;

    }
    [Serializable]
    public class Map
    {
        public Objects objects;

    }
    [Serializable]
    public class Application
    {
        public Map map;
    }
}