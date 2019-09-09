using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockShrink : MonoBehaviour
{
    public float shrinkRate = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale -= new Vector3(shrinkRate * Time.deltaTime, shrinkRate * Time.deltaTime, shrinkRate * Time.deltaTime);
    }
}
