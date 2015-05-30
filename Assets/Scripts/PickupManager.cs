using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PickupManager : MonoBehaviour {

    public List<Object> lPickup;

    public void SpawnRandomPickup () {
        int pickedValue = Random.Range ( 1, lPickup.Count );
    }

}