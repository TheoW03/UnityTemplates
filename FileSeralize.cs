using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoadClass<T>
{
    private T Object;
    private string fileName;
    public SaveLoadClass(string fileName)
    {
        this.fileName = fileName;

    }
    public void setItem(T obj)
    {
        if(!Directory.Exists(Application.persistentDataPath+"/mySaveData/")){
            Directory.CreateDirectory("/mySaveData/");
        }
        BinaryFormatter formatter = new BinaryFormatter();
        string json = JsonUtility.ToJson(obj);
        File.WriteAllText(Application.persistentDataPath +"/mySaveData/"+ this.fileName,json);
    }
    /**
     (T),
    */
    public T getObject()
    {
        try
        {

            string json = File.ReadAllText(Application.persistentDataPath +"/mySaveData/"+ this.fileName);
            Object = JsonUtility.FromJson<T>(json);
        }
        catch (FileNotFoundException e)
        {
            Debug.Log("error getting data");
        }


        return Object;
    }

}
