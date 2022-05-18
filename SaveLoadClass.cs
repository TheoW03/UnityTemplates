using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

/**
TODO: replace with stream reader
*/
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

        FileStream fcreate;
        if (!File.Exists(Path.Combine(Application.persistentDataPath, this.fileName)))
        {
            fcreate = File.Open(Path.Combine(Application.persistentDataPath, this.fileName), FileMode.Create); // will create the file or overwrite it if it already exists
            fcreate.Close();
        }

        using (StreamWriter stream = new StreamWriter(Path.Combine(Application.persistentDataPath, this.fileName)))
        {
            string json = JsonUtility.ToJson(obj);
            stream.Write(json);

        }


    }
    /**
     (T),
    */
    public T getObject()
    {
        try
        {
            using (StreamReader stream = new StreamReader(Path.Combine(Application.persistentDataPath, this.fileName)))
            {
                string json = stream.ReadToEnd();
                Object = JsonUtility.FromJson<T>(json);
                if (Object == null)
                {

                    return default(T);
                }
                return Object;
            }


        }
        catch (FileNotFoundException e)
        {
            Debug.Log("error getting data");
            return default(T);
        }
        catch (IOException e)
        {
            Debug.Log("file maybe corrupted");
            return default(T);
        }
    }

}
