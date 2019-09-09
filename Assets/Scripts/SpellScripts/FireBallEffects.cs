using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallEffects : MonoBehaviour
{
    public GameObject IceSheet;
    bool colliding = false;
    public void OnCollisionEnter(Collision other)
    {
        colliding = true;
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
            this.GetComponent<TimedObjectDestruction>().time = 0.0f;
        }   
    }
}
