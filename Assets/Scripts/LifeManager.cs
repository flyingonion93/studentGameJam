using UnityEngine;
using System.Collections;

public class LifeManager : MonoBehaviour {

    public int life;
    [HideInInspector] public int lifeUp;
    [HideInInspector] public int kingsLife = 10;

    public void UpLife () {
        if ( life <= 3 ) {
            lifeUp = Random.Range ( 1, 3 );
        } else
            lifeUp = 1;
        if ( ( life + lifeUp ) > 10 )
            life = 10;
        else
            life += lifeUp;
    }

    public void DownLife ( int down ) {
        life -= down;
    }
}
