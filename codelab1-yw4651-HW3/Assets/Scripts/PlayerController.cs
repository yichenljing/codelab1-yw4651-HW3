using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float force = 5;
    Rigidbody2D rb;

    private const string PLAY_PREF_KEY_HS = "High Score";
    private const string FILE_HS = "CodeLab1-week3-HighScore.text"; 
    private const string FILE_VALUE = "CodeLab1-week3-VALUE.text";// name of the file write and read multiple value;
    private int score = 0;
    public int Score {

        get {
            return score;

        }
        set {
            score = value;
            if (score > highScore) {

                HighScore = score;
            }

                }
    }



    private List<int> allScores = new List<int>(); //list to hold all high scores

    private int highScore = 0;

    //Property for HighScore
    private int HighScore
    {
        get
        {
            return highScore;
        }
        set
        {
            highScore = value;
            //Save it somewhere
            //PlayerPrefs.SetInt(PLAY_PREF_KEY_HS, highScore); //save HighScore to PlayerPrefs

            //Save High Score to a file
            File.WriteAllText(Application.dataPath + FILE_HS, highScore + "");

            //Add the high Score to the allScores list
            allScores.Add(highScore);

            string allScoreString = ""; //make an empty string
            for (int i = 0; i < allScores.Count; i++)
            { //loop through from 0 to the number of items in allScores
                allScoreString = allScoreString + allScores[i] + ","; //add the high score in the ith place to the string followed by a ","
            }
            File.WriteAllText(Application.dataPath + FILE_VALUE, allScoreString); //write the string to the all scores file
        }
    }





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

    void Start()
    {
        Debug.Log("Hello, world!");

        rb = GetComponent<Rigidbody2D>();

        //Rigidbody2D rb = GetComponent<Rigidbody2D>();

        //rb.AddForce(Vector2.right * force);
        Debug.Log(Application.dataPath);

       
        if (File.Exists(Application.dataPath + FILE_HS)) //if the file exists
        {
            string hsString = File.ReadAllText(Application.dataPath + FILE_HS); //read the text from the file into a string

            print(hsString); //print the contents of the file
            string[] splitString = hsString.Split(','); //split the string on ','
            highScore = int.Parse(splitString[0]); //parse the string in the first place

            for (int i = 0; i < splitString.Length; i++)
            { //go through the split string array
                print(splitString[i]); //print out each value
            }
        }
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
