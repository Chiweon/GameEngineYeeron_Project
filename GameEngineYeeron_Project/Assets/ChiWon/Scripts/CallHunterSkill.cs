using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallHunterSkill : MonoBehaviour
{
    [Header("테스트 설정")]
    [Tooltip("자동 탄환 증가 보상을 받을 HunterSkill 컴포넌트를 여기에 할당하세요.")]
    public HunterSkill hunterSkill; // HunterSkill 컴포넌트를 할당할 슬롯

    [Tooltip("IncreaseAutoBulletCountReward 함수에 전달할 탄환 증가량입니다.")]
    public int testAmount = 5; // 테스트할 탄환 증가량

    [Tooltip("게임 시작 시(Awake) 바로 함수를 호출할지 여부입니다.")]
    public bool callOnAwake = true;

    // 선택 사항: 특정 키를 눌렀을 때 호출하고 싶다면
    [Tooltip("Space 키를 눌렀을 때 함수를 호출할지 여부입니다.")]
    public bool callOnSpaceKey = false;


    void Awake()
    {
        // HunterSkill 컴포넌트가 할당되지 않았다면, 같은 GameObject에서 찾아봅니다.
        if (hunterSkill == null)
        {
            hunterSkill = GetComponent<HunterSkill>();
        }

        // 그래도 HunterSkill이 없다면 경고 로그를 출력합니다.
        if (hunterSkill == null)
        {
            Debug.LogError("HunterSkill 컴포넌트를 찾을 수 없습니다. TestAutoBulletReward 스크립트에 할당하거나, 같은 GameObject에 HunterSkill이 있는지 확인하세요.", this);
            return; // 함수 실행 중단
        }

        // 게임 시작 시 바로 호출하도록 설정했다면 호출합니다.
        if (callOnAwake)
        {
            Debug.Log($"[TestAutoBulletReward] Awake에서 HunterSkill.IncreaseAutoBulletCountReward({testAmount}) 호출 시도.");
            CallIncreaseAutoBulletCountReward();
        }
    }

    void Update()
    {
        // Space 키를 눌렀을 때 호출하도록 설정했고, Space 키가 눌렸다면 호출합니다.
        if (callOnSpaceKey && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log($"[TestAutoBulletReward] Space 키 입력으로 HunterSkill.IncreaseAutoBulletCountReward({testAmount}) 호출 시도.");
            CallIncreaseAutoBulletCountReward();
        }
    }

    // 실제 IncreaseAutoBulletCountReward 함수를 호출하는 내부 메서드
    void CallIncreaseAutoBulletCountReward()
    {
        if (hunterSkill != null)
        {
            hunterSkill.IncreaseAutoBulletCountReward(testAmount);
        }
        else
        {
            Debug.LogError("HunterSkill이 할당되지 않아 IncreaseAutoBulletCountReward를 호출할 수 없습니다.", this);
        }
    }
}
