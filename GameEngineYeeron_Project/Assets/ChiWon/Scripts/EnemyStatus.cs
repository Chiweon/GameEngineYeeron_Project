using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    public int maxHP = 20;
    public int currentHP = 20;
    public int adk = 1;
    public int expValue = 1;
    public float moveSpeed = 8.0f;

    public Transform player;
    public PlayerLevel playerLevel;
    
    public void Start()
    {
        currentHP = maxHP;
        player = GameObject.Find("Player").transform;
        playerLevel = GameObject.Find("PlayerLevelManager").gameObject.GetComponent<PlayerLevel>();
    }

    public void Update()
    {
        MoveToPlayer();
        EnemyDamaged();
    }

    //플레이어가 몬스터와 한번 충돌하면 플레이어가 몬스터가 향하는 방향과 같은 방향으로 자동으로 이동하는 버그가 있음
    void MoveToPlayer() 
    {
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    public void EnemyDamaged ()
    {
        if (currentHP <= 0)
        {
            Debug.Log("Enemy is dead");
            EnemyDie();
            
        }
    }

    void EnemyDie()
    {
        
        playerLevel.playerExp += expValue;
        Debug.Log("Got EXP");
        Destroy(gameObject);
    }
}

public class FirstEnemy : EnemyStatus
{
    new public void Start()
    {
        //base.Start();
        //maxHP = 100;
        //expValue = 10;
        //adk = 1;
    }
}



