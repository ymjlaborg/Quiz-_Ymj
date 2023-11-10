using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSingleton : MonoBehaviour
{
    // 게임오브젝트 싱글톤
    public static PlayerSingleton instance;

    //게임 옵션 설정값
    private int Lang = LANG_KR;
    //플레이어 게임오브젝트
    static GameObject player; // static으로 선언해야 다른 스크립트에서 사용 가능
    //캐릭터 컨트롤러
    static CharacterController cc;

    public GameObject test;


    public const int LANG_KR = 0; //한국어
    public const int LANG_EN = 1; //영어
    public const int LANG_JJ = 2; //제주어

    private void Awake() {
        //플레이어 게임오브젝트 찾기
        player = GameObject.FindGameObjectWithTag("Player");
        //캐릭터 컨트롤러 컴포넌트 가져오기
        //cc = player.GetComponent<CharacterController>();

        Debug.Log("플레이어 게임오브젝트 : " + player);
        test = player;
        //싱글톤
        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

    


    }



    //플레이어 위치 이동
    public void TeleportPlayer(Vector3 pos) {
        //cc.enabled = false;
    var controller = test.GetComponent<CharacterController>();
    if (controller != null) {
        controller.enabled = false;
        test.transform.position = pos;
        controller.enabled = true;
    }
       
        
    }

    private void SetLang(int lang) { //한국어, 영어, 제주어
        Lang = lang; //한국어
        Debug.Log("언어 설정 : " + Lang);
        
    }
    
      public void Selecte_Langs_KR(){
        Lang = LANG_KR;
        SetLang(Lang);

    }

    public void Selecte_Langs_EN(){
        Lang = LANG_EN;
        SetLang(Lang);
        

    }

    public void Selecte_Langs_JJ(){
        Lang = LANG_JJ;
        SetLang(Lang);
        

    }
    public int Getlang() {
        Debug.Log("현재 언어 : " + Lang); 
        return Lang;   
    }


  
}
