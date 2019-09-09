using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockPillarBall : MonoBehaviour
{
    public GameObject Pillar;
    bool colliding = false;
    bool CreatePillar = false;
    public void OnCollisionEnter(Collision other)
    {
        colliding = true;
        if (other.gameObject.tag == "Ground")
        {
            CreatePillar = true;
        }
        else if (other.gameObject.tag == "GameController")
        {
            colliding = false;
        }
        else
        {
            this.GetComponent<TimedObjectDestruction>().time = 0.0f;
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (colliding)
        {
            if (CreatePillar)
            {
                Instantiate(Pillar, transform.position, new Quaternion(0, 0, 0, 0));
                this.GetComponent<TimedObjectDestruction>().time = 0.0f;
                Destroy(this);
            }
            this.GetComponent<TimedObjectDestruction>().time = 0.0f;
        }   
    }
}
