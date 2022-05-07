using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    #region
    //array, set number of boxes + restricted
    //list, dynamic

    //not required to be under same parent, but all npcs have canvases

    //dictionary, data structure with key value pair
    #endregion

    //public List<GameObject> npcObjs = new List<GameObject>();

    Dictionary<string, float> npcInfo = new Dictionary<string, float>();

    public GameObject npcPrefab;

    // Start is called before the first frame update
    void Start()
    {
        #region process
        //1. loop through all npcs
        //2.  access each npcObj
        //3.  access each npc text comp
        //4.  set text of text comp
        #endregion

        #region //for loop
        //for (int i = 0; i < npcObjs.Count; i++)
        //{
        //    npcObjs[i].GetComponentInChildren<TextMeshProUGUI>().SetText("Bob");
        //}
        #endregion

        npcInfo.Add("eckles", 0.6f);
        npcInfo.Add("yeni", 0.9f);
        npcInfo.Add("laurus", 0.56f);
        npcInfo.Add("lucas", 1f);

        //float testValue; //temp value
        //npcInfo.TryGetValue("laurus", out testValue); //if laurus is present, set test value to whatever laurus is

        //Debug.Log(testValue);

        foreach(KeyValuePair<string, float> pair in npcInfo) //loop through dictionary
        {
            #region //debug
            //Debug.Log(pair.Key);
            //Debug.Log(pair.Value);
            #endregion

            GameObject newNpc = Instantiate(npcPrefab); //instantiate new controller
            newNpc.GetComponent<NPCController>().sight = pair.Value; //set sight value
            newNPC.GetComponentInChildren<TextMeshProUGUI>().SetText(pair.Key); //set text to key
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
