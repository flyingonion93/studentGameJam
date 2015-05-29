using UnityEngine;

/// <summary>
/// Singleton pattern for manager handling.
/// </summary>
/// <typeparam name="T">Any element that inherits from MonoBehaviour</typeparam>
public class osSingleton<T> : MonoBehaviour where T : MonoBehaviour {

    private static T _instance;

    private static object _lock = new object ();

    public static T Instance {
        get {
            if ( applicationIsQuitting ) {
                return null;
            }
            lock ( _lock ) {
                if ( _instance == null ) {
                    _instance = (T) FindObjectOfType<T> ();
                    if ( FindObjectsOfType<T> ().Length > 1 ) {
                        //FATAL. More than an instance.
                        return _instance;
                    }
                    if( _instance == null ){ 
                        GameObject singleton = new GameObject();
                        _instance = singleton.AddComponent<T>();
                        singleton.name = "(singleton)" + typeof( T ).ToString();
                        DontDestroyOnLoad( singleton );
                    }
                }
                return _instance;
            }
        }
    }

    private static bool applicationIsQuitting = false;

    public void OnDestroy () {
        applicationIsQuitting = false;
    }

}