using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public bool isdead = false;
    public static int result_score=0;
	
    void OnCollisionEnter(Collision other) //오브젝트가  트리거 콜라이더를 처음 접촉할 때(otehr = 접촉한 트리거 콜라이더)
    {
        if (other.gameObject.CompareTag("Enemy"))  //오브젝트의 태그가 ""라면
        {
            GetComponent<AudioSource>().Play();
            isdead = true;
            result_score = (int)ScoreManager.score;
        }
    }
}
