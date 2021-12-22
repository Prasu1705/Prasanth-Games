using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerCountDown : MonoBehaviour
{
    public GameObject textDisplay;
    public int secondsLeft;
    public bool takingAway = false;
    public CollisionHandler collisionHandler;

    void Start()
    {
        textDisplay.GetComponent<Text>().text = "00:" + secondsLeft;
    }

    // Update is called once per frame
    void Update()
    {
        if(takingAway == false && secondsLeft>0)
        {
            StartCoroutine(TimerTake());
        }
        else if(secondsLeft ==0)
        {
            collisionHandler.StartCrashSequence();
        }

    }
    IEnumerator TimerTake()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        secondsLeft -= 1;
        if(secondsLeft < 10)
        {
            textDisplay.GetComponent<Text>().text = "00:0" + secondsLeft;
            takingAway = false;
        }
        else
        {
            textDisplay.GetComponent<Text>().text = "00:" + secondsLeft;
            takingAway = false;
        }
    }
}
