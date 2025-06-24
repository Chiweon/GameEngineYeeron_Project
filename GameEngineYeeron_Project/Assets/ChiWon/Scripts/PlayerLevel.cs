using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    public int playerMinLv = 1;
    public int playerMaxLv = 50;
    public int playerCurrentLv;
    public int playerExp = 0;

    private void Start()
    {
        playerCurrentLv = playerMinLv;
        Debug.Log($"플레이어 레벨:{playerCurrentLv}");
    }


    void Update()
    {
        //몬스터를 한번에 여러마리 잡으면서 레벨이 한번데 2이상 오를경우 UI호출 예외사항 처리할것
        if(playerExp >= 5)
        {
            if (playerCurrentLv < playerMaxLv)
            {
                playerCurrentLv += 1;
                playerExp = 0;
                Debug.Log(playerCurrentLv);
            }
            else
            {
                Debug.Log("Level MAX");
            }

        }

    }
}
