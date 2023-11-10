using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class NLang
{
    public string lang, langLocalize;
    public List<string> value = new List<string>();
}

public class NewLanguageSingleton : MonoBehaviour
{
    public static NewLanguageSingleton instance;
    

      // 간단하게 2개 언어
    public List<string> koreanDialogues = new List<string>();
    public List<string> englishDialogues = new List<string>();
    

      private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else Destroy(this);

        InitLang();
        
       // 대사 초기화
       if (koreanDialogues.Count == 0 && englishDialogues.Count == 0)
       {
           string[] ko_dialogueList = {"안녕하세요.", "바나나 먹고싶다.", "김치 좋아하세요?", "안녕히 가세요.", "어서오세요.", "잘가세요."};
           string[] en_dialogueList = {"Hello.", "I want to eat a banana.", "Do you like kimchi?", "Goodbye.", "Welcome.", "Bye."};

           for (int i = 0; i < ko_dialogueList.Length; ++i)
           {
               SaveDialogue("Korean", ko_dialogueList[i]);
               SaveDialogue("English", en_dialogueList[i]);
           }
       }
   }

   void InitLang()
   {
      int langIndex = PlayerPrefs.GetInt("LangIndex", -1);
      int systemIndex = Langs.FindIndex(x => x.lang.ToLower() == Application.systemLanguage.ToString().ToLower());
      if (systemIndex == -1) systemIndex = 0;
      int index = langIndex == -1 ? systemIndex : langIndex;

      LoadDialogues("Korean", koreanDialogues);
      LoadDialogues("English", englishDialogues);

      SetLangIndex(index); 
   }

   void LoadDialogues(string language, List<string> dialogues)
   {
       int index = 0;
       while (true)
       {
          string key = $"Dialogue_{language}_{index}";
          if (!PlayerPrefs.HasKey(key))
              break;

          dialogues.Add(PlayerPrefs.GetString(key));
          index++;
       }
   }

   public void SaveDialogue(string language, string dialogue)
   {
     int index;
     if (language == "Korean")
         index= koreanDialogues.Count;
     else // English
         index= englishDialogues.Count;

     string key=$"Dialogue_{language}_{index}";
     
     PlayerPrefs.SetString(key,dialogue);
     
     // If you want to save the changes immediately
     // PlayerPrefs.Save();
   }

   public void SetLangIndex(int index)
   {
      curLangIndex = index;  
      PlayerPrefs.SetInt("LangIndex", curLangIndex);  

      LocalizeChanged();  //텍스트들 현재 언어로 변경
      LocalizeSettingChanged();   //드랍다운의 value변경
  }

  public string GetDialogue(int index)
  {
    List<string> currentLangDialogues = (curLangIndex == 0) ? koreanDialogues : englishDialogues;

    if (index < 0 || index >= currentLangDialogues.Count)
    {
        Debug.LogError("Invalid dialogue index");
        return null;
    }

    return currentLangDialogues[index];
}

public event System.Action LocalizeChanged = () => {};  
public event System.Action LocalizeSettingChanged = () => {};

public int curLangIndex;    
public List<Lang> Langs;    


}
