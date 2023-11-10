using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.AI;
public class npc_tuto_field : MonoBehaviour
{
   // UI 컴포넌트
    public GameObject ui;

    
    public GameObject me;
    public GameObject ui_olds;
    public Button buttons; 

    
    public AudioClip buttonclick; // 오디오
   
    public Animator animator;
    
      static public npc_tuto_field instance;

    private bool walking;

    public float rotations = 1f;
   

    //ui관련 테스트//

    public bool meet;
    


    //대화창//

   public TextMeshProUGUI text;

   public TextMeshProUGUI text2;

   string m_Message; // 텍스트를 저장할 변수

   string m_Message2; // 텍스트를 저장할 변수
 
    
    public AudioClip[] audio1; // 오디오
    public AudioClip[] audio2; // 오디오
    public int[] value1; // value1 배열
    public int[] value2; // value2 배열
    public float m_Speed;
    public Button button;

    //public GameObject auto;
    public GameObject UI;

    public AudioSource audioSources;
    

   
    public int i = 0;    // 문자 배열의 인덱스
    public int jk;
    public int lang; //사용언어

    public int lan;
    private bool isTyping;
    private bool isEnd = false;
    private bool isStart;
    private bool isskip;   

    public bool firstnpc;


    public LangArray[] LangArrays; // CustomArray 타입의 배열

    public int Number;

    [System.Serializable]
    public class LangArray
    {
        public int[] Mword; // 첫 번째 int 값 배열
        public int[] Sword; // 두 번째 int 값 배열
        public AudioClip[] KMaudio; // 첫 번째 오디오 클립
        public AudioClip[] EMaudio; // 두 번째 오디오 클립

        public AudioClip[] JMaudio; // 두 번째 오디오 클립
        
        public GameObject Poi;
    }
    

   
       
    public void Start(){
     
        animator = GetComponent<Animator>();
        ui.SetActive(false);
        text = UI_Singleton.instance.uitext;
        text2 = UI_Singleton.instance.uitext2;
        UI = UI_Singleton.instance.UI2;
        button = UI_Singleton.instance.UIbuttons;
        audioSources = UI_Singleton.instance.audioSource;
        
     
          
  
    
     
      
      animator.SetFloat("Box", 2f);
      buttons.onClick.AddListener(() => {  
            
           
            
                
                Check_lang();

            
            
          
                       });


        

        button.onClick.AddListener(() => {  
            // 버튼 클릭시 isStart가 true이면 isStart를 false로 바꾸고 현재 타이핑중인 문자열을 스킵하고 다음 문자열을 출력한다
            
               skip();
               
            });
           
        
     

    }

    



  

  //플레이어가 트리거 안에 들어왔을 때
    private void OnTriggerEnter(Collider other) // 트리거 안에 들어왔을 때
    {  
       meet = true;
       if(meet == true){
         GameObject ac = other.gameObject;
         Cam(ac);
       }
          

        ui.SetActive(true);
}

// 플레이어가 트리거 밖으로 나갔을 때
    private void OnTriggerExit(Collider other)
    {
        ui.SetActive(false);
          
        meet = false;

        //만약 test.cs에 있는 isStart가 false이면 
    }



    public void Cam(GameObject a)
    {
     
         //me.transform.LookAt(a.transform); //me 오브젝트가 user을 바라보게 함
            //me.transform.rotation = Quaternion.Euler(0, me.transform.rotation.eulerAngles.y, 0);
            //버튼 활성화
        StartCoroutine(LookAtCamera(a, rotations));
        Debug.Log("트리거");

    }

    //UI가 LOOKAT으로 메인카메라를 바라보게 하는 코루틴 함수
    IEnumerator LookAtCamera(GameObject ac , float rotationSpeed )
    {
        while (meet) //
        {
         
            ui.transform.LookAt(Camera.main.transform);
        
                    Quaternion targetRotation = Quaternion.LookRotation(ac.transform.position - me.transform.position); // user를 바라보는 회전값을 구함
        targetRotation = Quaternion.Euler(0, targetRotation.eulerAngles.y, 0); // Z축 회전값을 0으로 고정
        
        me.transform.rotation = Quaternion.Lerp(me.transform.rotation, targetRotation, Time.deltaTime * rotationSpeed); //자연스러운 회전을 위해 Lerp 사용
         
          

            yield return null;
        }
    }




// 대화창 코드//

