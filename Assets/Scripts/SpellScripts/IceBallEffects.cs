using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBallEffects : MonoBehaviour
{
    public GameObject IceSheet;
    bool colliding = false;
    bool iceSheetBool = false;
    public void OnCollisionEnter(Collision other)
    {
        colliding = true;
        if (other.gameObject.name == "Water")
        {
            iceSheetBool = true;
        }
        if (other.gameObject.tag == "GameController")
        {
            colliding = false;
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (colliding)
        {
            if (iceSheetBool)
            {
                Instantiate(IceSheet, transform.position, new Quaternion(0, 0, 0, 0));
                this.GetComponent<TimedObjectDestruction>().time = 0.0f;
                Destroy(this);
            }
            this.GetComponent<TimedObjectDestruction>().time = 0.0f;
        }   
    }
}
