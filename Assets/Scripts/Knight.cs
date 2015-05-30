using UnityEngine;
using System.Collections;

public class Knight : MonoBehaviour {
    public float moveSpeed = 4.0f;

    public void Update () {
        Vector3 lookVector = new Vector3 (1, 1, 0);
        transform.LookAt ( GameManager.Instance.ManagerNavPoint.currentNavPoint.position );
        transform.position += lookVector * moveSpeed * Time.deltaTime;
    }

}