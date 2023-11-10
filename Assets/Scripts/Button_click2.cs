using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Button_click2 : MonoBehaviour
{  



    public Image languageImage;
    public Image[] selectionImages; // selectionImage 배열

    public Sprite koreanSprite;
    public Sprite englishSprite;
    public Sprite jejuSprite;

    public Button button;

    public GameObject UI;

    private int selectedLanguageIndex = 0; // 선택된 언어 인덱스

    private void Start()
    {
        // 기본값으로 한국어 이미지로 설정
        languageImage.sprite = koreanSprite;

        for (int i = 0; i < selectionImages.Length; i++) // 
        {
            if (i == 0)
                selectionImages[i].sprite = koreanSprite;
            else if (i == 1)
                selectionImages[i].sprite = englishSprite;
            else if (i == 2)
                selectionImages[i].sprite = jejuSprite;

            // 선택된 언어만 회색으로 변경
            SetSelectionColor(selectionImages[i], i == selectedLanguageIndex ? Color.gray : Color.white); // 선택된 언어만 회색으로 변경
        }

         button.onClick.AddListener(() => {  
            
          //만약 ui가 비활성화 상태라면
            Check_UI();
            Debug.Log("클릭함");
           
        });
    }

    public void Check_UI()
    {
        //만약 UI 오브젝트가 비활성화 상태라면
        //activeSelf : 활성화 상태인지 아닌지 확인
        if(UI.activeSelf == false){
            UI.SetActive(true);
            Debug.Log("UI가 활성화 되었습니다.");
        }
        else{
            UI.SetActive(false);
            Debug.Log("UI가 비활성화 되었습니다.");
            //languageImage.sprite가 하얀색이 되어야함
            SetSelectionColor(languageImage, Color.white);
        }
    }

    private void SetSelectionColor(Image image, Color color)
    {
         var material = new Material(image.material);
    material.SetColor("_Color", color);
    image.material = material;
    }

   public void ChangeLanguage(int languageIndex) 
   {
       switch (languageIndex)
       {
           case 0: 
               languageImage.sprite = koreanSprite;
               Debug.Log("한국어");
               break;

           case 1: 
               languageImage.sprite = englishSprite;
                Debug.Log("영어");
               break;

           case 2: 
               languageImage.sprite = jejuSprite;
                Debug.Log("제주어");
               break;

           default:
               Debug.LogWarning("Invalid language index");
               break;
       }

      SetSelectionColor(languageImage, Color.gray); // 선택된 언어의 Language 이미지를 회색으로 변경

      for (int i=0; i<selectionImages.Length; ++i) {
          SetSelectionColor(selectionImages[i], i==languageIndex ? Color.gray : Color.white);
      }
      
      selectedLanguageIndex=languageIndex; 
    }
}

