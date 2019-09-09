using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockPillarRaise : MonoBehaviour
{
    public float height = 0;
    public float heightLimit = 1;
    float initY;
    // Start is called before the first frame update
    void Start()
    {
        initY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (height < heightLimit)
        {
            transform.position = new Vector3(transform.position.x, initY+  (height*5), transform.position.z);
            height += 1 * Time.deltaTime;
        }
    }
}
