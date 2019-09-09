using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySwordScript : MonoBehaviour
{
    [Range(1,20)]
    public float damage = 1;
    public bool attacking = false;
    public bool hasHit = false;
    bool colliding = false;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "PlayerController")
        {
            colliding = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "PlayerController")
        {
            colliding = false;
        }
    }

    void Update()
    {

        if (!attacking)
        {
            if (hasHit)
            {
                hasHit = false;
            }
        }
        else if (attacking)
        {
            if (colliding == true)
            {
                if (!hasHit)
                {
                    //do damage to player
                    hasHit = true;
                    Debug.Log("PLAYER HIT");
                    GameObject.Find("PlayerController").GetComponent<Rigidbody>().AddForce(Math.NormVector(GameObject.Find("PlayerController").transform.position - this.transform.position) * 500); 
                }
            }
        }

    }

}
