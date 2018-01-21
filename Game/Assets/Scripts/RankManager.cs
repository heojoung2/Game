using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankManager : MonoBehaviour {

    private string[] data;
	// Use this for initialization
	void Start () {
        StartCoroutine(Get_Rank());
        
    }

    IEnumerator Get_Rank()
    {
        WWW server_data = new WWW("http://192.168.1.78/rank_folder/search.php");
        yield return server_data;

        if(server_data.error!=null)
        {
            print("error");
        }

        string server_data_string = server_data.text;
        string result = "";
        data = server_data_string.Split('|');

        for (int i = 0; i < data.Length-1; i++)
        {
            result += ((i+1)+" "+data[i] + "\n");
        }
        GetComponent<Text>().text = result;
    }
}
