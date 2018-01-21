using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour {

    public static bool pause_flag;
    public PlayerManager player;

    private GameObject result_text;
    private float stop_time;

    Animator animator;
    
	void Awake()    //Start보다도 먼저, 객체가 생성될때 호출됩니다. Start는 비활성화되고 활성화 될때 다시 실행되지만 Awake는 단 한번
    {
        animator = GetComponent<Animator>();
        result_text = GameObject.Find("GameOverText");
    }

    private void Start()
    {
        stop_time = 0;
        pause_flag=false;
    }
    
	// Update is called once per frame
	void Update ()
    {
        if (player.isdead)
        {
            animator.SetTrigger("animator_gameover");
            result_text.GetComponent<Text>().text = "GAMEOVER\n\nSCORE : " + (int)PlayerManager.result_score;
            Fun_Audio_Zero();

            stop_time += Time.deltaTime;
            if (stop_time > 1)
            {
                pause_flag = true;
            }
        }

        if (pause_flag)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

    void Fun_Audio_Zero()
    {
        GameObject.Find("UpBoundary").GetComponent<AudioSource>().volume = 0;
        GameObject.Find("DownBoundary").GetComponent<AudioSource>().volume = 0;
    }
}
