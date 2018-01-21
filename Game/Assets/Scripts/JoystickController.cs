using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickController : MonoBehaviour
{
    public PlayerController player;
    public Transform Ball;
    public float speed;

    private Vector3 ball_first_position;
    private Vector3 ball_direction;
    private float radius;           // 조이스틱 배경의 반 지름.
    private bool move_flag;          // 플레이어 움직임 스위치.

    void Start()
    {
        speed=5f;
        move_flag = false;
        ball_first_position = Ball.transform.position;

        radius = GetComponent<RectTransform>().sizeDelta.y * 0.5f;   
        radius = radius * transform.parent.GetComponent<RectTransform>().localScale.x;  // 캔버스 크기에대한 반지름 조절.
    }
    
    void FixedUpdate()  //물리효과계산을 수행하기 직전에 호출된다. 물리효과코드를 적는다
    {
        if (move_flag)
            player.transform.transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    public void Drag(BaseEventData _Data)
    {
        move_flag = true;
        PointerEventData Data = _Data as PointerEventData;  //마우스 및 터치에 대한 이벤트
        Vector3 touch_point = Data.position;    //현재 터치되고 있는 점

        ball_direction = (touch_point - ball_first_position).normalized;    // 조이스틱을 이동시킬 방향을 구함.(오른쪽,왼쪽,위,아래)
        float distance = Vector3.Distance(touch_point, ball_first_position);     // 처음 위치와 현재 터치점의 거리

        if (distance < radius)
            Ball.position = ball_first_position + ball_direction * distance;
        else
            Ball.position = ball_first_position + ball_direction * radius;

        player.transform.eulerAngles = new Vector3(0, Mathf.Atan2(ball_direction.x, ball_direction.y) * Mathf.Rad2Deg, 0);    //회전
        player.Fun_Animating(move_flag);
    }

    public void DragEnd()
    {
        Ball.position = ball_first_position;    //볼을 원래의 위치로.
        ball_direction = Vector3.zero;          //방향을 0으로.
        move_flag = false;
        player.Fun_Animating(move_flag);
    }
}