using System;
using System.Collections.Generic;

namespace TemporalMapValue
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