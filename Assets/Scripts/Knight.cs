using UnityEngine;
using System.Collections;

public class Knight : MonoBehaviour {
    //public Transform aux;
    public float moveSpeed = 4.0f;
    //int aux1, aux2;

    public void Update () {
        /*if ( GameManager.Instance.ManagerNavPoint.currentNavPoint.position.x < 0 )
            aux1 = -1;
        else
            aux1 = 1;
        if ( GameManager.Instance.ManagerNavPoint.currentNavPoint.position.y < 0 )
            aux2 = -1;
        else
            aux2 = 1;
        Vector3 aux = new Vector3 ( aux1, aux2, 0 );
        aux = GameManager.Instance.ManagerNavPoint.currentNavPoint;*/
        transform.LookAt ( GameManager.Instance.ManagerNavPoint.currentNavPoint );
        //transform.position += aux * moveSpeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards ( transform.position, GameManager.Instance.ManagerNavPoint.currentNavPoint.position, moveSpeed * Time.deltaTime );
    }

}