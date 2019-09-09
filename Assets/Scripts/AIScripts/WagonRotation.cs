using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WagonRotation : MonoBehaviour
{
    public float speedMultiplier = 1;
    public GameObject horseToFllow;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "PlayerController")
        {
            GameObject.Find("PlayerController").transform.parent = transform;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "PlayerController")
        {
            GameObject.Find("PlayerController").transform.parent = null;
            GameObject.Find("PlayerController").transform.rotation = new Quaternion(0, GameObject.Find("PlayerController").transform.rotation.y, 0, GameObject.Find("PlayerController").transform.rotation.w);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "PlayerController")
        {
            GameObject.Find("PlayerController").transform.rotation = new Quaternion(0, GameObject.Find("PlayerController").transform.rotation.y, 0, GameObject.Find("PlayerController").transform.rotation.w);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = horseToFllow.transform.position - transform.position;
        dir.y = 0; // keep the direction strictly horizontal
        Quaternion rot = Quaternion.LookRotation(dir);
        // slerp to the desired rotation over time
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, speedMultiplier * Time.deltaTime);



    }
}
