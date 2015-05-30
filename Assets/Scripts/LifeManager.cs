using UnityEngine;
using System.Collections;

public class LifeManager : MonoBehaviour {

    public int life = 10;
    [HideInInspector] public int lifeUp;

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
		GameManager.Instance.Animations.damaged = true;
    }
}
