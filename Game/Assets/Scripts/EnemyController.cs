using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {

    Transform player;    //쫓을 객체
    NavMeshAgent navigation;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;  //Player태그의 위치를 알아낸다
        navigation = GetComponent<NavMeshAgent>();
    }
    
	void Update ()  //navigation은 물리효과와 관계없으므로
    {
        navigation.SetDestination(player.position); //가야할 곳
	}
}
