using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Camera main_camera;
    public Camera sub_camera;

    GameObject target;
    private Vector3 offset;     //카메라의 위치계산
    private int down = 9;
    private int up = 159;

	void Start ()
    {
        target = GameObject.Find("Player");
        offset = transform.position - target.transform.position;
	}

    void Update()
    {
        if ((down< target.transform.position.y &&  target.transform.position.y < down+1 ) || (up < target.transform.position.y && target.transform.position.y < up+1))
            Fun_Sub_Camera();
    }

    void LateUpdate ()  //Update의 제일 마지막
    {
            transform.position = target.transform.position + offset;   
    }

    void Fun_Sub_Camera()
    {
        main_camera.enabled = false;
        sub_camera.enabled = true;
        Invoke("Fun_Hide_Camera", 1.5f);  //1초후에 실행
    }

    void Fun_Hide_Camera()
    {
        main_camera.enabled = true;
        sub_camera.enabled = false;
    }
}
