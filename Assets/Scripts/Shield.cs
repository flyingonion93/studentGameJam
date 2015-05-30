using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {

    public Transform standardShield, heavyShield, smallShield, shieldHolster;

    // Use this for initialization
    void Start () {
        Instantiate( standardShield, shieldHolster.position, Quaternion.identity );
        standardShield.parent = shieldHolster;
    }

    // Update is called once per frame
    void Update () {
        transform.position = shieldHolster.position;
    }

    public void OnTriggerEnter2D ( Collider2D col ) { 

    }
}