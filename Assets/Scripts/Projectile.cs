using UnityEngine;
using System.Collections;

[RequireComponent ( typeof ( Rigidbody2D ) )]
public class Projectile : MonoBehaviour {

    public float hitDamage;

    public void Start () {
        /*float rx = GameManager.Instance.Knight.transform.position.x;
        float ry = GameManager.Instance.Knight.transform.position.y;
        if ( rx != 0.0 || ry != 0.0 ) {
            float angle = Mathf.Atan2 ( ry, rx ) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis ( 90.0f - angle, Vector3.forward );
        }*/
    }

    public void Update () {
        transform.position += transform.forward * Time.deltaTime;
    }

    public void OnTriggerEnter2D ( Collider2D col ) {
        Destroy ( gameObject );
    }
}
