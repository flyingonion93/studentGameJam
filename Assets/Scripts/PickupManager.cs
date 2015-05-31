using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PickupManager : MonoBehaviour {

    public Transform lifeUp, heavyShield, shotgun, smallShield, shieldUp;
    public Transform spawner1, spawner2, spawner3, spawner4, currentSpawner;

    public void Start () {
        InvokeRepeating ( "AddPickup", 10f, 10f );
    }

    public void AddPickup () {
        int spawnerSelected = Random.Range ( 0, 3 );
        switch ( spawnerSelected ) { 
            case 0:
                currentSpawner = spawner1;
                break;
            case 1:
                currentSpawner = spawner2;
                break;
            case 2:
                currentSpawner = spawner3;
                break;
            case 3:
                currentSpawner = spawner4;
                break;
        }
        int pickupSelected = Random.Range ( 0, 4 );
        switch( pickupSelected ) {
            case 0:
                Instantiate( lifeUp, currentSpawner.position, Quaternion.identity );
                break;
            case 1:
                Instantiate( heavyShield, currentSpawner.position, Quaternion.identity );
                break;
            case 2:
                Instantiate( shotgun, currentSpawner.position, Quaternion.identity );
                break;
            case 3:
                Instantiate( smallShield, currentSpawner.position, Quaternion.identity );
                break;
            case 4:
                Instantiate( shieldUp, currentSpawner.position, Quaternion.identity );
                break;
        }
    }

    //public void SpawnRandomPickup () {
    //    int pickedValue = Random.Range ( 0, lPickup.Count - 1);
    //    int pickedSpawner = Random.Range( 0, lSpawners.Count - 1);
    //    Instantiate ( lPickup[pickedValue], lSpawners[pickedSpawner].position, Quaternion.identity );
    //}



}