using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class portal : MonoBehaviour
{

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "PlayerController")
        {
            SceneManager.LoadScene(1);
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
