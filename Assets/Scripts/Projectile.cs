using UnityEngine;
using System.Collections;

[RequireComponent ( typeof ( Rigidbody2D ) )]
public class Projectile : MonoBehaviour {

    public float hitDamage;

    public void Start () {

    }

    public void Update () {
        transform.position += transform.forward * Time.deltaTime;
    }

    public void OnTriggerEnter2D ( Collider2D col ) {
        Destroy ( gameObject );
    }
}
