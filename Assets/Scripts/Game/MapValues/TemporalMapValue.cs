using System;
using System.Collections.Generic;

namespace TemporalMapValue
{
    //[Serializable]
    //public class Local_offset
    //{
    //    public float x;
    //    public float y;

    //}
    //[Serializable]
    //public class Scale
    //{
    //    public float x;
    //    public float y;

    //}
    //[Serializable]
    //public class Placement
    //{
    //    public bool flipX;
    //    public bool flipY;
    //    public Local_offset local_offset;
    //    public float rotation_rad;
    //    public Scale scale;

    //}

    [Serializable]
    public class Vector2
    {
        public float x;
        public float y;
    }

    [Serializable]
    public class Resources
    {
        public string asset_id;
        public int color;
        public List<Vector2> geo;
    }

    [Serializable]
    public class Objects
    {
        public List<Resources> BuildingCell;
        public List<Resources> CharacterCell;
        public List<Resources> CloudCell;
        public List<Resources> DecalCell;
        public List<Resources> ResourceCell;
        public List<Resources> RoadCell;
        public List<Resources> StaticCell;
        public List<Resources> TileCell;

    }

    [Serializable]
    public class Map
    {
        public Objects objects;
    }

    [Serializable]
    public class Application
    {
        //public IList<string> metadata;
        public Map map;

    }
}