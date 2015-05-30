using UnityEngine;
using System.Collections;

public abstract class Characters : MonoBehaviour {

    [HideInInspector] public Enums.inputState_nm currentInputState;
    [HideInInspector] public bool alive, canAttack;
    [HideInInspector] public Vector2 spawnPos;
    public float walkVel;


    public virtual void Awake () {
        _transform = transform;
        alive = true;
        canAttack = true;
    }

    public abstract void DetectInput ();

    public abstract void UpdatePosition ();

    #region Protected Attributes
    protected Transform _transform;
    protected Vector3 movementValue = new Vector2 ();
    #endregion

    protected void Walk () {
        _transform.position += movementValue;
    }

    protected abstract IEnumerator Attack ();
}