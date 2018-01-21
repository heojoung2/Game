using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegisterManager : MonoBehaviour {

    public static bool input_text_flag;
    public PlayerManager player;
    public InputField input_text;

    private string id;
    private int score;

	// Use this for initialization
	void Start () {
        input_text_flag = false;
	}

    private void Update()
    {
        input_text.enabled = input_text_flag;
    }

    public void Fun_Register()
    {
        id = input_text.text;
        score = (int)PlayerManager.result_score;
        input_text.text = "";

        //서버 시작
        Set_Rank(id,score);
    }

    void Set_Rank(string id, int score)
    {
        WWWForm form = new WWWForm();
        form.AddField("id_post", id);
        form.AddField("score_post", score);

        WWW server_data = new WWW("http://192.168.1.78/rank_folder/insert.php", form);

        if(server_data.error!=null)
        {
            print("error");
        }
    }
}
