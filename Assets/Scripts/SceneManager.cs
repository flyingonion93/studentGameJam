using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour {

    public Transform rollBottom, rollCenter, rollTop;

    public void OnTriggerEnter2D ( Collider2D col ) {
        print ( col.tag );   
    }


}
