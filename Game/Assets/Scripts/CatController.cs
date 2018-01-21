using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour {
    public float speed = 1;

    private Rigidbody rb;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        StartCoroutine(Fun_Move());
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + transform.TransformDirection(new Vector3(0, 0,1) *speed* Time.deltaTime));    //보고있는 방향의 직진
    }

    IEnumerator Fun_Move()
    {
        transform.Rotate(new Vector3(0, Random.Range(0, 360), 0),Space.Self);
        
        yield return new WaitForSeconds(5);
        StartCoroutine(Fun_Move());

    }
}
