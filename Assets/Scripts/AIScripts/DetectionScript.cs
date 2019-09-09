using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionScript : MonoBehaviour
{
    [Header("Distances")]
    [Range(0,100)]
    public float DetectionRange = 4;
    [Range(0, 100)]
    public float AttackRange = 2;
    GameObject player;
    public bool chasing = false;
    public bool attacking = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerController");
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        if(Math.Distance(player.transform.position, transform.position) <= AttackRange)
        {
            chasing = false;
            attacking = true;
            GetComponent<MoveScript>().StopMovement();
        }
        else if (Math.Distance(player.transform.position,transform.position) <= DetectionRange)
        {
            chasing = true;
        }
        else
        {
            chasing = false;
        }
        if (chasing)
        {
            GetComponent<MoveScript>().SetDestination(player.transform);
        }
        if (Math.Distance(player.transform.position, transform.position) > DetectionRange && chasing)
        {
            GetComponent<MoveScript>().StopMovement();
        }
    }

    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, DetectionRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, AttackRange);
    }
}
