using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterLightingScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("PlayerController").GetComponent<PlayerState>().Underwater == true)
        {
            GetComponent<Renderer>().enabled = true;
        }
        else GetComponent<Renderer>().enabled = false;
    }
}
