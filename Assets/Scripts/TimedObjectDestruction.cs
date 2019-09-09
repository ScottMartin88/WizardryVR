using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedObjectDestruction : MonoBehaviour {
    
    public float time;
    public bool explode = false;
    public GameObject explosionObj;
    public GameObject test;
    // Use this for initialization
    void Start () {
        test = new GameObject();

    }
	
	// Update is called once per frame
	void Update ()
    {
        
        Destroy(test, time);//Destroy the game object after x seconds.
        if (test == null)
        {
            if (explode)
            {
                Instantiate(explosionObj, transform.position, transform.rotation);
            }
            Destroy(this.gameObject);
        }
    }
    public void setTimer(float x)
    {
        time = x;
    }
}
