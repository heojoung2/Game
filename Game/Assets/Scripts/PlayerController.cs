using UnityEngine;

// This script is used to control the player with keyboard / controller mechanics. This differs from
// the Player_ControllerMove script in that this script also allows the player to jump
public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;
    private Vector3 player_input;

    private bool is_ground = true;


    void Start()    //스크립트가 활성화된 첫 번째 프레임에 호출
    {
        animator = GetComponent<Animator>();    //<>안을 참조해서 얻는다
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            is_ground = true;
            animator.SetBool("animator_ground", is_ground);
        }
    }

    public void Fun_Animating(bool flag)
    {
        animator.SetBool("animator_run",flag);    //애니메이터의 " "에 값을 알려준다.
    }

    public void Fun_Jump()
    {
        if (is_ground)
        {
            rb.velocity = new Vector3(0, 14, 0);
            is_ground = false;

            animator.SetTrigger("animator_jump");
            animator.SetBool("animator_ground", is_ground);
        }
    }
}
