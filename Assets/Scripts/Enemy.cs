using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public Transform Left, Rigth;

    public Camera mainCamera;
    Enums.enemy_type currentType;
    public int attackValue;
    public float walkVel;
    public bool alive;

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

    public void Update () {
        float x = mainCamera.transform.position.x;
        float y = mainCamera.transform.position.y;
        float height = mainCamera.orthographicSize;
        float width = height * mainCamera.aspect;

        if ( alive && ( (transform.position.x > x + width) || (transform.position.x < x - width) ) || ( (transform.position.y > y + height) || (transform.position.y < y - height) ) ) {
            Destroy ( this.gameObject );
        } else if ( alive && currentType != Enums.enemy_type.BOWMAN ) {
            UpdatePosition ();
        }
    }

    public void UpdatePosition () {
        switch ( currentType ) { 
            case Enums.enemy_type.SWORDMAN:
                if ( Physics2D.OverlapCircle ( transform.position, 3.0f, LayerMask.NameToLayer("Knight") ) ) {
                    Vector3 aux = GameManager.Instance.Knight.transform.position;
                    transform.position = Vector3.MoveTowards ( transform.position, aux, walkVel * Time.deltaTime );
                }
                break;
            case Enums.enemy_type.HORSEMAN:
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