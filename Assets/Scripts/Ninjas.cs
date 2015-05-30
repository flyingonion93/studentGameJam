using UnityEngine;
using System.Collections;

public class Ninjas : MonoBehaviour {

    //Transform knight;
    public int angle = 0;

    void Start () { 
        
    }

	void Update () {
        print ( "ets lo puto crack" );
        //transform.position = knight.transform.position;
        transform.rotation = Quaternion.AngleAxis ( angle, Vector3.forward );
        angle++;
	}
}
