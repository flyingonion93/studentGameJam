using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour {

    public Transform rollCenter, begin, end, war1, war2, currentWar;
    public Transform left1, left2, left3, left4, left5, left6, left7, left8, right1, right2, right3, right4, right5, right6, right7, right8;
    public Transform EnemyHorse, EnemySword, instanceEnemy;

    public void Start () {
        InvokeRepeating ( "AddEnemy", 0f, 5f );
        currentWar = war2;
    }

    public float ObtainDistance () {
        return end.position.y - begin.position.y;
    }

    public void ChangeRolls () {
        print ( rollCenter.parent.ToString () );
        currentWar.position = new Vector3 ( currentWar.position.x, currentWar.position.y + 2 * ObtainDistance () - 5 , currentWar.position.z );
        if ( currentWar == war1 )
            currentWar = war2;
        else
            currentWar = war1;
        //rollCenter.parent.position = new Vector3 ( xValue, yValue + 2 * ObtainDistance (), zValue );
    }

    public void AddEnemy () {
        int valueSoldier = Random.Range ( 0, 1 );
        switch ( valueSoldier ) { 
            case 0:
                instanceEnemy = EnemyHorse;
                break;
            case 1:
                instanceEnemy = EnemySword;
                break;
        }
        int value = Random.Range ( 0, 15 );
        switch ( value ) { 
            case 0:
                Instantiate ( instanceEnemy, left1.position, Quaternion.identity );
                break;
            case 1:
                Instantiate ( instanceEnemy, left2.position, Quaternion.identity );
                break;
            case 2:
                Instantiate ( instanceEnemy, left3.position, Quaternion.identity );
                break;
            case 3:
                Instantiate ( instanceEnemy, left4.position, Quaternion.identity );
                break;
            case 4:
                Instantiate ( instanceEnemy, left5.position, Quaternion.identity );
                break;
            case 5:
                Instantiate ( instanceEnemy, left6.position, Quaternion.identity );
                break;
            case 6:
                Instantiate ( instanceEnemy, left7.position, Quaternion.identity );
                break;
            case 7:
                Instantiate ( instanceEnemy, left8.position, Quaternion.identity );
                break;
            case 8:
                Instantiate ( instanceEnemy, right1.position, Quaternion.identity );
                break;
            case 9:
                Instantiate ( instanceEnemy, right2.position, Quaternion.identity );
                break;
            case 10:
                Instantiate ( instanceEnemy, right3.position, Quaternion.identity );
                break;
            case 11:
                Instantiate ( instanceEnemy, right4.position, Quaternion.identity );
                break;
            case 12:
                Instantiate ( instanceEnemy, right5.position, Quaternion.identity );
                break;
            case 13:
                Instantiate ( instanceEnemy, right6.position, Quaternion.identity );
                break;
            case 14:
                Instantiate ( instanceEnemy, right7.position, Quaternion.identity );
                break;
            case 15:
                Instantiate ( instanceEnemy, right8.position, Quaternion.identity );
                break;
        }
    }

}