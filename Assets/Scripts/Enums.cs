using UnityEngine;
using System.Collections;

public class Enums : MonoBehaviour {

    public enum inputState_nm { 
        NONE,
        THROW,
        ATTACK,
        WALK,
        DEAD
    }

    public enum anim_nm { 
        IDLE,
        WALK,
        ATTACK,
        THROW,
        HIT,
        PUKE
    }

    public enum enemy_type { 
        BOWMAN,
        SWORDMAN,
        HORSEMAN,
        KING
    }
}
