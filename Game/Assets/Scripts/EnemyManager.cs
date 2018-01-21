using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    static public bool isdownwolrd;
    public GameObject up_enemy;
    public GameObject down_enemy;
    public float spawn_time = 5f;

    private int random_size = 14;
    
    void Start ()
    {
        isdownwolrd = true;
        InvokeRepeating("Fun_Spawn", 0, spawn_time);    //0초후 Fun_Spawn함수를 spawn_time마다 실행한다	
	}

    void Fun_Spawn()
    {
        int x = Random.Range(-random_size, random_size);
        int z = Random.Range(-random_size, random_size);
        if (isdownwolrd)
        {
            int y = 5;
            Vector3 spawn_point = new Vector3(x, y, z);
            Instantiate(down_enemy, spawn_point, Quaternion.identity); //인스턴스화
        }
        else
        {
            int y = 155;
            
            Vector3 spawn_point = new Vector3(x, y, z);
            Instantiate(up_enemy, spawn_point, Quaternion.identity); //인스턴스화
            
        }
    }
}
