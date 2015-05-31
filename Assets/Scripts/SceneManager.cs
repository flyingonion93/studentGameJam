using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour {

    public Transform rollCenter, begin, end;

    public float ObtainDistance () {
        return end.position.y - begin.position.y;
    }

    public void ChangeRolls () {

        float xValue = rollCenter.parent.position.x;
        float yValue = rollCenter.parent.position.y;
        float zValue = rollCenter.parent.position.z;
        rollCenter.parent.position = new Vector3 ( xValue, yValue + 2 * ObtainDistance (), zValue );
    }

}
