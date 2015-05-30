using UnityEngine;
using System.Collections;

public class Enemy : Characters {

    public Transform Left, Rigth;
    public Enums.enemy_type currentType;
    public int attackValue;

    public void Start () {
        alive = true;
        attackValue = 1;
        switch ( currentType ) {
            case Enums.enemy_type.BOWMAN:
                walkVel = 0.0f;
                break;
            case Enums.enemy_type.SWORDMAN:
                walkVel = 2.5f;
                break;
            case Enums.enemy_type.HORSEMAN:
                walkVel = 3.0f;
                break;
        }
    }

    protected override IEnumerator Attack () {
        throw new System.NotImplementedException ();
    }

    public override void DetectInput () {
        throw new System.NotImplementedException ();
    }



    public void Update () {
        if ( alive && currentType != Enums.enemy_type.BOWMAN )
            UpdatePosition ();
    }

    public override void UpdatePosition () {
        switch ( currentType ) {
            case Enums.enemy_type.SWORDMAN:
                if ( Physics2D.OverlapCircle ( transform.position, 3.0f, LayerMask.NameToLayer ( "Knight" ) ) ) {
                    print("VIST");
                    transform.position = Vector3.MoveTowards ( transform.position, GameManager.Instance.Knight.transform.position, walkVel * Time.deltaTime );
                }
                break;
            case Enums.enemy_type.HORSEMAN:
                if ( transform.position == Left.position ) {
                    Vector3 aux = new Vector3 ( Rigth.position.x, GameManager.Instance.Knight.transform.position.y, Rigth.position.z );
                    transform.position = Vector3.MoveTowards ( transform.position, aux, walkVel * Time.deltaTime );
                } else {
                    Vector3 aux = new Vector3 ( Left.position.x, GameManager.Instance.Knight.transform.position.y, Rigth.position.z );
                    transform.position = Vector3.MoveTowards ( transform.position, aux, walkVel * Time.deltaTime );
                }
                break;
        }
    }

    protected Vector3 GenerateRandomVector () {
        float randX = Random.Range ( Left.position.x, Rigth.position.x );
        float randY = Random.Range ( transform.position.y - 1, transform.position.y + 1 );
        Vector3 posVec = new Vector3 ( randX, randY, transform.position.z );
        return posVec;
    }
}