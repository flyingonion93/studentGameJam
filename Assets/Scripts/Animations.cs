using UnityEngine;
using System.Collections;

public  class Animations : MonoBehaviour {

    protected Animator _animator;
    protected Enums.anim_nm currentAnim;
    protected int characterAnimState = Animator.StringToHash ( "controlAnimState" );
    protected int _animState;
	public bool damaged;
    private Characters _character;

    public virtual void Awake () {
        _animator = GetComponent<Animator> ();
        _animState = characterAnimState;
        _character = GetComponent<Characters> ();
    }

    public void Update () {
        // Move
        if ( _character.currentInputState == Enums.inputState_nm.WALK && currentAnim != Enums.anim_nm.WALK ) {
            currentAnim = Enums.anim_nm.WALK;
            _animator.SetInteger ( _animState, 1);
        }
        // Idle
        if ( _character.currentInputState == Enums.inputState_nm.NONE && currentAnim != Enums.anim_nm.IDLE ) {
            currentAnim = Enums.anim_nm.IDLE;
            _animator.SetInteger ( _animState, 0);
        }
		//Damage
		if (damaged && currentAnim != Enums.anim_nm.HIT) {
			currentAnim = Enums.anim_nm.HIT;
			_animator.SetInteger(_animState, 2);
			damaged = false;
		}
    }
}
