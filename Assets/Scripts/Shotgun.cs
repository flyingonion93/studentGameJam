using UnityEngine;
using System.Collections;

public class Shotgun : MonoBehaviour {

    public Transform proj1, proj2, proj3, shotRange;
    public float sVelocity;
    protected int shotsFired;

    public void Start () {
        proj1.gameObject.SetActive ( false );
        proj2.gameObject.SetActive ( false );
        proj3.gameObject.SetActive ( false );
        shotsFired = 0;
    }

    public void Update () {
        if ( Input.GetKeyDown ( "b" ) ) {
            switch ( shotsFired ) {
                case 0:
                    proj1.gameObject.SetActive ( true );
                    proj1.gameObject.rigidbody2D.AddForce ( Vector2.MoveTowards ( proj1.position, shotRange.position, sVelocity ) );
                    break;
                case 1:
                    proj2.gameObject.SetActive ( true );
                    proj2.gameObject.rigidbody2D.AddForce ( Vector2.MoveTowards ( proj2.position, shotRange.position, sVelocity * Time.deltaTime ) );
                    break;
                case 2:
                    proj3.gameObject.SetActive ( true );
                    proj3.gameObject.rigidbody2D.AddForce ( Vector2.MoveTowards ( proj3.position, shotRange.position, sVelocity * Time.deltaTime ) );
                    break;
            }
        }
        
    }
}