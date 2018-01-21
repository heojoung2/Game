using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour {

    public int score_value = 100;

    private Rigidbody rb;
    private int random_size = 14;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        StartCoroutine(Fun_Move());
    }

    void OnCollisionEnter(Collision other) //오브젝트가  트리거 콜라이더를 처음 접촉할 때(otehr = 접촉한 트리거 콜라이더)
    {
        if (other.gameObject.CompareTag("Player"))  //오브젝트의 태그가 ""라면
        {
            GetComponent<AudioSource>().Play();

            ScoreManager.score += score_value;

            int x = Random.Range(-random_size, random_size);
            float[] y = {3.5f,153.3f};
            int y_index = Random.Range(0, 2);
            int z = Random.Range(-random_size, random_size);
            x = 0;
            z = 0;
            Vector3 re_spawn_point = new Vector3(x, y[y_index], z);
            transform.position = re_spawn_point;
        }
    }

    IEnumerator Fun_Move()
    {
        rb.AddForce(new Vector3(Random.Range(-100, 100), Random.Range(0, 100), Random.Range(-100, 100)));

        yield return new WaitForSeconds(1);
        StartCoroutine(Fun_Move());

    }
}
