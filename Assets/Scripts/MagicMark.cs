using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicMark : MonoBehaviour
{
    ///////////////////////////////////////////////////////////////////////
    //   This is the code for the magic marks used for spell selection   //
    //this just uses basic collision code to tell which has been selected//
    //the number and hand id of each specific mark instantiated, is set  //
    //                  in the magic controller code.                    //
    ///////////////////////////////////////////////////////////////////////

    GameObject player,lHand,rHand;
    public GameObject selected;
    bool selectedMark = false;
    public char number = '0';
    public char handId = '0';
    private void Start()
    {
        player = GameObject.Find("PlayerController");
        lHand = GameObject.Find("Controller (left)");
        rHand = GameObject.Find("Controller (right)");
    }
    private void Update()
    {
        if ((Math.Distance(lHand.transform.position, transform.position) < 0.05f) && selectedMark == false)
        {
            if (handId == 'L')
            {
                Instantiate(selected, transform.position, transform.rotation, transform);
                player.GetComponent<MagicController>().magicOrderL.Add(number);
                selectedMark = true;
            }
        }
        if ((Math.Distance(rHand.transform.position, transform.position) < 0.05f) && selectedMark == false)
        {
            if (handId == 'R')
            {
                Instantiate(selected, transform.position, transform.rotation, transform);
                player.GetComponent<MagicController>().magicOrderR.Add(number);
                selectedMark = true;
            }
        }
    }
}
