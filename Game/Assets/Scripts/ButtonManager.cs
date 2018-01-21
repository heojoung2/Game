using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

    public static bool rank;
    public PlayerManager player_manager;
    public PlayerController player_controller;
    public RegisterManager registermanager;

    GameObject audio_obj;

    private void Start()
    {
        audio_obj = GameObject.Find("Canvas");
        rank = false;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Home");
        }
    }

    public void OnClickPause()
    {
        AudioPlay();
        AudioListener.volume = 0;
        GameOverManager.pause_flag = true;
    }

    public void OnClickPlay()
    {
        AudioPlay();
        AudioListener.volume = 1;
        GameOverManager.pause_flag = false;
    }

    public void OnClickRetry()
    {
        if (player_manager.isdead==true)
        {
            AudioPlay();

            SceneManager.LoadScene("Main");
        } 
    }

    public void OnClickHome()
    {
        if (player_manager.isdead == true)
        {
            AudioPlay();

            SceneManager.LoadScene("Home");
        }
    }

    public void OnClickRank()
    {
        if (player_manager.isdead == true)
        {
            rank = true;
            AudioPlay();
            GameObject.Find("Rank").GetComponent<Animator>().SetBool("animator_rank",rank);

            RegisterManager.input_text_flag = true;
        }
    }

    public void OnClickYes()
    {
        RegisterManager.input_text_flag = false;
        if (rank == true)
        {
            rank = false;
            AudioPlay();
            GameObject.Find("Rank").GetComponent<Animator>().SetBool("animator_rank", rank);

            registermanager.Fun_Register();
        }
    }

    public void OnClickJump()
    {
        player_controller.Fun_Jump();
        AudioPlay();
    }

    public void AudioPlay()
    {
        audio_obj.GetComponent<AudioSource>().Play();
    }
}
