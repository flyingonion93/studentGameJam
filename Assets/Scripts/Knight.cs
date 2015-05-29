using UnityEngine;
using System.Collections;

public class Knight : MonoBehaviour {

    public float moveSpeed = 4.0f;

    [HideInInspector] public Transform navigationPoint;

    public void Update () {
        transform.LookAt ( navigationPoint );
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

}