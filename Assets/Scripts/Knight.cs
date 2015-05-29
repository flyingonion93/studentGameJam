using UnityEngine;
using System.Collections;

public class Knight : MonoBehaviour {

    public float moveSpeed = 4.0f;

    public void Update () {
        Vector3 lookVector = GameManager.Instance.ManagerNavPoint.currentNavPoint.position;
        lookVector.z = 0f;
        transform.LookAt ( lookVector );
        Debug.DrawRay ( -transform.position, GameManager.Instance.ManagerNavPoint.currentNavPoint.position, Color.cyan );
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

}