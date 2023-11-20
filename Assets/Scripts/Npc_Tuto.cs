using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.AI;
using System.Security;
using Unity.VisualScripting;




public class Npc_Tuto : MonoBehaviour
{  

 public string m_Message; // 텍스트를 저장할 변수
 public string m_Message2;

 public int lang = 3;

 public int[] value1; // value1 배열

 public int[] value2; 

 public int i = 0;    // 문자 배열의 인덱스

 public TextMeshProUGUI text;
 public TextMeshProUGUI text2;

 public TextMeshProUGUI point_text;

 public TextMeshProUGUI time_text;

 

  public float m_Speed = 0.1f;

  public GameObject button;

    public bool isStart;

    public bool istyping;
  

  // [게임 시작시 지워질 요소]
  public GameObject Npc;

  public GameObject player;

  static public Npc_Tuto instance;

  public LangArray[] LangArrays;

  


  //inputfield 변수
  

  //텍스트 메쉬 프로 인풋 필드
    public TMP_InputField tmpInputFields;

  public int Number;

  public GameObject next;

  public GameObject apply;

  private bool Quiz_Round;

  int point = 20;



  float Quiztime = 45;




   [System.Serializable]
    public class LangArray
    {
        public int[] Mword; // 첫 번째 int 값 배열

        public int[] Genre; // 두 번째 int 값 배열
      
    }

  void Awake() {
    if(instance == null) {
        instance = this;
    }
}


public void Start_main()
{

    
System.Random random = new System.Random();  // 랜덤 객체 생성
value1 = new int[1];  // 한 개의 요소를 저장할 수 있는 배열 생성
value1[0] = random.Next(0, 3);  // 0부터 4까지의 랜덤한 정수 생성 후 배열에 저장
tmpInputFields.onEndEdit.AddListener(SubmitInput);
Typing_start(); 
}



public void Typing_start() {  
    
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          
         
      Debug.Log("Typing_start: i = " + i + ", value1.Length = " + value1.Length);
      // i가 value1의 길이보다 작을때까지 반복하고 i를 1씩 증가시킨다 만약 i가 value1의 길이보다 크면 UI를 비활성화
        if (i < value1.Length) {
            m_Message = LanguageSingleton.instance.Langs[lang].value[value1[i]].Replace("/", "\n");
            
            //타이머 코루틴 실행
            
            isStart = true;
            
            Debug.Log("m_Message: " + m_Message);

          
            
            StartCoroutine(Typing(text, m_Message, m_Speed));

          
            i++;

             if(Quiz_Round == true) {
                if(i > 1) 
                {
                  point -= 2;
                 point_text.text =  "획득 가능 포인트 : " + point;
                 Quiztime = 45;
                  StartCoroutine(Timeset(Quiztime));
                }
                else
                {
                   point -= 2;
                if (i >= value1.Length) point = 2; // i가 value1의 길이보다 크면 point를 2로 설정

                point_text.text =  "획득 가능 포인트 : " + point;
                Debug.Log("모르겠다" + point_text.text);
                Quiztime = 45;
                 StartCoroutine(Timeset(Quiztime));
                
                }
                


               
                //45초 타이머
                

        
                
            }

            
           
           
        } else if( i >= value1.Length ) { // i가 value1의 길이보다 크면 UI를 비활성화
              
            
            Debug.Log("대화 끝");

            
            point_text.text = "얻으신 포인트는 : " + point + "입니다.";
           

            }
           
            
            
          //if()에서 그리고는 &&로 바꾸기
            
        }




           IEnumerator Typing(TextMeshProUGUI text, string message, float speed)
    {   
          istyping = true;

          

          if(point == 2) {
                    //value1.Length의 마지막 값 호출 
                 int lastElement = value1[value1.Length - 1];
                 m_Message = LanguageSingleton.instance.Langs[lang].value[lastElement].Replace("/", "\n");
                 text.text = " 정답은 : " + m_Message;
                 Debug.Log("정답");
                }

                else 
                {
                    for (int a = 0; a < message.Length; a++) // 0부터 message의 길이만큼 반복
                      {   
                        if(!istyping)
                        {
                          yield break;
                        }
                       text.text = message.Substring(0, a+1);  // 0부터 a+1까지의 문자열을 가져옴
                       yield return new WaitForSeconds(speed); // speed만큼 대기
                      }

                }
  
            
        
        
        
    }




    IEnumerator Timeset(float time)
    {   
       
  isStart = true;

  while (time > 0)
  {
    if (!isStart) // istyping이 false인 경우, 코루틴 중지
    {
      yield break;
    }
    Debug.Log("타이머 시작");
    time -= Time.deltaTime; // 1초씩 감소
    time_text.text = "남은 시간 : " + Mathf.Round(time); // 소수점 반올림
    yield return null;
  }

  time_text.text = "시간 초과";
  Typing_start();
      

    }
 




    public void skip() {

            //만약 Typing_start함수가 실행되어 istyping이 true이면 typing함수를 중지시키고 text에 message를 넣어준다
           
                
                //StopAllCoroutines();
                  
                  istyping = false;
                 text.text = m_Message;
                //text.text = m_Message;
                

                
                
                
             
            
            
        
        
        
        
    


    }




    public void NextQuiz()
    {
      Typing_start();
      isStart = false;
      
    }
    

    public void QuizStart() {
     button.SetActive(false);
     // lang은 0~2까지의 랜덤한 정수
        lang = UnityEngine.Random.Range(0, 3);
        Number = UnityEngine.Random.Range(0, 3);
        value1 = LangArrays[Number].Mword; // value1은 LangArrays의 Number번째 요소의 Mword
        value2 = LangArrays[Number].Genre;
        apply.SetActive(true);
        next.SetActive(true);
        button.SetActive(false);
        Quiz_Round = true;

        //text2 활성화
        text2.gameObject.SetActive(true);
        point_text.gameObject.SetActive(true);
        QuizSetting();
        
        

        

    }


    public void QuizSetting() {

     System.Random rnd = new System.Random();

        // 0~4번째 요소를 랜덤하게 섞음
        for (int i = 4; i > 0; i--)
        {
            int j = rnd.Next(i + 1);
            int temp = value1[i];
            value1[i] = value1[j];
            value1[j] = temp;
        }

          m_Message2 = LanguageSingleton.instance.Langs[lang].langLocalize;
         text2.text =  m_Message2;

         

        
      Typing_start();
    } 





    public void SubmitInput(string arg0)
    {

          
           int lastElement = value1[value1.Length - 1];
           string correct = LanguageSingleton.instance.Langs[lang].value[lastElement].Replace("/", "\n");
           

            if (arg0 == correct)
        {
            Debug.Log("정답");
            point += 2;
            point_text.text = "획득 가능 포인트 : " + point;
            text.text = "정답입니다.";
         
            
        }
        else
        {
            Debug.Log("오답");
            point -= 4;
            point_text.text = "획득 가능 포인트 : " + point;
            text.text = "오답입니다.";
            Typing_start();
        }

    }

}

     



    








     
   
  


  

 

 

  

    






