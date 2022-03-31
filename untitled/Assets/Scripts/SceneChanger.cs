using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //add scene management library

public class SceneChanger : MonoBehaviour
{
    public void GoToScene(string sceneName)
    {
        Debug.Log("Pressed button"); //check button functionality
        SceneManager.LoadScene(sceneName); //load end scene attempt 3
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
