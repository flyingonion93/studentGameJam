using UnityEngine;
using System.Collections;

public class Knight : MonoBehaviour {
    //public Transform aux;
    public float moveSpeed = 4.0f;
    //int aux1, aux2;

    public void Update () {
        Vector3 lookVector = GameManager.Instance.ManagerNavPoint.currentNavPoint.position;
        lookVector.z = 0f;
        transform.LookAt ( lookVector );
        Debug.DrawRay ( transform.position, lookVector );
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

}