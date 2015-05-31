using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {

    public bool isMagnetic;
    public Transform standardShield, heavyShield, smallShield, shieldHolster;

    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    void Update () {        
    }

    public void OnTriggerEnter2D ( Collider2D col ) {
        print ( "touch" );
        if ( col.tag == "Swordman" || col.tag == "Bowman" || col.tag == "Horseman" ) {
            GameManager.Instance.ShieldManager.DownShield ( 1 );
            Destroy ( col.gameObject );
        } else if ( col.tag == "King" ) {
            GameManager.Instance.ShieldManager.DownShield ( 4 );
            //else if ( col.tag == "Projectile" )
            //    col.rigidbody2D.AddForce ( -col.transform.position );
        }
    }
}