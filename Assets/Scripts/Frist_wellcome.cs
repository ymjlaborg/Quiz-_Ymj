using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Frist_wellcome : MonoBehaviour
{   



    public Animator animator;

    public int[] value1; // value1 배열
   
    
    public TextMeshProUGUI text;
    string m_Message; // 텍스트를 저장할 변수

    


  public void Start()
    {    
        
         //애니메이터 파라미터 Start를 true로 바꿔준다.
        animator.SetBool("Start", true); // 애니메이터 파라미터 Start를 true로 바꿔준다.
        //6초후 timeOut함수를 실행한다.
        Invoke("TimeOut", 6f);

    

    }

    

    public void TimeOut()
    {   
        int lang = 3;
        int i = 0;
      if (i < value1.Length) {
            
            m_Message = LanguageSingleton.instance.Langs[lang].value[value1[i]].Replace("/", "\n");
            Debug.Log("m_Message = " + m_Message);
            StartCoroutine(Typing(text, m_Message, 0.9f));
            i++;


      }
     

    }
    

      IEnumerator Typing(TextMeshProUGUI text, string message, float speed)
    {   
      
        for (int a = 0; a < message.Length; a++) // 0부터 message의 길이만큼 반복
        {   
            text.text = message.Substring(0, a+1);  // 0부터 a+1까지의 문자열을 가져옴
            yield return new WaitForSeconds(speed); // speed만큼 대기
        }
        
        
        
    }


    

  
}
