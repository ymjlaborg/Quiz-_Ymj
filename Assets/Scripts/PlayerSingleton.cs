using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSingleton : MonoBehaviour
{
    // 게임오브젝트 싱글톤
    public static PlayerSingleton instance;

    //게임 옵션 설정값
    private int Lang = UI_TALK;
    //플레이어 게임오브젝트
    static GameObject player; // static으로 선언해야 다른 스크립트에서 사용 가능
    //캐릭터 컨트롤러
    static CharacterController cc;

   


    public const int QUIZ_FOOD = 0; //한국어
    public const int QUIZ_SPORT = 1; //영어
    public const int QUIZ_NORMAL = 2; //제주어

    public const int UI_TALK = 3; //대화창

    private void Awake() {
       
    
        //싱글톤
        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

    


    }



    //플레이어 위치 이동
  
       
        
    

    private void SetLang(int lang) { //한국어, 영어, 제주어
        Lang = lang; //한국어
        Debug.Log("언어 설정 : " + Lang);
        
    }
    
      public void Selecte_Langs_KR(){
        Lang = QUIZ_FOOD;
        SetLang(Lang);

    }

    public void Selecte_Langs_EN(){
        Lang = QUIZ_SPORT;
        SetLang(Lang);
        

    }

    public void Selecte_Langs_JJ(){
        Lang = QUIZ_NORMAL;
        SetLang(Lang);
        

    }

    public void Selecte_Langs_TALK(){
        Lang = UI_TALK;
        SetLang(Lang);
        

    }
    public int Getlang() {
        Debug.Log("현재 언어 : " + Lang); 
        return Lang;   
    }


  
}
