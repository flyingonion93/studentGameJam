using UnityEngine;
using System.Collections;

public class Squire : MonoBehaviour {

    [HideInInspector] public Vector2 spawnPos;
    [HideInInspector] public Enums.inputState_nm currentInputState;
    public float walkVel;
    protected Transform _transform;
    protected bool alive, inverted;
    protected Vector3 movementValue;

    public void Start () {
        alive = true;
        inverted = false;
    }

    public void Update () {
        // Falta el if del manager de la salut if > 0
        currentInputState = Enums.inputState_nm.NONE;
        DetectInput ();
        UpdatePosition ();
        // Falta el else, si està mort
        currentInputState = Enums.inputState_nm.DEAD;
    }

    protected void DetectInput () {
        float movementValueH = Input.GetAxis ("Horizontal");
        float movementValueV = Input.GetAxis ("Vertical");
        if ( inverted )
            movementValue = new Vector3 ( -movementValueH, -movementValueV, 0.0f ) * 0.25f;
        else 
            movementValue = new Vector3 ( movementValueH, movementValueV, 0.0f ) * 0.25f;

        // Move
        if ( ( movementValue.x != 0 ) || ( movementValue.y != 0 ) )
            currentInputState = Enums.inputState_nm.WALK;

        // Attack
        if ( Input.GetButtonDown ( "Attack" ) )
            currentInputState = Enums.inputState_nm.ATTACK;
    }

    protected void UpdatePosition () {
        if ( !alive )
            return;
        if ( currentInputState == Enums.inputState_nm.WALK )
            Walk ();
    }

    protected void Walk () {
        transform.position += movementValue;
    }

    void OnTriggerEnter2D ( Collider2D col) {
        if ( col.tag == "Life" )
            ;
    }

    void OnTriggerEnter2D ( Collider2D col ) {
        if ( col.tag == "ShieldLife" )
            ;
    }

    void OnTriggerEnter2D ( Collider2D col ) {
        if ( col.tag == "Magnet" )
            ;
    }

    void OnTriggerEnter2D ( Collider2D col ) {
        if ( col.tag == "BigShield" )
            ;
    }

    void OnTriggerEnter2D ( Collider2D col ) {
        if ( col.tag == "LittleShield" )
            ;
    }

    void OnTriggerEnter2D ( Collider2D col ) {
        if ( col.tag == "Clone" )
            ;
    }

    void OnTriggerEnter2D ( Collider2D col ) {
        if ( col.tag == "BulletTime" )
            ;
    }

    void OnTriggerEnter2D ( Collider2D col ) {
        if ( col.tag == "NuclearBurp" )
            ;
    }

    void OnTriggerEnter2D ( Collider2D col ) {
        if ( col.tag == "SuperKnight" )
            ;
    }

    void OnTriggerEnter2D ( Collider2D col ) {
        if ( col.tag == "InvertControl" )
            ;
    }

    void OnTriggerEnter2D ( Collider2D col ) {
        if ( col.tag == "Beer" )
            ;
    }
}
