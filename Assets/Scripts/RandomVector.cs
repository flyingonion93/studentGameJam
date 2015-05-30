using UnityEngine;
using System.Collections;

public class RandomVector : MonoBehaviour {

    public Transform LeftSide, RigthSide;

    public Vector3 GenerateRandomVector () {
        float randX = Random.Range ( LeftSide.position.x, RigthSide.position.x );
        float randY = Random.Range ( transform.position.y - 4, transform.position.y + 8 );
        Vector3 posVec = new Vector3 ( randX, randY, transform.position.z );
        return posVec;
    }

}