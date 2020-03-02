using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SpriteRenderer))]
public class changeColor : MonoBehaviour
{
    public Color colorA;
    public Color colorB;


        private SpriteRenderer spriteRenderer;
       
        public float timeTochange = 0.1f; //how often colors change
        private float StartTime = 0f;  //when to start count time

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }


        // Update is called once per frame
        private void Update()
        {
            StartTime += Time.deltaTime;  

        if (spriteRenderer.color != colorA && StartTime >= timeTochange) //change color when it's time
        {    

            spriteRenderer.color = colorA;
            StartTime = 0f;  //reset the start time to 0
        }
        else if(spriteRenderer.color != colorB && StartTime >= timeTochange) {

            spriteRenderer.color = colorB;
            StartTime = 0f;
        }
        }
    }
