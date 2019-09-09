using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreCollision(this.GetComponent<MeshCollider>(), GameObject.Find("PlayerController").GetComponent<CapsuleCollider>());
    }

    // Update is called once per frame
    void Update()
    {
            
    }
}
