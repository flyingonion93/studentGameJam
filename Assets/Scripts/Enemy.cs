using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

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
                walkVel = 0.2f;
                break;
            case Enums.enemy_type.HORSEMAN:
                walkVel = 0.25f;
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
                break;
            case Enums.enemy_type.HORSEMAN:
                break;
        }
    }
}
