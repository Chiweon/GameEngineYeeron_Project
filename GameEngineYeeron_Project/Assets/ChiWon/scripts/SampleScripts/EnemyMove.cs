using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public float moveSpeed;
    
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = (player.position - transform.position).normalized; //정규화: 거리에 따라 속도차가 나기 때문에 정규화 시킴 : 모든 수치를 1로 설정
        //Vector = 방향 + 스칼라 (힘) 
        //스칼라 : 수치(무게, 속력)
        transform.position += direction * moveSpeed * Time.deltaTime;
    }
}
