using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class underwaterScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Camera")
        {
            GameObject.Find("PlayerController").GetComponent<PlayerState>().Underwater = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Camera")
        {
            GameObject.Find("PlayerController").GetComponent<PlayerState>().Underwater = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
