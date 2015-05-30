﻿using UnityEngine;
using System.Collections;

public class Knight : MonoBehaviour {
    public float moveSpeed = 4.0f;
    public Transform ninjas;
    public float temps = 5f;

    public void Start () {
        ninjas.gameObject.SetActive ( false );
    }

    public void Update () {
        // FALTA COMPROVAR LA SALUT
        GameManager.Instance.ManagerNavPoint.StartCoroutine ( "MoveObject" );
    }

    public IEnumerator ItsNinjaTime () {
        
        ninjas.gameObject.SetActive ( true );
        yield return new WaitForSeconds ( temps );
        ninjas.gameObject.SetActive ( false );
    }
}