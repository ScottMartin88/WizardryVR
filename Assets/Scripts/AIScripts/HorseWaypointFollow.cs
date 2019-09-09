using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseWaypointFollow : MonoBehaviour
{
    public GameObject follow, forward;
    public enum Mode { single, Loop, PingPong }
    bool pingpong = false;
    public Mode TravelMode;
    public bool moving = false;
    public List<GameObject> wayPoints;
    public int waypointno = 0;
    public int waypointTotal;
    public float speedMultiplier = 1;
    public float waypointDetector = 10;



    // Update is called once per frame
    void Update()
    {
        
        waypointTotal = wayPoints.Count;

        if (waypointTotal > 0) moving = true;
        else moving = false;



        if (moving)
        {
            float y = transform.position.y;
            float y2 = follow.transform.position.y;
            if (Math.Distance(follow.transform.position, transform.position) < 3 )
            {
                follow.transform.position += (Math.NormVector(wayPoints[waypointno].transform.position - transform.position) * 1.5f * speedMultiplier) * Time.deltaTime;
                follow.transform.position = new Vector3(follow.transform.position.x, y, follow.transform.position.z);
            }
            else if (Math.Distance(follow.transform.position, transform.position) >= 3)
            {
                follow.transform.position -= (Math.NormVector(follow.transform.position - transform.position)*5) * speedMultiplier * Time.deltaTime;
                follow.transform.position = new Vector3(follow.transform.position.x, y, follow.transform.position.z);
            }
            /*if (Math.Distance(follow.transform.position, transform.position) < 2)
            {
                follow.transform.position += (follow.transform.position - transform.position) * speedMultiplier * Time.deltaTime;
                follow.transform.position = new Vector3(follow.transform.position.x, y2, follow.transform.position.z);
            }*/

            transform.position += (Math.NormVector(forward.transform.position - transform.position) * speedMultiplier) * Time.deltaTime;
            transform.position = new Vector3(transform.position.x, y,transform.position.z);
        }

        if (Math.Distance(transform.position, wayPoints[waypointno].transform.position) < waypointDetector)
        {
            if (!pingpong)
            {
                waypointno += 1;
            }
            else
            {
                waypointno -= 1;
            }
        }


        if (waypointno == waypointTotal)
        {
            if (TravelMode == Mode.single)
            {

            }
            else if (TravelMode == Mode.Loop)
            {
                waypointno = 0;
            }
            else if (TravelMode == Mode.PingPong)
            {
                pingpong = !pingpong;
                waypointno -= 1;
            }            
        }
        if (waypointno < 0)
        {
            if (TravelMode == Mode.PingPong)
            {
                pingpong = !pingpong;
                waypointno = 1;
            }
        }


        Vector3 dir = follow.transform.position - transform.position;
        dir.y = 0; // keep the direction strictly horizontal
        Quaternion rot = Quaternion.LookRotation(dir);
        // slerp to the desired rotation over time
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, (speedMultiplier/5) * Time.deltaTime);


    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, waypointDetector);
    }

}
