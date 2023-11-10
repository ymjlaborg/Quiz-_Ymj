using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Sound  // 컴포넌트 추가 불가능.  MonoBehaviour 상속 안 받아서. 그냥 C# 클래스.
{
    public string name;  // 곡 이름
    public AudioClip clip;  // 곡
}
public class SoundManager : MonoBehaviour
{
     #region singleton
    static public SoundManager instance;  // 자기 자신을 공유 자원으로. static은 씬이 바뀌어도 유지된다.

    private void Awake()  // 객체 생성시 최초 실행 (그래서 싱글톤을 여기서 생성)
    {
        if (instance == null)  // 단 하나만 존재하게끔
        {
            instance = this;  // 객체 생성시 instance에 자기 자신을 넣어줌
            DontDestroyOnLoad(gameObject);  // 씬 바뀔 때 자기 자신 파괴 방지
        }
        else
            Destroy(this.gameObject);  
    }
    #endregion singleton


    public Sound[] effectSounds;  // 효과음 오디오 클립들
    public Sound[] bgmSounds;  // BGM 오디오 클립들


    public AudioSource audioSourceBFM;  // BGM 재생기. BGM 재생은 한 군데서만 이루어지면 되므로 배열 X 
    public AudioSource[] audioSourceEffects;  // 효과음들은 동시에 여러개가 재생될 수 있으므로 'mp3 재생기'를 배열로 선언

    public string[] playSoundName;  // 재생 중인 효과음 사운드 이름 배열


    void Start()
    {
        playSoundName = new string[audioSourceEffects.Length];
    }

    public void PlaySE(string _name) // 효과음 재생 함수
    {
        for (int i = 0; i < effectSounds.Length; i++) // 효과음 사운드 배열을 돌면서
        {
            if(_name == effectSounds[i].name) // 매개변수로 받은 이름과 같은 이름의 사운드를 찾으면
            {
                for (int j = 0; j < audioSourceEffects.Length; j++) // 효과음 재생기 배열을 돌면서
                {
                    if(!audioSourceEffects[j].isPlaying) // 재생 중이지 않은 재생기를 찾으면
                    {
                        audioSourceEffects[j].clip = effectSounds[i].clip;  // 재생기에 사운드를 넣고
                        audioSourceEffects[j].Play(); // 재생
                        playSoundName[j] = effectSounds[i].name; // 재생 중인 효과음 사운드 이름 배열에 이름을 넣어줌
                        return;      
                    }
                }
                Debug.Log("모든 가용 AudioSource가 사용 중입니다."); // 모든 재생기가 재생 중이면
                return;
            }
        }
        Debug.Log(_name + "사운드가 SoundManager에 등록되지 않았습니다."); // 효과음 사운드 배열에 매개변수로 받은 이름과 같은 이름의 사운드가 없으면
    }

    public void PlayBGM(string _name)   // BGM 재생 함수
    {
        for (int i = 0; i < bgmSounds.Length; i++)  // BGM 사운드 배열을 돌면서
        {
            if (_name == bgmSounds[i].name) // 매개변수로 받은 이름과 같은 이름의 사운드를 찾으면
            {
                audioSourceBFM.clip = bgmSounds[i].clip; // BGM 재생기에 사운드를 넣고
                audioSourceBFM.Play(); // 재생
                return; 
            }
        }
        Debug.Log(_name + "사운드가 SoundManager에 등록되지 않았습니다."); // BGM 사운드 배열에 매개변수로 받은 이름과 같은 이름의 사운드가 없으면
    }

    public void StopAllSE() // 모든 효과음 재생기를 멈추는 함수
    {
        for (int i = 0; i < audioSourceEffects.Length; i++) 
        {
            audioSourceEffects[i].Stop();
        }
    }

    public void StopSE(string _name)
    {
        for (int i = 0; i < audioSourceEffects.Length; i++)
        {
            if(playSoundName[i] == _name)
            {
                audioSourceEffects[i].Stop();
                break;
            }
        }
        Debug.Log("재생 중인" + _name + "사운드가 없습니다. ");
    }
}
