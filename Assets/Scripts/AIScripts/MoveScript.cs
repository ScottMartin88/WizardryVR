using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    public bool moving = false;
    public float speed = 0.01f;
    public float closeBias = 0.1f;
    public Transform positionToMove = null;
    public List<GameObject> PatrolPoints;
    public int i;
    // Update is called once per frame
    void Update()
    {
        if (positionToMove != null)
        {
            moving = true;
            positionToMove.position = new Vector3(positionToMove.position.x, transform.position.y, positionToMove.position.z);
        }
        else moving = false;


        if (moving)
        {
            transform.LookAt(positionToMove);
            if (Math.Distance(this.transform.position, positionToMove.position) < closeBias)
            {
                moving = false;
                StopMovement();
            }
            else
            {
                transform.position -= Math.NormVector(transform.position - positionToMove.position) * speed;
            }
        }
    }
    private void FixedUpdate()
    {
        if (positionToMove == null)
        {
            i = Random.Range(0, 10);
            if (i == 9)
            {
                Debug.Log("HMM?");
                int x = Random.Range(0, 3);
                positionToMove = PatrolPoints[x].transform;
            }
        }
    }

    public void SetDestination(Transform Destination)
    {
        positionToMove = Destination;
    }


    public void StopMovement()
    {
        positionToMove = null;
    }
}
