using UnityEngine;
using System.Collections;

public class ShieldManager : MonoBehaviour {

    public float powerTime = 5f;
    public float radi = 1.8f;
    public int resistance;

    public void UpShield () {
        if ( resistance >= 10 )
            resistance = 10;
        else if ( resistance == 0 ) {
            resistance = 10;
            GameManager.Instance.Squire.primaryShield.gameObject.SetActive ( true );
        } else
            resistance++;
    }

    public void DownShield ( int down ) {
        resistance -= down;
        if ( resistance <= 0 ) {
            // Music
            GameManager.Instance.Squire.smallShield.gameObject.SetActive ( false );
            GameManager.Instance.Squire.primaryShield.gameObject.SetActive ( false );
            GameManager.Instance.Squire.shotgun.gameObject.SetActive ( false );
            resistance = 0;
        }
    }

    //public IEnumerator MagnetShieldInstance () {
    //    GameManager.Instance.Shield.isMagnetic = true;
    //    yield return new WaitForSeconds ( 5 );
    //    GameManager.Instance.Shield.isMagnetic = false;
    //}

    public IEnumerator BigShieldInstance () {
        GameManager.Instance.Squire.smallShield.gameObject.SetActive ( false );
        GameManager.Instance.Squire.primaryShield.gameObject.SetActive ( false );
        GameManager.Instance.Squire.shotgun.gameObject.SetActive ( false );
        GameManager.Instance.Squire.heavyShield.gameObject.SetActive ( true );
        yield return new WaitForSeconds ( 5 );
        GameManager.Instance.Squire.smallShield.gameObject.SetActive ( false );        
        GameManager.Instance.Squire.heavyShield.gameObject.SetActive ( false );
        GameManager.Instance.Squire.primaryShield.gameObject.SetActive ( true );
    }

    public IEnumerator LittleShieldInstance () {
        GameManager.Instance.Squire.primaryShield.gameObject.SetActive ( false );
        GameManager.Instance.Squire.heavyShield.gameObject.SetActive ( false );
        GameManager.Instance.Squire.shotgun.gameObject.SetActive ( false );
        GameManager.Instance.Squire.smallShield.gameObject.SetActive ( true );
        yield return new WaitForSeconds ( 5 );
        GameManager.Instance.Squire.smallShield.gameObject.SetActive ( false );
        GameManager.Instance.Squire.heavyShield.gameObject.SetActive ( false );
        GameManager.Instance.Squire.shotgun.gameObject.SetActive ( false );
        GameManager.Instance.Squire.primaryShield.gameObject.SetActive ( true );
    }

    public IEnumerator ShotgunInstance () {
        GameManager.Instance.Squire.smallShield.gameObject.SetActive ( false );
        GameManager.Instance.Squire.heavyShield.gameObject.SetActive ( false );
        GameManager.Instance.Squire.primaryShield.gameObject.SetActive ( false );
        GameManager.Instance.Squire.shotgun.gameObject.SetActive ( true );
        yield return new WaitForSeconds ( 10 );
        GameManager.Instance.Squire.smallShield.gameObject.SetActive ( false );
        GameManager.Instance.Squire.heavyShield.gameObject.SetActive ( false );        
        GameManager.Instance.Squire.shotgun.gameObject.SetActive ( false );
        GameManager.Instance.Squire.primaryShield.gameObject.SetActive ( true );
    }
}