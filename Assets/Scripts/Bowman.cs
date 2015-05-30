using UnityEngine;
using System.Collections;

public class Bowman : Characters {

    public Transform arrow, knight;
    public float cooldownTime = 2f;

    public void Update () {
        DetectInput ();
    }

    public override void DetectInput () {
        bool overlaping = Physics2D.OverlapCircle ( transform.position, 15f, LayerMask.NameToLayer ( "Knight" ) );
        print ( overlaping.ToString () );
        if ( overlaping && canAttack ) {
            StartCoroutine ( "Attack" );
        }
    }

    public override void UpdatePosition () {
        throw new System.NotImplementedException ();
    }

    protected override IEnumerator Attack () {
        print ( "Attack" );
        canAttack = false;
        Instantiate ( arrow );
        Vector2.MoveTowards ( transform.position, knight.position, 10f );
        yield return new WaitForSeconds( cooldownTime );
        canAttack = true;
    } 
        
}