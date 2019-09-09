using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    float rotation = 0;
    [Range(0, 100)]
    public float multiplier = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rotation >= 360) rotation = 0;

        rotation += (1 * Time.deltaTime)*multiplier;

       
        //transform.rotation = new Quaternion(0, 0, rotation, 0); 
    }
    private void FixedUpdate()
    {
        transform.Rotate((Vector3.forward * rotation) * Time.deltaTime, Space.World);
    }
}
