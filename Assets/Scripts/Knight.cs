using UnityEngine;
using System.Collections;

public class Knight : MonoBehaviour {

    public Transform LeftSide, RigthSide, currentNavPoint;

    public float moveSpeed = 4.0f;
    public Transform ninjas;
    public float temps = 5f;

    public void Start () {
        ninjas.gameObject.SetActive ( false );
    }

    public void Update () {
        // FALTA COMPROVAR LA SALUT
        StartCoroutine ( "NewNavPoint" );
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

    public IEnumerator ItsNinjaTime () {
        
        ninjas.gameObject.SetActive ( true );
        yield return new WaitForSeconds ( temps );
        ninjas.gameObject.SetActive ( false );
    }

    protected Vector3 GenerateRandomVector () {
        float randX = Random.Range ( LeftSide.position.x, RigthSide.position.x );
        float randY = Random.Range ( transform.position.y - 4, transform.position.y + 8 );
        Vector3 posVec = new Vector3 ( randX, randY, transform.position.z );
        return posVec;
    }
}