using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
public class InputLeft : MonoBehaviour
{

    ///////////////////////////////////////////////
    //Left controller inputs, controls movement  //
    ///////////////////////////////////////////////
    public GameObject hand;
    public GameObject m1, m2, m3, m4, m5, m6, m7, m8;
    public SteamVR_Action_Boolean grip,a,b,trigger;
    public SteamVR_Action_Vector2 joystick;
    public SteamVR_Input_Sources inputSource = SteamVR_Input_Sources.Any;
    [Space]
    public GameObject _camera;
    [Space]
    public float speedMultiplier = 5;    
    float BoostCount = 10, BoostCounter = 0;

    void Update()
    {
        ///////////////////////////////////////////////
        //  Get the inputs for the left controller   //
        ///////////////////////////////////////////////
        if (grip.GetStateDown(inputSource))
        {
            this.GetComponent<MagicController>().GripPressed(m1,m2,m3,m4,m5,m6,m7,m8,'L');
        }
        if (grip.GetStateUp(inputSource))
        {
            this.GetComponent<MagicController>().GripReleased('L');
        }
        if (trigger.GetStateDown(inputSource))
        {
            hand.GetComponent<HandMagicState>().CastSpell();
        }
        if (trigger.GetStateUp(inputSource))
        {
            hand.GetComponent<HandMagicState>().ReleaseSpell();
        }
        if (joystick[inputSource].axis.y > 0.1f)
        {
            transform.position += ((_camera.transform.forward* joystick[inputSource].axis.y)*speedMultiplier)*Time.deltaTime;
        }
        else if (joystick[inputSource].axis.y < -0.1f)
        {
            transform.position -= ((_camera.transform.forward * -joystick[inputSource].axis.y)* speedMultiplier) * Time.deltaTime;
        }

        if (BoostCounter > 0) BoostCounter -= 1 * Time.deltaTime;
        if (BoostCounter < 1) { speedMultiplier = 5; }
    }

    ///////////////////////////////////////////////
    //Adds a speed boost when haste has been cast//
    ///////////////////////////////////////////////
    public void haste()
    {
        speedMultiplier = 15;
        BoostCounter = BoostCount;
    }
}
