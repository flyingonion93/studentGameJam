using UnityEngine;
using System.Collections;

public class ManagerNavPoint : MonoBehaviour {

    public Transform LeftSide, RigthSide, knightPos, currentNavPoint;
    public bool navPointOnScreen;

	// Use this for initialization
	void Start () {
        navPointOnScreen = false;
	}
	
	// Update is called once per frame
	void Update () {
            StartCoroutine ( "NewNavPoint" );
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

    public IEnumerator NewNavPoint () {
        while ( true ) {
            Vector3 pointA = transform.position;
            Vector3 pointB = GenerateRandomVector ();
            yield return StartCoroutine ( MoveObject ( transform, pointA, pointB, 3.0f ) );
        }
    }

    public IEnumerator MoveObject ( Transform thisTransform, Vector3 startPos, Vector3 endPos, float time ) {
        var i = 0.0f;
        var rate = 1.0f / time;
        while ( i < 1.0f ) {
            i += Time.deltaTime * rate;
            thisTransform.position = Vector3.Lerp ( startPos, endPos, i );
            yield return null;
        }
    }

}