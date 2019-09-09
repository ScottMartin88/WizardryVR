using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

//Code to set the state of each hand, allows for spell selection and casting as well as
//grabbing mechanics when no spell has been selected.

public class HandMagicState : MonoBehaviour
{
    [Header("Magic Effects")]
    public GameObject fireFX;
    public GameObject iceFX, earthFX, windFX, lightFX, psiFX;
    GameObject currentFX;
    GameObject currentToggle;
    string currentspell = "";
    string handEffect = "";
    bool toggled = false;
    bool spellset = false;
    public bool grabbing = false;

    FixedJoint FJ = null;
    SteamVR_Behaviour_Pose m_Pose = null;
    public GrabObj CurrentGrabbedObj = null;
    public List<GrabObj> contactGrabObj = new List<GrabObj>();
    float count = 0;


    // Start is called before the first frame update
    void Start()
    {
        FJ = GetComponent<FixedJoint>();
        m_Pose = GetComponent<SteamVR_Behaviour_Pose>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Sets the spell effect. this allowsfor the player to know what type spell is selected
        //as well as there being a spell selected.
        if(currentspell == "")
        {
            if (currentFX != null)
            {
                clearSpellsFX();
            }
        }
        if(handEffect == "Fire")
        {
            if (!spellset)
            {
                clearSpellsFX();
                currentFX = Instantiate(fireFX, transform.position, transform.rotation, transform);
                spellset = true;
            }
        }
        if (handEffect == "Ice")
        {
            if (!spellset)
            {
                clearSpellsFX();
                currentFX = Instantiate(iceFX, transform.position, transform.rotation, transform);
                spellset = true;
            }
        }
        if (handEffect == "Earth")
        {
            if (!spellset)
            {
                clearSpellsFX();
                currentFX = Instantiate(earthFX, transform.position, transform.rotation, transform);
                spellset = true;
            }
        }
        if (handEffect == "Wind")
        {
            if (!spellset)
            {
                clearSpellsFX();
                currentFX = Instantiate(lightFX, transform.position, transform.rotation, transform);
                spellset = true;
            }
        }

        //Here are togglable spells, when i want the spell to keep casting when toggled on or off.

        if (currentspell == "FireThrower")
        {
            if (toggled)
            {
                if (count <= 0)
                {
                    GameObject FireThrower = Instantiate(GameObject.Find("PlayerController").GetComponent<SpellPrefabHolder>().FireThrower, transform.position, transform.rotation);
                    currentToggle = FireThrower;
                    count = 0.1f;
                }
            }
        }
        if (currentspell == "SnowStorm")
        {
            if (toggled)
            {
                if (count <= 0)
                {
                    GameObject SnowStorm = Instantiate(GameObject.Find("PlayerController").GetComponent<SpellPrefabHolder>().SnowStorm, transform.position, transform.rotation);
                    currentToggle = SnowStorm;
                    count = 0.1f;
                }
            }
        }
    }



    private void Update()
    {
        if (count > 0) count -= 1 * Time.deltaTime;
    }



    public void CastSpell()
    {
        //casts the spell that is set to be cast
        if (currentspell == "")
        {
            if (!toggled)
            {
                toggled = true;
                grabbing = true;
                Pickup();
            }
        }

        //Fire Based spells
        else if (currentspell == "FireThrower")
        {
            if (!toggled)
            {                
                toggled = true;
            }
        }
        else if (currentspell == "FireBolt")
        {
            GameObject FireBolt = Instantiate(GameObject.Find("PlayerController").GetComponent<SpellPrefabHolder>().FireBolt, transform.position, transform.rotation);

            FireBolt.GetComponent<Rigidbody>().AddRelativeForce(0, -8000, 8000);
        }
        else if (currentspell == "FireBall")
        {
            GameObject FireBall = Instantiate(GameObject.Find("PlayerController").GetComponent<SpellPrefabHolder>().FireBall, transform.position, transform.rotation);

            FireBall.GetComponent<Rigidbody>().AddRelativeForce(0, -8000, 8000);
        }
        else if (currentspell == "FireSword")
        {
            if (!toggled)
            {
                GameObject FireSword = Instantiate(GameObject.Find("PlayerController").GetComponent<SpellPrefabHolder>().FireSword, transform.position, transform.rotation);
                currentToggle = FireSword;
                toggled = true;
                grabbing = true;

                CurrentGrabbedObj = FireSword.GetComponent<GrabObj>();

                if (CurrentGrabbedObj.activeHand)
                    CurrentGrabbedObj.activeHand.Drop();

                CurrentGrabbedObj.transform.position = transform.position;

                Rigidbody targetbody = CurrentGrabbedObj.GetComponent<Rigidbody>();

                FJ.connectedBody = targetbody;

                CurrentGrabbedObj.activeHand = this;
            }
        }



        //Ice Based spells
        else if (currentspell == "SnowStorm")
        {
            if (!toggled)
            {

                toggled = true;
            }
        }
        else if (currentspell == "IceBolt")
        {
            GameObject IceBolt = Instantiate(GameObject.Find("PlayerController").GetComponent<SpellPrefabHolder>().IceBolt, transform.position, transform.rotation);

            IceBolt.GetComponent<Rigidbody>().AddRelativeForce(0, -8000, 8000);            
        }
        else if (currentspell == "IceBall")
        {
            GameObject Iceball = Instantiate(GameObject.Find("PlayerController").GetComponent<SpellPrefabHolder>().IceBall, transform.position, transform.rotation);

            Iceball.GetComponent<Rigidbody>().AddRelativeForce(0, -8000, 8000);
        }
        else if (currentspell == "IceSword")
        {
            if (!toggled)
            {
                GameObject IceSword = Instantiate(GameObject.Find("PlayerController").GetComponent<SpellPrefabHolder>().IceSword, transform.position, transform.rotation);
                currentToggle = IceSword;
                toggled = true;
                grabbing = true;

                CurrentGrabbedObj = IceSword.GetComponent<GrabObj>();

                if (CurrentGrabbedObj.activeHand)
                    CurrentGrabbedObj.activeHand.Drop();

                CurrentGrabbedObj.transform.position = transform.position;

                Rigidbody targetbody = CurrentGrabbedObj.GetComponent<Rigidbody>();

                FJ.connectedBody = targetbody;

                CurrentGrabbedObj.activeHand = this;
            }
        }



        //Earth Based spells
        else if (currentspell == "RockPillar")
        {
            GameObject RockPillar = Instantiate(GameObject.Find("PlayerController").GetComponent<SpellPrefabHolder>().RockPillar, transform.position, transform.rotation);

            RockPillar.GetComponent<Rigidbody>().AddRelativeForce(0, -8000, 8000);
        }



        //Air Based spells
        else if (currentspell == "AirBurst")
        {
            GameObject AirBurst = Instantiate(GameObject.Find("PlayerController").GetComponent<SpellPrefabHolder>().AirBurst, transform.position, transform.rotation);            
        }
        else if (currentspell == "JumpBoost")
        {
            GameObject.Find("PlayerController").GetComponent<InputRight>().JumpBoost();
        }
        else if (currentspell == "Haste")
        {
            GameObject.Find("PlayerController").GetComponent<InputLeft>().haste();
        }


    }
    public void ReleaseSpell()
    {
        // if a spell is a toggled spell then releasing the trigger stops the spell
        if(toggled)
        {
            if (currentToggle != null)
            {
                if(grabbing == false)
                {
                    Destroy(currentToggle);
                }
                else
                {
                    currentToggle.AddComponent<TimedObjectDestruction>().setTimer(1);
                    currentToggle = null;

                }
                
            }
            if (grabbing)
            {
                Drop();
                grabbing = false;
            }
            
            toggled = false;
        }
    }


