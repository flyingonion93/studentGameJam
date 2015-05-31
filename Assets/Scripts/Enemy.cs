using UnityEngine;
using System.Collections;

public class Enemy : Characters {

    public Transform Left, Right;
    public Transform arrow;
    public Enums.enemy_type currentType;
    public int attackValue;
    protected bool toLeft, toLeftKing;  // per als horsemen i el rei

    public void Start () {
        currentInputState = Enums.inputState_nm.NONE;
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
            case Enums.enemy_type.KING:
                walkVel = 2.0f;
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
        else if ( alive && currentType == Enums.enemy_type.BOWMAN )
            UpdateBowman ();
        else if ( alive && currentType == Enums.enemy_type.KING ) {
            print ( "Hay un pene para Laura" );
            UpdateKing ();
        } else
            Destroy ( this.gameObject );
    }

    public void UpdateKing () {
        currentInputState = Enums.inputState_nm.WALK;
        float x = GameManager.Instance.Knight.transform.position.x;
        float y = GameManager.Instance.Knight.transform.position.y;
        if ( ( transform.position.x >= Left.position.x ) && ( transform.position.x <= Left.position.x + 5 ) ) {
            Vector3 aux = new Vector3 ( Right.position.x, GameManager.Instance.Knight.transform.position.y * 3, Right.position.z );
            transform.position = Vector3.MoveTowards ( transform.position, aux, walkVel * Time.deltaTime );
            toLeftKing = false;
        } else if ( ( transform.position.x <= Right.position.x ) && ( transform.position.x >= Right.position.x - 5 ) ) {
            Vector3 aux = new Vector3 ( Left.position.x, GameManager.Instance.Knight.transform.position.y * 3, Right.position.z );
            transform.position = Vector3.MoveTowards ( transform.position, aux, walkVel * Time.deltaTime );
            toLeftKing = true;
        } else {
            if ( toLeftKing ) {
                Vector3 aux = new Vector3 ( Left.position.x, GameManager.Instance.Knight.transform.position.y * 3, Right.position.z );
                transform.position = Vector3.MoveTowards ( transform.position, aux, walkVel * Time.deltaTime );
            } else {
                Vector3 aux = new Vector3 ( Right.position.x, GameManager.Instance.Knight.transform.position.y * 3, Right.position.z );
                transform.position = Vector3.MoveTowards ( transform.position, aux, walkVel * Time.deltaTime );
            }
        }
    }

    // VA MAL
    public void UpdateBowman () {
        float x = transform.position.x - GameManager.Instance.Knight.transform.position.x;
        float y = transform.position.y - GameManager.Instance.Knight.transform.position.y;
        if ( ( x < 12 || x > -12 ) && ( y < 12 || y > -12 ) ) {

            currentInputState = Enums.inputState_nm.ATTACK;

            float rx = GameManager.Instance.Knight.transform.position.x;
            float ry = GameManager.Instance.Knight.transform.position.y;
            if ( rx != 0.0 || ry != 0.0 ) {
                float angle = Mathf.Atan2 ( ry, rx ) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis ( 90.0f - angle, Vector3.forward );
                InvokeRepeating ("fletxes", 0.5f, 1.0f);
                /*Vector3 aux2 = new Vector3 ();
                // ACÍ HI HA QUE INVOCAR UNA FLETXA I LLANÇAR-LA, ESPERAR UNS SEGONS I TORNAR A REPETIR MENTRE L'OBJECTIU ESTIGA A 12 DE DISTÀNCIA
                if ( rx > transform.position.x && ry > transform.position.y )
                    aux2 = new Vector3 ( transform.position.x + 1, transform.position.y + 1, 0 );
                else if ( rx > transform.position.x && ry <= transform.position.y )
                    aux2 = new Vector3 ( transform.position.x + 1, transform.position.y - 1, 0 );
                else if ( rx <= transform.position.x && ry > transform.position.y )
                    aux2 = new Vector3 ( transform.position.x - 1, transform.position.y + 1, 0 );
                else if ( rx <= transform.position.x && ry <= transform.position.y )
                    aux2 = new Vector3 ( transform.position.x - 1, transform.position.y - 1, 0 );
                Instantiate (arrow, aux2, transform.rotation);
                arrow.rigidbody2D.AddForce (new Vector2(rx,ry));
                StartCoroutine ( "arrowDelay" );*/
            }
        }
    }

    public IEnumerator arrowDelay () {

        yield return new WaitForSeconds ( 2.0f );
    }

    public void fletxes () {
        float rx = GameManager.Instance.Knight.transform.position.x;
        float ry = GameManager.Instance.Knight.transform.position.y;
        Vector3 aux2 = new Vector3 ();
        if ( rx > transform.position.x && ry > transform.position.y )
            aux2 = new Vector3 ( transform.position.x + 1, transform.position.y + 1, 0 );
        else if ( rx > transform.position.x && ry <= transform.position.y )
            aux2 = new Vector3 ( transform.position.x + 1, transform.position.y - 1, 0 );
        else if ( rx <= transform.position.x && ry > transform.position.y )
            aux2 = new Vector3 ( transform.position.x - 1, transform.position.y + 1, 0 );
        else if ( rx <= transform.position.x && ry <= transform.position.y )
            aux2 = new Vector3 ( transform.position.x - 1, transform.position.y - 1, 0 );
        
        Instantiate ( arrow, aux2, transform.rotation );
        arrow.rigidbody2D.AddForce ( new Vector2 ( rx, ry ) );
    }

    // VA BÉ
    public override void UpdatePosition () {
        switch ( currentType ) {
            case Enums.enemy_type.SWORDMAN:
                float x = transform.position.x - GameManager.Instance.Knight.transform.position.x;
                float y = transform.position.y - GameManager.Instance.Knight.transform.position.y;
                if ( (x < 8 || x > -8) && (y < 8 || y > -8) ) {
                    transform.position = Vector3.MoveTowards ( transform.position, GameManager.Instance.Knight.transform.position, walkVel * Time.deltaTime );
                    float rx = GameManager.Instance.Knight.transform.position.x;
                    float ry = GameManager.Instance.Knight.transform.position.y;
                    if ( rx != 0.0 || ry != 0.0 ) {
                        float angle = Mathf.Atan2 ( ry, rx ) * Mathf.Rad2Deg;
                        transform.rotation = Quaternion.AngleAxis ( 270.0f - angle, Vector3.forward );
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

    public void OnTriggerEnter2D ( Collider2D col ) {
        switch ( col.tag ) {
            case "KillMachine":
                if ( this.currentType == Enums.enemy_type.KING && GameManager.Instance.LifeManager.kingsLife > 0 )
                    GameManager.Instance.LifeManager.kingsLife--;
                else
                    Destroy ( this.gameObject );
                GameManager.Instance.ShieldManager.resistance--;
                break;
        }
    }
}