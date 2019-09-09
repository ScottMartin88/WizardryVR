using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunScript : MonoBehaviour
{
    bool setcolour = false;
    public bool issun;
    public bool issunwater;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("PlayerController").GetComponent<PlayerState>().Underwater == true)
        {
            if (!setcolour)
            {     
                if (issunwater)
                {
                    GetComponent<Light>().enabled = true;
                }
                if (issun)
                {
                    GetComponent<Light>().enabled = false;
                }
                setcolour = true;
            }
        }
        else
        {
            if (setcolour)
            {
                if (issunwater)
                {
                    GetComponent<Light>().enabled = false;
                }
                if (issun)
                {
                    GetComponent<Light>().enabled = true;
                }
                setcolour = false;
            }
        }
    }
}