    //sets the spell based on the magic code that was sent
    //there are 109601 combinations for spells
    public void setSpell(string code)
    {

        //FireSpells
        if (code == "82")
        {
            currentspell = "FireThrower";
            handEffect = "Fire";
        }
        else if(code == "83")
        {
            currentspell = "FireBolt";
            handEffect = "Fire";
        }
        else if(code == "836")
        {
            currentspell = "FireBall";
            handEffect = "Fire";
        }
        else if (code == "865")
        {
            currentspell = "FireSword";
            handEffect = "Fire";
        }


        //Ice Spells
        else if(code == "42")
        {
            currentspell = "SnowStorm";
            handEffect = "Ice";
        }
        else if (code == "43")
        {
            currentspell = "IceBolt";
            handEffect = "Ice";
        }
        else if (code == "436")
        {
            currentspell = "IceBall";
            handEffect = "Ice";
        }
        else if (code == "465")
        {
            currentspell = "IceSword";
            handEffect = "Ice";
        }


        //Earth Spells
        else if (code == "631")
        {
            currentspell = "RockPillar";
            handEffect = "Earth";
        }
        //Wind Spells
        else if (code == "216")
        {
            currentspell = "AirBurst";
            handEffect = "Wind";
        }

        else if (code == "5182")
        {
            currentspell = "JumpBoost";
            handEffect = "Wind";
        }
        else if (code == "7324")
        {
            currentspell = "Haste";
            handEffect = "Wind";
        }
      


        else
        {
            currentspell = "";
            handEffect = "";
        }
        spellset = false;
    }


    private void clearSpellsFX()
    {
        Destroy(currentFX);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Grab"))        
            return;
        contactGrabObj.Add(other.gameObject.GetComponent<GrabObj>());
    }
    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("Grab"))
            return;
        contactGrabObj.Remove(other.gameObject.GetComponent<GrabObj>());
    }


    public void Pickup()
    {
        Debug.Log("attemping to grab nearest");
        CurrentGrabbedObj = GetNearestObj();

        if (!CurrentGrabbedObj)
            return;

        if (CurrentGrabbedObj.activeHand)
            CurrentGrabbedObj.activeHand.Drop();

        CurrentGrabbedObj.transform.position = transform.position;

        Rigidbody targetbody = CurrentGrabbedObj.GetComponent<Rigidbody>();

        FJ.connectedBody = targetbody;

        CurrentGrabbedObj.activeHand = this;
    }
    public void Drop()
    {
        if (!CurrentGrabbedObj)
            return;

        Rigidbody targetbody = CurrentGrabbedObj.GetComponent<Rigidbody>();
        targetbody.velocity = m_Pose.GetVelocity();
        targetbody.angularVelocity = m_Pose.GetAngularVelocity();

        FJ.connectedBody = null;

        CurrentGrabbedObj.activeHand = null;
        CurrentGrabbedObj = null;

    }
    private GrabObj GetNearestObj()
    {
        Debug.Log("attempting to find nearest");
        GrabObj nearest = null;
        float mindist = float.MaxValue;
        float dist = 0.0f;

        foreach(GrabObj grabObj in contactGrabObj)
        {
            Debug.Log("check each obj");
            dist = (grabObj.transform.position - transform.position).sqrMagnitude;

            if (dist < mindist)
            {
                Debug.Log("set nearest");
                mindist = dist;
                nearest = grabObj;
            }
        }

        return nearest;
    }

}
