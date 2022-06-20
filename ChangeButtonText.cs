using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChangeButtonText : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject button1;
    private string s;
    public void changewithHover()
    {
        button1.GetComponent<Text>().color = Color.yellow;
        s = button1.GetComponent<Text>().text;
        button1.GetComponent<Text>().text = ">" + s + "<";
    }
    public void leave()
    {
        button1.GetComponent<Text>().color = Color.white;
        button1.GetComponent<Text>().text = s;
    }
}
