using UnityEngine;
using System.Collections;

public class ManagerNavPoint : MonoBehaviour {

    public Transform LeftSide, RigthSide, knightPos, currentNavPoint;
    public bool navPointOnScreen;

	// Use this for initialization
	void Start () {
        navPointOnScreen = false;
	}

    //protected void NewNavPoint () {
    //    Vector3 randVector = GenerateRandomVector ();
    //    Instantiate ( currentNavPoint, randVector, Quaternion.identity );
    //}

    protected Vector3 GenerateRandomVector () {
        float randX = Random.Range ( LeftSide.position.x, RigthSide.position.x );
        float randY = Random.Range ( knightPos.position.y - 4, knightPos.position.y + 8 );
        Vector3 posVec = new Vector3 ( randX, randY, transform.position.z );
        navPointOnScreen = true;
        return posVec;
    }
}