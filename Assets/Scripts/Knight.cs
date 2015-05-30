using UnityEngine;
using System.Collections;

public class Knight : MonoBehaviour {
    public float moveSpeed = 4.0f;
    public Transform ninjas;

    public void Start () {
        ninjas.gameObject.SetActive ( false );
    }

    public void Update () {
        // FALTA COMPROVAR LA SALUT
        Vector3 lookVector = new Vector3 (1, 1, 0);
        transform.LookAt ( GameManager.Instance.ManagerNavPoint.currentNavPoint.position );
        transform.position += lookVector * moveSpeed * Time.deltaTime;
    }

    protected void ItsNinjaTime () { 
        
    }

}