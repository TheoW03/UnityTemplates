using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dictionaryList : MonoBehaviour
{

    private List<string> keys = new List<string>();
    [SerializeField]
    private List<GameObject> values = new List<GameObject>();

    private Dictionary<string, GameObject> myDictionary = new Dictionary<string, GameObject>();
    void Start()
    {
        for(int i = 0; i < keys.Count;i++){
            keys.Add(values[i].tag);
        }
        for (int i = 0; i < Mathf.Min(keys.Count, values.Count); i++)
        {
            myDictionary.Add(keys[i], values[i]);
        }
    }
    public Dictionary<string, GameObject> getDictionary(){
        return myDictionary;
    }
}
