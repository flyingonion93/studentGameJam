using UnityEngine;
using System.Collections;

public class Camara : MonoBehaviour {

    #region Public Attributes
    public float dampTime = 0.15f;
    private Vector3 velocity = Vector3.zero;
    public Transform target;
    #endregion

    #region Public Interface
    public void Update () {
        if ( target ) {
            Vector3 point = camera.WorldToViewportPoint ( target.position );
            Vector3 delta = target.position - camera.ViewportToWorldPoint ( new Vector3 ( 0.5f, 0.5f, point.z ) ); //(new Vector3(0.5, 0.5, point.z));
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp ( transform.position, destination, ref velocity, dampTime );
        }
    }

    public void LateUpdate () {
        Camera.main.transform.position = new Vector3 ( 0, Camera.main.transform.position.y, Camera.main.transform.position.z );
    }
    #endregion
}