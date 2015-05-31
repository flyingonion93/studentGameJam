using UnityEngine;
using System.Collections;

public class Enemy : Characters {

    public Transform Left, Right;
    public Enums.enemy_type currentType;
    public int attackValue;
    protected bool toLeft;

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
                float x = transform.position.x - GameManager.Instance.Knight.transform.position.x;
                float y = transform.position.y - GameManager.Instance.Knight.transform.position.y;
                if ( (x < 10 || x > -10) && (y < 10 || y > -10) ) {
                    transform.position = Vector3.MoveTowards ( transform.position, GameManager.Instance.Knight.transform.position, walkVel * Time.deltaTime );
                    float rx = GameManager.Instance.Knight.transform.position.x;
                    float ry = GameManager.Instance.Knight.transform.position.y;
                    if ( rx != 0.0 || ry != 0.0 ) {
                        float angle = Mathf.Atan2 ( ry, rx ) * Mathf.Rad2Deg;
                        transform.rotation = Quaternion.AngleAxis ( 90.0f - angle, Vector3.forward );
                    }
                }
                break;
            case Enums.enemy_type.HORSEMAN:
                if ( (transform.position.x >= Left.position.x) && (transform.position.x <= Left.position.x + 5) ) {
                    Vector3 aux = new Vector3 ( Right.position.x, GameManager.Instance.Knight.transform.position.y, Right.position.z );
                    transform.position = Vector3.MoveTowards ( transform.position, aux, walkVel * Time.deltaTime );
                    toLeft = false;
                    if ( GameManager.Instance.Knight.transform.position.y > transform.position.y )
                        transform.rotation = Quaternion.AngleAxis ( 180.0f, Vector3.forward );
                    else
                        transform.rotation = Quaternion.AngleAxis ( 0.0f, Vector3.forward );
                } else if ( ( transform.position.x <= Right.position.x ) && ( transform.position.x >= Right.position.x - 5 ) ) {
                    Vector3 aux = new Vector3 ( Left.position.x, GameManager.Instance.Knight.transform.position.y, Right.position.z );
                    transform.position = Vector3.MoveTowards ( transform.position, aux, walkVel * Time.deltaTime );
                    toLeft = true;
                    if ( GameManager.Instance.Knight.transform.position.y > transform.position.y )
                        transform.rotation = Quaternion.AngleAxis ( 180.0f, Vector3.forward );
                    else
                        transform.rotation = Quaternion.AngleAxis ( 0.0f, Vector3.forward );
                } else {
                    if ( toLeft ) {
                        Vector3 aux = new Vector3 ( Left.position.x, GameManager.Instance.Knight.transform.position.y, Right.position.z );
                        transform.position = Vector3.MoveTowards ( transform.position, aux, walkVel * Time.deltaTime );
                        if ( GameManager.Instance.Knight.transform.position.y > transform.position.y )
                            transform.rotation = Quaternion.AngleAxis ( 180.0f, Vector3.forward );
                        else
                            transform.rotation = Quaternion.AngleAxis ( 0.0f, Vector3.forward );
                    } else {
                        Vector3 aux = new Vector3 ( Right.position.x, GameManager.Instance.Knight.transform.position.y, Right.position.z );
                        transform.position = Vector3.MoveTowards ( transform.position, aux, walkVel * Time.deltaTime );
                        if ( GameManager.Instance.Knight.transform.position.y > transform.position.y )
                            transform.rotation = Quaternion.AngleAxis ( 180.0f, Vector3.forward );
                        else
                            transform.rotation = Quaternion.AngleAxis ( 0.0f, Vector3.forward );
                    }
                }
                break;
        }
    }

    protected Vector3 GenerateRandomVector () {
        float randX = Random.Range ( Left.position.x, Right.position.x );
        float randY = Random.Range ( transform.position.y - 1, transform.position.y + 1 );
        Vector3 posVec = new Vector3 ( randX, randY, transform.position.z );
        return posVec;
    }
}