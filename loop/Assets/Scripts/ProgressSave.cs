using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ProgressSave : MonoBehaviour
{
    public string fileName; //read this file
    
    const char delimiter = '|'; //transl = "break", separates items


    // Start is called before the first frame update
    void Start()
    {
        StreamReader reader = new StreamReader(fileName); //open stream reader
        string newPos = reader.ReadLine(); //read file; should be @ saved player position
        reader.Close(); //close file
        Debug.Log(newPos); //show line read in console

        string[] pos = newPos.Split(new char[] { delimiter }); //split line based on delimiter
        transform.position = new Vector3(float.Parse(pos[0]), float.Parse(pos[1]), float.Parse(pos[2])); //turn line into a vector 3
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //if space is pressed
        {
            StreamWriter writer = new StreamWriter(fileName); //open file
            //write player position to file
            writer.Write("" +
                transform.position.x + delimiter +
                transform.position.y + delimiter +
                transform.position.z);
            writer.Close(); //close file
        }
    }
}
