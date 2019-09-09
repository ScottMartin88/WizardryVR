using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFaceScript : MonoBehaviour
{

    public enum Emotion { Happy, Neutral, Sad, Angry, suprised, admiration, conceited, confused }
    public Emotion EmotionalState = Emotion.Neutral;
    [Space]
    public bool talking = false;
    public bool ChangeState = true;

    [Header("Eyes")]
    public GameObject eyes;
    public Material open;
    public Material closed;

    [Header("EyeBrows")]
    public GameObject eyebrows;
    public Material e_up;
    public Material e_neutral;
    public Material e_down;

    [Header("Mouth")]
    public GameObject mouth;
    public Material m_happy;
    public Material m_neutral;
    public Material m_sad;
    public Material m_open;
    public Material m_open2;
    public Material m_open3;
    Material currentEyeBrows;
    Material currentMouth;

    float blinkCounter = 1;
    float talkCounter = 0;
    bool eyesOpen = true;
    int mouthopen = 0;

 
    // Start is called before the first frame update

    
    void Start()
    {
        //Set the eyes to open as there is nothing to set the eyes unless he blinks, which would initially leave him without eyes.
        eyes.GetComponent<SkinnedMeshRenderer>().material = open;
    }

    // Update is called once per frame
    void Update()
    {
        //being used to update the counters on every frame.

        if (blinkCounter > 0)
        {
            blinkCounter -= 1 * Time.deltaTime;
        }
        if (talking && talkCounter > 0)
        {
          talkCounter -= 1 * Time.deltaTime;
        }
    }
    private void FixedUpdate()
    {

        //changing the face in the fixed updaye as it's not required to be as responsive as the timer
        
        //if changestate bool is true, then the state will be changed, the bool is true by default to set up the character initially.
        if (ChangeState)
        {
            ChangeEmotionalState();
            ChangeState = false;
        }

        if (blinkCounter <= 0)
        {
            Blink();
        }

        if (talkCounter <= 0)
        {
            Talking();
        }

        //This means that if he is not talking and his mouth is open, he will close it. 
        if (mouthopen > 0 && talking == false)
        {
            mouth.GetComponent<SkinnedMeshRenderer>().material = currentMouth;
        }

    }

    void ChangeEmotionalState()
    {

        //this sets the face to the emotion that the character has, changing the eyebrows and mouth to reflect the emotion.
        if (EmotionalState == Emotion.Happy)
        {
            currentEyeBrows = e_neutral;
            currentMouth = m_happy;
        }
        else if (EmotionalState == Emotion.Neutral)
        {
            currentEyeBrows = e_neutral;
            currentMouth = m_neutral;
        }
        else if (EmotionalState == Emotion.Sad)
        {
            currentEyeBrows = e_up;
            currentMouth = m_sad;
        }
        else if (EmotionalState == Emotion.Angry)
        {
            currentEyeBrows = e_down;
            currentMouth = m_sad;
        }
        else if (EmotionalState == Emotion.suprised)
        {
            currentEyeBrows = e_up;
            currentMouth = m_neutral;
        }
        else if (EmotionalState == Emotion.admiration)
        {
            currentEyeBrows = e_up;
            currentMouth = m_happy;
        }
        else if (EmotionalState == Emotion.conceited)
        {
            currentEyeBrows = e_down;
            currentMouth = m_happy;
        }
        else if (EmotionalState == Emotion.confused)
        {
            currentEyeBrows = e_down;
            currentMouth = m_neutral;
        }

        SetEmotionalState();
    }
    void SetEmotionalState()
    {        
      
        eyebrows.GetComponent<SkinnedMeshRenderer>().material = currentEyeBrows;
        mouth.GetComponent<SkinnedMeshRenderer>().material = currentMouth;
    }
    void Blink()
    {
        //the blink script. it activated everytime the counter is at 0 or less and then the timer is set in here, so he keeps his eyes open for a time. closes and opens them quickly
        //allowing for the blink

        if (eyesOpen)
        {
            eyes.GetComponent<SkinnedMeshRenderer>().material = closed;
            blinkCounter = 0.1f;
            eyesOpen = false;
        }
        else if (!eyesOpen)
        {
            eyes.GetComponent<SkinnedMeshRenderer>().material = open;
            blinkCounter = Random.Range(5, 10);
            eyesOpen = true;
        }
    }
    void Talking()
    {

        //works the same as the blinking but both are set to the same quick time, so that the mouth keeps opening and closing quickly.
        if (mouthopen == 0)
        {
            mouth.GetComponent<SkinnedMeshRenderer>().material = currentMouth;
            talkCounter = 0.1f;
            mouthopen = 1;
        }
        else if (mouthopen == 1)
        {
            mouth.GetComponent<SkinnedMeshRenderer>().material = m_open3;
            talkCounter = 0.1f;
            mouthopen = 2;
        }
        else if (mouthopen == 2)
        {
            mouth.GetComponent<SkinnedMeshRenderer>().material = m_open;
            talkCounter = 0.1f;
            mouthopen = 3;
        }
        else if (mouthopen == 3)
        {
            mouth.GetComponent<SkinnedMeshRenderer>().material = m_open2;
            talkCounter = 0.15f;
            mouthopen = 4;
        }
        else if (mouthopen == 4)
        {
            mouth.GetComponent<SkinnedMeshRenderer>().material = m_open;
            talkCounter = 0.1f;
            mouthopen = 5;
        }
        else if (mouthopen == 5)
        {
            mouth.GetComponent<SkinnedMeshRenderer>().material = m_open3;
            talkCounter = 0.1f;
            mouthopen = 0;
        }
    }
}
