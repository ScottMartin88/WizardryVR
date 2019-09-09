using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirBurst : MonoBehaviour
{
    float count;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name != "PlayerController")
        other.GetComponent<Rigidbody>().AddForce((other.transform.position - transform.position)*1000);
    }

    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        count += 1000 * Time.deltaTime;
        //GetComponent<SphereCollider>().radius = count/10;
        transform.localScale = Math.MultiplyVector(new Vector3(1,1,1), count);
        ///if (count > 10) Destroy(this.gameObject);
    }
}
