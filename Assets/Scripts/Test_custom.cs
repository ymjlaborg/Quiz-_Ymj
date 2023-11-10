using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Test_custom : MonoBehaviour
{   

    private int langIndex = 0; // 언어 인덱스 변수

    public void SaveLangIndex(int index)
    {
        langIndex = index;
        PlayerPrefs.SetInt("LangIndex", langIndex);
        PlayerPrefs.Save();
        LoadLangIndex();
    }

    public int LoadLangIndex() // 언어 인덱스 불러오기
    {
        if (PlayerPrefs.HasKey("LangIndex")) // 저장된 값이 있는지 확인
        {
            langIndex = PlayerPrefs.GetInt("LangIndex");
            Debug.Log("langIndex load : " + langIndex );
        }
        else
        {
            // 기본값 설정 (예: 0)
            langIndex = 0;
            PlayerPrefs.SetInt("LangIndex", langIndex);
            PlayerPrefs.Save();
        }

        return langIndex; // 언어 인덱스 반환
    }
}
