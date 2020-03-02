using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example : MonoBehaviour
{
    public Color colorStart;
    public Color colorEnd;
    // Fade the color from red to green
    // back and forth over the defined duration

    //Color colorStart = new Color(0.3f, 0.3f,0.6f);
  
    float duration = 1.0f;
    SpriteRenderer rend;

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float lerp = Mathf.PingPong(Time.deltaTime, duration) / duration;
        rend.material.color = Color.Lerp(colorStart, colorEnd, 1);
    }
}