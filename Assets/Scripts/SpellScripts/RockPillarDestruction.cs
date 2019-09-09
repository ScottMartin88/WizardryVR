using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockPillarDestruction : MonoBehaviour
{
    public List<GameObject> rocks;
    public GameObject collision;
    bool setDestruction = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (collision == null)
        {
            if (setDestruction == false)
            {
                setDestruction = true;
                for (int i = 0;  i < rocks.Count; i++)
                {
                    rocks[i].GetComponent<Rigidbody>().useGravity = true;
                    rocks[i].AddComponent<TimedObjectDestruction>().setTimer(10);
                    rocks[i].GetComponent<SphereCollider>().enabled = true;
                    rocks[i].GetComponent<RockShrink>().enabled = true;

                }
                this.gameObject.AddComponent<TimedObjectDestruction>().setTimer(15);
            }
        }
    }
}
