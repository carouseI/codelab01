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
    private void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Player")) //check last scene trigger if player hits checkpoint
    {
        _cutscene.SetActive(true);
        GameManager.Instance.HitCheckpoint = true;
        Destroy(GameObject);
    }
    else
    {
        if (GameManager.Instance.HitCheckpoint)
            _cutscene.SetActive(true);
    }
}
}
