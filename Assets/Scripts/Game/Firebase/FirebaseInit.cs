using UnityEngine;
using UnityEngine.Events;
using Firebase;
using Firebase.Extensions;

public class FirebaseInit : MonoBehaviour
{
    public static bool IsInit { get; private set; } = false;
    public static UnityEvent OnFirebaseInitialized = new UnityEvent();


    private void Awake()
    {
        Init();
    }


    private void Init()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            if (task.Exception != null)
            {
                throw new System.Exception();
            }

            IsInit = true;
            OnFirebaseInitialized.Invoke();
        });
    }
}
