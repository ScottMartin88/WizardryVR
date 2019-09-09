using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    public float counter = 0;
    public bool attackcount = false;
    public Animator m_Animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.GetComponent<MoveScript>().moving == true)
        {
            m_Animator.SetBool("Walking", true);
        }else m_Animator.SetBool("Walking", false);

        if (attackcount == false && this.gameObject.GetComponent<DetectionScript>().attacking == true)
        {
            m_Animator.SetBool("Attacking", true);
            attackcount = true;
            counter = 0.05f;
        }
        if (attackcount)
        {
            if (counter > 0)
            {
                counter -= 1 * Time.deltaTime;
            }
            else if (counter <= 0)
            {
                attackcount = false;
                counter = 0;
                m_Animator.SetBool("Attacking", false);
                this.gameObject.GetComponent<DetectionScript>().attacking = false;
            }
        }


    }

}
