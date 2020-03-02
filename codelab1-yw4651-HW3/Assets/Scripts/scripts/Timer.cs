using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float currentTime = 0f; // the time now display
    public float startingTime = 30f;  //play time

    public Text countdownText;

    void Start()
    {
        currentTime = startingTime;
    }

    void Update()
    {
       currentTime -= 1 * Time.deltaTime; //

       countdownText.text = currentTime.ToString("0");

       if(currentTime <= 0)
        {

            currentTime =0;

        }


        }
    }

