using UnityEngine;
using System.Collections;

public class ShieldManager : MonoBehaviour {

    public Transform magnetShield, bigShield, littleShield, shieldPos;
    public float radi = 1.8f;
    public int resistance = 10;

    public void UpShield () {
        if ( resistance >= 10 )
            resistance = 10;
        else
            resistance++;
    }

    public void DownShield ( int down ) {
        resistance -= down;
    }

    public void BigShieldInstance () { 

    }

    public void LittleShieldInstance () { 

    }

    public void MagnetShield () {
        bool detected = Physics2D.OverlapCircle ( shieldPos.position, radi );
        if ( detected ) { 
            //shieldPos.rigidbody2D.AddForce (
        }
    }
}
