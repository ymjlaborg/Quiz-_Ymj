using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Find : MonoBehaviour
{  

    public GameObject player;
  

    //findeplayer를 다른 스크립트에서 사용하기 위해 static으로 선언
    public static void findeplayer()
    {
        
       GameObject player = GameObject.FindWithTag("Player");
         if (player != null) {
    // Player 오브젝트를 찾았으므로 여기에 로직을 추가합니다.
           } else {
                   Debug.Log("Player 오브젝트를 찾을 수 없습니다.");
                   } 
 
        PlayerSingleton.instance.test = player;
    }
   
   // 다른 스크립트에서 findeplayer를 실행시키는 코드는 아래와 같음
    // Find.findeplayer();
}
