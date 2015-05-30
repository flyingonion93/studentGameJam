using UnityEngine;
using System.Collections;


public class Knight : MonoBehaviour {

    public Transform LeftSide, RigthSide, currentNavPoint;

    public float moveSpeed;
    public Transform ninjas;
    public float temps = 5f;

    public void Start () {
        ninjas.gameObject.SetActive ( false );
    }

    public void Update () {
        if ( GameManager.Instance.LifeManager.life <= 0 ) {
            GameManager.Instance.Squire.currentInputState = Enums.inputState_nm.DEAD;
        }
        transform.position = Vector3.MoveTowards ( transform.position, currentNavPoint.position, moveSpeed * Time.deltaTime );
        if ( transform.position == currentNavPoint.position )
            currentNavPoint.position = GenerateRandomVector ();
    }

    public IEnumerator ItsNinjaTime () {
        
        ninjas.gameObject.SetActive ( true );
        yield return new WaitForSeconds ( temps );
        ninjas.gameObject.SetActive ( false );
    }

    protected Vector3 GenerateRandomVector () {
        float randX = Random.Range ( LeftSide.position.x, RigthSide.position.x );
        float randY = Random.Range ( transform.position.y - 4, transform.position.y + 8 );
        Vector3 posVec = new Vector3 ( randX, randY, transform.position.z );
        return posVec;
    }
}