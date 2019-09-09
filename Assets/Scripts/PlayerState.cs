using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public bool Underwater = false;
    bool setSwimming = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Underwater)
        {
            if (!setSwimming)
            {
                GetComponent<Rigidbody>().useGravity = false;
                RenderSettings.fogDensity = 0.05f;
                RenderSettings.fogColor = new Color(0.22f, 0.65f, 0.77f, 0.5f);
                GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                setSwimming = true;
            }
        }
        else
        {
            if (setSwimming)
            {
                GetComponent<Rigidbody>().useGravity = true;
                RenderSettings.fogDensity = 0;
                setSwimming = false;
            }
        }


       
    }
}
