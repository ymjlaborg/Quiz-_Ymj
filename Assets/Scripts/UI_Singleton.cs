using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
[System.Serializable]
public class nothing  
{
    
}
public class UI_Singleton : MonoBehaviour
{
    #region singleton

    public TextMeshProUGUI uitext;

    public TextMeshProUGUI uitext2;

    public GameObject UI2;

    public Button UIbuttons;

    public AudioSource audioSource;

     
    static public UI_Singleton instance { get; private set; } // 자기 자신을 담을 변수

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

    // Update is called once per frame
    


   
}


