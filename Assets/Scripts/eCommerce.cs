using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eCommerce : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject button_obj;

    float time;


    private void Awake() {
        //button_obj.SetActive(false);
    }

   public void websiteLink()
    {
        Application.OpenURL("https://smartstore.naver.com/ymj_shop");
    }



    public void Exit()
    {
        button_obj.SetActive(true);
        restAnim();
    }

     
    //트리거 충돌시 버튼 활성화
    private void OnTriggerEnter(Collider other)
    {
        
            button_obj.SetActive(true);
            //코루틴 ui_effect 실행
            StartCoroutine(ui_effect());
            
        
    }

   

    //ui_effect 코루틴
    IEnumerator ui_effect()
    {   
        while(time < 1f)
        {
            button_obj.transform.localScale = Vector3.one * time;
            time += Time.deltaTime;
            yield return null;
        }
       

        time += Time.deltaTime;
         yield return null;
    
        
    }
    

    public void restAnim()
    {
        time = 0;
        button_obj.transform.localScale = Vector3.zero;
        button_obj.SetActive(false);
        
      
    }
    
}
