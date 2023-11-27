using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //2D게임에서 트리거를 사용하기 위해 필요한 컴포넌트
     


    //만약 플레이어가 2D 콜라이더에 닿았다면, NPC_TUTO를 찾아서 대화창을 띄워준다.
    public void Start_land()
    {
        Npc_Tuto.instance.Start_main();
    }


    // 스타트 함수 실행 
    public void Start()
    {
        //인보크 함수를 사용해서 3초후에 Start_land 함수를 실행한다.
        Invoke("Start_land", 3f);
    }
}
