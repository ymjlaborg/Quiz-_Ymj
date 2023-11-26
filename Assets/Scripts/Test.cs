using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator Transition;
    public GameObject Particle;

    public AudioSource audioSource;

    public AudioClip audioClip;

     public void LevelStart() // 스태틱 함수로 만들어서 다른 스크립트에서 호출 가능하게 만듦 
    {   
       

            gameObject.SetActive(true);
            Transition.SetBool("Start&End", true);
            //자기 자신의 오브젝트를 비활성화 시킨다.
            //3초후 QuizStart 함수를 실행한다.
            Invoke("QuizStart", 3f); //
            Particle.SetActive(false);
            audioSource.PlayOneShot(audioClip);
            
            
        
        

        

    }


    public async void QuizStart()
    {
        Transition.SetBool("Start&End", false);
        //1초후 Npc_Tuto.instance.QuizStart(); 실행한다.
        Npc_Tuto.instance.QuizStart();
        Particle.SetActive(true);
    }
}
