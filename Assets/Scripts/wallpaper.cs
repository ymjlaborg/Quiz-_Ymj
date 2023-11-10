using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallpaper : MonoBehaviour
{
    public AudioClip[] KR_audio; // 한국어 오디오
    public AudioClip[] EN_audio; // 영어 오디오
    public AudioClip[] JJ_audio; // 일본어 오디오
    public AudioClip[] audio1; // 오디오
    public int lang; //사용언어
 
     
   public void Start()
    {
        // Npc_Tuto.instance.lan을 lang에 넣어줌
    
    }

    public void Selecte_Langs(int lan)
    {
        if (lan == 0)
        {
            audio1 = KR_audio;
            lang = 0;
            Debug.Log("한국어");
        }
        else if (lan == 1)
        {
            audio1 = EN_audio;
            lang = 1;
            Debug.Log("영어");
        }
        else if (lan == 2)
        {
            audio1 = JJ_audio;
            lang = 2;
            Debug.Log("제주어");
        }
    }

    // 콜라이더가 트리거에 들어갔을때
    private void OnTriggerEnter(Collider other)
    {
        // 만약 트리거에 들어간 오브젝트의 태그가 Player라면
        //lang = Npc_Tuto.instance.lan;
        Selecte_Langs(lang);
        // 오디오 소스에 오디오를 넣어줌
        Debug.Log("들어옴");
        PlayAudio();
    }

    // 콜라이더가 트리거에서 나갔을때
    private void OnTriggerExit(Collider other)
    {
        // 만약 트리거에 들어간 오브젝트의 태그가 Player라면
        // 오디오 소스를 멈춤
        GetComponent<AudioSource>().Stop();
        // 오브젝트를 비활성화함
    }

    public void PlayAudio()
    {
        GetComponent<AudioSource>().clip = audio1[0];
        GetComponent<AudioSource>().Play();
    }
}