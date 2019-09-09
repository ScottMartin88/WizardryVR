using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
public class InputRight : MonoBehaviour
{

    /////////////////////////////////////////////////////
    //Left controller inputs, controls Jump mechanics  //
    /////////////////////////////////////////////////////
    public GameObject hand;
    public GameObject m1, m2, m3, m4, m5, m6, m7, m8;
    public SteamVR_Action_Boolean grip, a, b, trigger;
    public SteamVR_Action_Vector2 joystick;
    public SteamVR_Input_Sources inputSource = SteamVR_Input_Sources.Any;
    float jumpBoost = 1, jumpBoostCounter = 0; 
    float jumpBoostCount = 10;
    [Range(1.0f,20.0f)]
    public float turnSpeed = 10;
    bool used = false;
    float groundDistance;
    bool grounded = false;


    ///////////////////////////////////////////////
    //       Ground detection for jumping        //
    ///////////////////////////////////////////////
    private void Start()
    {
        groundDistance = GetComponent<Collider>().bounds.extents.y;
    }

    private void FixedUpdate()
    {
        if (!Physics.Raycast(transform.position, -Vector3.up, groundDistance + 0.2f))
        {
            grounded = false;
        }
        else
        {
            grounded = true;
        }
        

    }

    ///////////////////////////////////////////////
    //  Get the inputs for the right controller   //
    ///////////////////////////////////////////////
    void Update()
    {
        if (grip.GetStateDown(inputSource))
        {
            this.GetComponent<MagicController>().GripPressed(m1, m2, m3, m4, m5, m6, m7, m8, 'R');
        }
        if (grip.GetStateUp(inputSource))
        {
            this.GetComponent<MagicController>().GripReleased('R');
        }
        if (trigger.GetStateDown(inputSource))
        {
            hand.GetComponent<HandMagicState>().CastSpell();
        }
        if (trigger.GetStateUp(inputSource))
        {
            hand.GetComponent<HandMagicState>().ReleaseSpell();
        }
        if (a.GetStateDown(inputSource))
        {            
            if (grounded)
            {
                this.GetComponent<Rigidbody>().velocity += new Vector3(0, 5*jumpBoost, 0);
                grounded = false;
            }
        }
        if (joystick[inputSource].axis.x > 0.3f)
        {
            if (!used)
            {
                transform.Rotate(0, turnSpeed, 0);
                used = true;
            }
        }
        else if (joystick[inputSource].axis.x < -0.3f)
        {
            if (!used)
            {
                transform.Rotate(0, -turnSpeed, 0);
                used = true;
            }
        }
        else
        {
            used = false;
        }

        if (jumpBoostCounter > 0) jumpBoostCounter-=1 * Time.deltaTime;
        if (jumpBoostCounter < 1) { jumpBoost = 1; }
    }
    /////////////////////////////////////////////////
    //  Adds a jump boost when the spell is cast   //
    /////////////////////////////////////////////////
    public void JumpBoost()
    {
        jumpBoost = 2;
        jumpBoostCounter = jumpBoostCount;
    }
}
