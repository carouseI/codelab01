using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance; //static, shared among instances, no reference needed

    public bool HitCheckpoint { get; set; } //auto public bool property

    public static GameManager Instance
    {
        get
        {
            if (_instance is null) //check if null
                Debug.LogError("Game Manager is NULL");

            return _instance; //if null
        }

        private void Awake()
    {
        _instance = this; //initialise private instance
    }
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
