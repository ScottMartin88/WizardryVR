using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicController : MonoBehaviour
{
    public GameObject Marker;
    public GameObject leftHand, rightHand;
    GameObject m1, m2, m3, m4, m5, m6, m7, m8;
    GameObject marker1, marker2, marker3, marker4, marker5, marker6, marker7, marker8, marker9, marker10, marker11, marker12, marker13, marker14, marker15, marker16;
    public List<char> magicOrderL, magicOrderR;
    public bool marksInstantiatedL, marksInstantiatedR;
    public string magicCodeL, magicCodeR;

    public void GripPressed(GameObject x1, GameObject x2, GameObject x3, GameObject x4, GameObject x5, GameObject x6, GameObject x7, GameObject x8, char G)
    {
        ///////////////////////////////////////////////////////
        //Sets the marks that appear when the grip is pressed//
        //          'G' Just represents which hand           //
        ///////////////////////////////////////////////////////

        m1 = x1;
        m2 = x2;
        m3 = x3;
        m4 = x4;
        m5 = x5;
        m6 = x6;
        m7 = x7;
        m8 = x8;

        if (G == 'L')
        {
            if (!marksInstantiatedL)
            {
                //instantiate the marks
                InstantiateMarksL();
                marksInstantiatedL = true;
            }
        }
        else if (G == 'R')
        {
            if (!marksInstantiatedR)
            {
                //instantiate the marks
                InstantiateMarksR();
                marksInstantiatedR = true;
            }
        }
    }
    public void GripReleased(char G)
    {
        //////////////////////////////
        //Destroys the created marks//
        // 'G' Represends the hand  //
        //      Also sends code     //
        //    to designate which    //
        //  spell has been selected //
        //////////////////////////////
        if (G == 'L')
        {
            Destroy(marker1);
            Destroy(marker2);
            Destroy(marker3);
            Destroy(marker4);
            Destroy(marker5);
            Destroy(marker6);
            Destroy(marker7);
            Destroy(marker8);
            marksInstantiatedL = false;
            MagicSelection('L');
        }
        if (G == 'R')
        {
            Destroy(marker9);
            Destroy(marker10);
            Destroy(marker11);
            Destroy(marker12);
            Destroy(marker13);
            Destroy(marker14);
            Destroy(marker15);
            Destroy(marker16);
            marksInstantiatedR = false;
            MagicSelection('R');
        }

        
    }
    void MagicSelection(char H)
    {
        ///////////////////////////////////////////////////
        // here the code is set from the list to a string//
        // So it is able to be read in the hand specific //
        // State code, this then tells the code so select//
        //                    the spell                  //
        ///////////////////////////////////////////////////
        if (H == 'L')
        {
            for (int i = 0; i < magicOrderL.Count; i++)
            {
                magicCodeL += magicOrderL[i];
            }
            //Use Magic code to Create Spell
            leftHand.GetComponent<HandMagicState>().setSpell(magicCodeL);
            //Clear Lists and code
            magicCodeL = "";
            magicOrderL.Clear();

        }

        if (H == 'R')
        {
            for (int i = 0; i < magicOrderR.Count; i++)
            {
                magicCodeR += magicOrderR[i];
            }
            //Use Magic code to Create Spell

            rightHand.GetComponent<HandMagicState>().setSpell(magicCodeR);
            //Clear Lists and code
            magicCodeR = "";
            magicOrderR.Clear();
        }
    }

    ////////////////////////////////////////////////////////////
    //This instantiates the marks. from which hand needs them //
    // as well as setting their number, which is used as the  //
    //          magic code for spell selection                //
    ////////////////////////////////////////////////////////////
    void InstantiateMarksL()
    {
        marker1 = Instantiate(Marker, m1.transform.position, m1.transform.rotation);
        marker1.GetComponent<MagicMark>().number = '1';
        marker1.GetComponent<MagicMark>().handId = 'L';
        marker2 = Instantiate(Marker, m2.transform.position, m2.transform.rotation);
        marker2.GetComponent<MagicMark>().number = '2';
        marker2.GetComponent<MagicMark>().handId = 'L';
        marker3 = Instantiate(Marker, m3.transform.position, m3.transform.rotation);
        marker3.GetComponent<MagicMark>().number = '3';
        marker3.GetComponent<MagicMark>().handId = 'L';
        marker4 = Instantiate(Marker, m4.transform.position, m4.transform.rotation);
        marker4.GetComponent<MagicMark>().number = '4';
        marker4.GetComponent<MagicMark>().handId = 'L';
        marker5 = Instantiate(Marker, m5.transform.position, m5.transform.rotation);
        marker5.GetComponent<MagicMark>().number = '5';
        marker5.GetComponent<MagicMark>().handId = 'L';
        marker6 = Instantiate(Marker, m6.transform.position, m6.transform.rotation);
        marker6.GetComponent<MagicMark>().number = '6';
        marker6.GetComponent<MagicMark>().handId = 'L';
        marker7 = Instantiate(Marker, m7.transform.position, m7.transform.rotation);
        marker7.GetComponent<MagicMark>().number = '7';
        marker7.GetComponent<MagicMark>().handId = 'L';
        marker8 = Instantiate(Marker, m8.transform.position, m8.transform.rotation);
        marker8.GetComponent<MagicMark>().number = '8';
        marker8.GetComponent<MagicMark>().handId = 'L';
    }

    void InstantiateMarksR()
    {
        marker9 = Instantiate(Marker, m1.transform.position, m1.transform.rotation);
        marker9.GetComponent<MagicMark>().number = '1';
        marker9.GetComponent<MagicMark>().handId = 'R';
        marker10 = Instantiate(Marker, m2.transform.position, m2.transform.rotation);
        marker10.GetComponent<MagicMark>().number = '2';
        marker10.GetComponent<MagicMark>().handId = 'R';
        marker11 = Instantiate(Marker, m3.transform.position, m3.transform.rotation);
        marker11.GetComponent<MagicMark>().number = '3';
        marker11.GetComponent<MagicMark>().handId = 'R';
        marker12 = Instantiate(Marker, m4.transform.position, m4.transform.rotation);
        marker12.GetComponent<MagicMark>().number = '4';
        marker12.GetComponent<MagicMark>().handId = 'R';
        marker13 = Instantiate(Marker, m5.transform.position, m5.transform.rotation);
        marker13.GetComponent<MagicMark>().number = '5';
        marker13.GetComponent<MagicMark>().handId = 'R';
        marker14 = Instantiate(Marker, m6.transform.position, m6.transform.rotation);
        marker14.GetComponent<MagicMark>().number = '6';
        marker14.GetComponent<MagicMark>().handId = 'R';
        marker15 = Instantiate(Marker, m7.transform.position, m7.transform.rotation);
        marker15.GetComponent<MagicMark>().number = '7';
        marker15.GetComponent<MagicMark>().handId = 'R';
        marker16 = Instantiate(Marker, m8.transform.position, m8.transform.rotation);
        marker16.GetComponent<MagicMark>().number = '8';
        marker16.GetComponent<MagicMark>().handId = 'R';
    }
}
