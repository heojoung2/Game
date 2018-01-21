using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryManager : MonoBehaviour {
    public int y_position;
    public bool downworld;
    public GameObject audio_obj;

    private bool first_up_flag = false;
    
    private void OnCollisionEnter(Collision other) //오브젝트가  트리거 콜라이더를 처음 접촉할 때(otehr = 접촉한 트리거 콜라이더)
    {
        if (first_up_flag == false)
        {
            GameObject.Find("UpBoundary").GetComponent<AudioSource>().Play();
            first_up_flag = true;
        }
        

        if (other.gameObject.CompareTag("Player"))  //오브젝트의 태그가 ""이라면
        {
            this.GetComponent<AudioSource>().volume = 0;
            audio_obj.GetComponent<AudioSource>().volume = 1;

            other.gameObject.transform.position = new Vector3(-other.gameObject.transform.position.x, y_position, -other.gameObject.transform.position.z);
            EnemyManager.isdownwolrd = downworld;
        }
    }
}
