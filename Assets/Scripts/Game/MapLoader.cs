using UnityEngine;
using Firebase.Database;

public class MapLoader : MonoBehaviour
{
    private const string MAP = "map";

    private FirebaseDatabase _database = default;


    private void Start()
    {
        LoadLocalMap();
        //FirebaseInit.OnFirebaseInitialized.AddListener(() =>
        //{
        //    _database = FirebaseDatabase.DefaultInstance;
        //    DownloadMap();
        //});
    }


    public void LoadLocalMap()
    {
        Map.Instance.Value = MapValue.FromJsonFile("map_0.json");
    }

    public void DownloadMap()
    {
        _database.GetReference(MAP).GetValueAsync().ContinueWith(task =>
        {
            Map.Instance.Value = MapValue.FromDataSnapshot(task.Result);
            //Debug.Log(MapValue.ToJson(Map.Instance.Value));
        });
    }

    public void UploadMap()
    {
        _database.GetReference(MAP).SetRawJsonValueAsync(MapValue.ToJson(Map.Instance.Value));
    }
}
