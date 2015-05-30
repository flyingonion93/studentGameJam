using UnityEngine;
using System.Collections;

public class Ninjas : MonoBehaviour {

    public int angle = 0;

    void Start () { 
        
    }

	void Update () {
        print ( "ninjas" );
        transform.position = GameManager.Instance.Knight.transform.position;
        transform.rotation = Quaternion.AngleAxis ( angle, Vector3.forward );
        angle++;
	}
}
