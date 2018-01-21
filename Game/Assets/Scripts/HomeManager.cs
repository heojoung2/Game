using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class HomeManager : MonoBehaviour {

    void Update()  //프레임을 렌더링하기 전에 호출된다.
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void OnClickPlay()
    {
        AudioPlay();
        SceneManager.LoadScene("Main");
    }
    
    public void OnClickRank()
    {
        AudioPlay();
        SceneManager.LoadScene("Rank");
    }

    public void OnClickExit()
    {
        AudioPlay();
        Application.Quit();
    }

    public void OnClickHome()
    {
        AudioPlay();
        SceneManager.LoadScene("Home");
    }

    public void AudioPlay()
    {
        GameObject.Find("Canvas").GetComponent<AudioSource>().Play();
    }
}
