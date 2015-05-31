using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PickupManager : MonoBehaviour {

    public List<Object> lPickup;
    public List<Transform> lSpawners;

    public void Update () {
        InvokeRepeating ( "SpawnRandomPickup", 10f, 3f );
    }

    //public void SpawnRandomPickup () {
    //    int pickedValue = Random.Range ( 0, lPickup.Count - 1);
    //    int pickedSpawner = Random.Range( 0, lSpawners.Count - 1);
    //    Instantiate ( lPickup[pickedValue], lSpawners[pickedSpawner].position, Quaternion.identity );
    //}



}