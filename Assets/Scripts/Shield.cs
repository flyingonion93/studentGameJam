using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {

    public bool isMagnetic;
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
        if ( col.tag == "Swordman" || col.tag == "Bowman" || col.tag == "Horseman" )
            GameManager.Instance.ShieldManager.DownShield ( 1 );
        else if ( col.tag == "Ninja" )
            GameManager.Instance.ShieldManager.DownShield ( 2 );
        else if ( col.tag == "King" )
            GameManager.Instance.ShieldManager.DownShield ( 4 );
        else if ( col.tag == "Projectile" )
            col.rigidbody2D.AddForce ( col.transform.position );

    }
}