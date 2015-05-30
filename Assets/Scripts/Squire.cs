using UnityEngine;
using System.Collections;

public class Squire : Characters {

    public Transform smallShield, primaryShield, heavyShield;
    protected bool inverted;

    public void Start () {        
        smallShield.gameObject.SetActive ( false );
        heavyShield.gameObject.SetActive ( false );
        primaryShield.gameObject.SetActive ( true );
        inverted = false;
    }

    public void Update () {
        if ( GameManager.Instance.LifeManager.life > 0 ) {
            currentInputState = Enums.inputState_nm.NONE;
            DetectInput ();
            UpdatePosition ();
        } else
            currentInputState = Enums.inputState_nm.DEAD;
    }

    public override void DetectInput () {
        float movementValueH = Input.GetAxis ( "Horizontal" );
        float movementValueV = Input.GetAxis ( "Vertical" );
        if ( inverted )
            movementValue = new Vector3 ( -movementValueH, -movementValueV, 0.0f ) * 0.25f;
        else
            movementValue = new Vector3 ( movementValueH, movementValueV, 0.0f ) * 0.25f;

        // Move
        if ( ( movementValue.x != 0 ) || ( movementValue.y != 0 ) )
            currentInputState = Enums.inputState_nm.WALK;

        // Rotate
        float x = Input.GetAxis("HorizontalS");
        float y = Input.GetAxis("VerticalS");
        if (x != 0.0 || y != 0.0) {
            float angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(90.0f - angle, Vector3.forward);
    }

        // Attack
        if ( Input.GetButtonDown ( "Attack" ) )
            currentInputState = Enums.inputState_nm.ATTACK;
    }

    public override void UpdatePosition () {
        if ( !alive )
            return;
        if ( currentInputState == Enums.inputState_nm.WALK )
            Walk ();
    }

    // TO DO
    protected override IEnumerator Attack () {
        yield return null;
    }

    void OnTriggerEnter2D ( Collider2D col ) {
        switch ( col.tag ) {
            case "Life":
                GameManager.Instance.LifeManager.UpLife ();
                break;
            case "ShieldLife":
                GameManager.Instance.ShieldManager.UpShield ();
                break;
            case "Magnet":
                GameManager.Instance.ShieldManager.MagnetShield ();
                break;
            case "BigShield":
                print ( "pene" );
                GameManager.Instance.ShieldManager.BigShieldInstance ();
                break;
            case "LittleShield":
                GameManager.Instance.ShieldManager.LittleShieldInstance ();
                break;
            case "Clone":
                GameManager.Instance.Knight.ninjas.gameObject.SetActive ( true );
                break;
            case "BulletTime":
                break;
            case "NuclearBurp":
                break;
            case "SuperKnight":
                break;
            case "InvertControl":
                break;
            case "Beer":
                break;
        }
    }
}