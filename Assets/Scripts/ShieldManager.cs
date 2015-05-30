using UnityEngine;
using System.Collections;

public class ShieldManager : MonoBehaviour {

    public Transform magnetShield, bigShield, littleShield, shieldPos;

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

    public void MagnetShieldInstance () {
        Instantiate ( magnetShield, shieldPos.position, Quaternion.identity );
    }

    public void BigShieldInstance () { 

    }

    public void LittleShieldInstance () { 

    }
}
