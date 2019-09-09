using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WagonWheelRotation : MonoBehaviour
{
    [Range(-100, 100)]
    public float rotation = 0;
    [Range(0, 100)]
    public float multiplier = 1;
    public bool moving = false;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        moving = transform.parent.parent.GetComponent<HorseWaypointFollow>().moving;
    }
    private void FixedUpdate()
    {
        if (moving == true)
        {
            transform.Rotate((Vector3.up * rotation) * Time.deltaTime, Space.Self);
        }
    }
}
