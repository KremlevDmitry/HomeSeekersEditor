using System.Collections;
using System.Collections.Generic;
using Firebase.Database;
using UnityEngine;

public class DatabaseManager
{
    private static FirebaseDatabase _database = default;


    private void Awake()
    {
        if (FirebaseInit.IsInit)
        {
            Init();
        }
        else
        {
            FirebaseInit.OnFirebaseInitialized.AddListener(Init);
        }
    }


    private void Init()
    {
        _database = _database = FirebaseDatabase.DefaultInstance;

        DownloadAllData();
    }

    private static void DownloadAllData()
    {

    }
}
