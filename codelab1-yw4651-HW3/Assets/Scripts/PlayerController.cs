using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float force = 5;
    Rigidbody2D rb;


    public static PlayerController instance; //this static var will hold the Singleton

    private void Awake()
    {
        if (instance == null) //instance hasn't been set yet
        {
            instance = this; // set instance to this object

            DontDestroyOnLoad(gameObject); //Dont Destroy this object when you load a new scene

        }
        else
        { Destroy(gameObject); } // destroy this new object, so there is only one
    }


    private void Start()
    {
        Debug.Log("Hello, world!");

        rb = GetComponent<Rigidbody2D>();
    }
    


    // Start is called before the first frame update
  
    // Update is called once per frame
    void Update()  //draw
    {
        Debug.Log("Goodbye, world!");

    
        if (Input.GetKey(KeyCode.D)) {   // if D is pressed

            rb.AddForce(Vector2.right * force);   // apply a force using the "force" var
        }

        if (Input.GetKey(KeyCode.A)) {

            rb.AddForce(Vector2.left * force);
        }

        if (Input.GetKey(KeyCode.S)) {

            rb.AddForce(Vector2.down * force);
        }

        if (Input.GetKey(KeyCode.W)) {

            rb.AddForce(Vector2.up * force);

        }
    }
}
