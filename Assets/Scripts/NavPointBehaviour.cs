using UnityEngine;
using System.Collections;

public class NavPointBehaviour : MonoBehaviour {

    void OnTriggerEnter2D ( Collider2D col ) {
        Destroy ( this.gameObject );
    }
}