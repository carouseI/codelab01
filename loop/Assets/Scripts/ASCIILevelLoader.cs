using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ASCIILevelLoader : MonoBehaviour
{
    public string fileName; //level file name

    public float xOffset; //x position where grid starts; relative to game object
    public float yOffset; //y position where gird starts;     "     "   "    "


    // Start is called before the first frame update
    void Start()
    {
        StreamReader reader = new StreamReader(fileName); // open file
        string contentOfFile = reader.ReadToEnd(); //read whole file + store to variable
        reader.Close(); //close file

        //Debug.Log(contentOfFile);

        char[] newLineChar = { '\n' }; //check fore line break character

        string[] level = contentOfFile.Split(newLineChar); //split based on \n

        for(int i = 0; i < level.Length; i++) //loop each row in level
        {
            MakeRow(level[i], -i); //make row
        }
    }

    void MakeRow(string rowStr, float y) //2 parameters; characters of row + row's y position
    {
        //char c = contentOfFlie[i];
        //if (c == 'X')
        //{
        char[] rowArray = rowStr.ToCharArray(); //turn row into array of characters
        for(int x = 0; x < rowStr.Length; x++) //loop according to number of characters
        {
            char c = rowArray[x]; //store current character as variable c
            if(c == 'X') //if character is X
            {
                Debug.Log("make a cube");
                GameObject brick = Instantiate(Resources.Load("Brick")) as GameObject; //create a cube from resources folder
                //set position of new game object
                brick.transform.position = new Vector3(
                    x * brick.transform.localScale.x + xOffset,
                    y * brick.transform.localScale.y + yOffset,
                    0
                    );
            } else if(c == 'C') //if character is C
            {
                GameObject tube = Instantiate(Resources.Load("Tube")) as GameObject; //create a cylinder from resources folder
                //set position of new game object
                tube.transform.position = new Vector3(
                    x * tube.transform.localScale.x + xOffset,
                    y * tube.transform.localScale.y + yOffset,
                    0
                    );
            } else if(c == 'O') //if character is O
            {
                GameObject ball = Instantiate(Resources.Load("Ball")) as GameObject; //create a sphere from resources folder
                //set position of new game object
                ball.transform.position = new Vector3(
                    x * ball.transform.localScale.x + xOffset,
                    y * ball.transform.localScale.y + yOffset,
                    0
                    );
            }
            Debug.Log(y);
        }
        // }
    }

}
