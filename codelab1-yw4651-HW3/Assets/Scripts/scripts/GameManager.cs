using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //static variable means the value is the same for all the objects of this class type and the class itself
    public static GameManager instance; //this static var will hold the Singleton

    public Text ScoreText;

    private const string PLAY_PREF_KEY_HS = "High Score";
    private const string FILE_HS = "CodeLab1-week3-HighScore.text";
    private const string FILE_VALUE = "CodeLab1-week3-VALUE.text";// name of the file write and read multiple value;
    private int score = 0;


    public int Score
    {

        get
        {
            return score;

        }
        set
        {
            score = value;
            if (score > highScore)
            {

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



    private void Awake()
    {
        if (instance == null)
        { //instance hasn't been set yet
            instance = this; //set instance to this object
            DontDestroyOnLoad(gameObject); //Dont Destroy this object when you load a new scene
        }
        else
        { //if the instance is already set to an object
            Destroy(gameObject); //destroy this new object, so there is only ever one
        }
    }
    void Start()
    {


        //Rigidbody2D rb = GetComponent<Rigidbody2D>();

        //rb.AddForce(Vector2.right * force);
        Debug.Log(Application.dataPath);

        //highScore = PlayerPrefs.GetInt(PLAY_PREF_KEY_HS, 5); //get the high score out of PlayerPrefs
        ScoreText = GetComponentInChildren<Text>();

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
}