 public void Selecte_Langs(int lan){
        if(lan == 0){
            audio1 = LangArrays[Number].KMaudio;
            value1 = LangArrays[Number].Mword;
            audio2 = LangArrays[Number].KMaudio;
            value2 = LangArrays[Number].Sword;
            lang = 0;
            Debug.Log("한국어");
            UI_Singleton.instance.UI2.SetActive(true);
            Typing_start();
        }
        if(lan == 1){
            audio1 = LangArrays[Number].EMaudio;
            value1 = LangArrays[Number].Mword;
            audio2 = LangArrays[Number].EMaudio;
            value2 = LangArrays[Number].Sword;
            lang = 1;
            Debug.Log("영어");
              UI_Singleton.instance.UI2.SetActive(true);
            Typing_start();
        }
        if(lan == 2){
            audio1 = LangArrays[Number].JMaudio;
            value1 = LangArrays[Number].Mword;
            audio2 = LangArrays[Number].JMaudio;
            value2 = LangArrays[Number].Sword;
            lang = 2;
            Debug.Log("제주어");
            UI_Singleton.instance.UI2.SetActive(true);
            Typing_start();
        }
    }


    private void Check_lang() {  
     Selecte_Langs(PlayerSingleton.instance.Getlang());


     }


    //타이핑 시작 함수
    public void Typing_start() { 
      isStart = true;
      
      Debug.Log("Typing_start: i = " + i + ", value1.Length = " + value1.Length);
      // i가 value1의 길이보다 작을때까지 반복하고 i를 1씩 증가시킨다 만약 i가 value1의 길이보다 크면 UI를 비활성화
        if (i < value1.Length) {
            m_Message = LanguageSingleton.instance.Langs[lang].value[value1[i]].Replace("/", "\n");
            m_Message2 = LanguageSingleton.instance.Langs[lang].value[value2[i]].Replace("/", "\n");
            text2.text = m_Message2;
            StartCoroutine(Typing(text, m_Message, m_Speed));
            PlayAudio(i);
            i++;
           
           
        } else if( i >= value1.Length && isskip ) { // i가 value1의 길이보다 크면 UI를 비활성화
              UI.SetActive(false);
            audioSources.Stop();
            i = 0;
            
            isskip = false;
            if(firstnpc == true){
            
             Fade.instance.StartFadeIn();

            }
           
            
            
          //if()에서 그리고는 &&로 바꾸기
            
        }
       
         
        

    }

     
      IEnumerator Typing(TextMeshProUGUI text, string message, float speed)
    {   
        isTyping = true;
  
        for (int a = 0; a < message.Length; a++) // 0부터 message의 길이만큼 반복
        {   
            text.text = message.Substring(0, a+1);  // 0부터 a+1까지의 문자열을 가져옴
            yield return new WaitForSeconds(speed); // speed만큼 대기
        }
        
        
        
    }
    


    public void skip() {

            //만약 Typing_start함수가 실행되어 istyping이 true이면 typing함수를 중지시키고 text에 message를 넣어준다
            if (isTyping) {
                StopAllCoroutines();
                
                text.text = m_Message;
                

                isTyping = false;
                isskip = true;
                Debug.Log("스킵");
                isStart = false;
                
            } else if (isStart == false) { //만약 Typing_start함수가 실행되지 않았다면 Typing_start함수를 실행시킨다
                Typing_start();
                Debug.Log("타이핑");
            }
            
            
        
        
        
        
    }







     
   
  


  public void PlayAudio(int a) 
    {  
       
        Debug.Log("PlayAudio: a = " + a);
        audioSources.clip = audio1[a];    
        audioSources.Play();
    }
    

 

 

  

    






}
