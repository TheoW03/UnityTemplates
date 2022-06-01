using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSomething : MonoBehaviour{
    private bool Exists = false;
    private GameObject newObj;
    private Sprite NewSprite;
    public GameObject[] prefab; //get value in editor 
    public Sprite sprite; //get value in editor
    private List<GameObject> AL;
    
    void Start(){

    }
    void Update(){
        if(!Exists){
            newObj = Instantiate(prefab);
            NewSprite = sprite; 
            newCar.GetComponent<SpriteRenderer>().sprite = NewSprite;
            AL.add(newObj);
            Exists = true;
        }
        int i = 0;
    }
    

}
