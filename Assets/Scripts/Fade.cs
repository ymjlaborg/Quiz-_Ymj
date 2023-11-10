using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{   
    private CanvasGroup cg; //캔버스 그룹
    public float fadeTime; //페이드 인 시간
    float accumTime = 0f; //누적 시간
    private Coroutine fadecor;
    

    public static Fade instance; //싱글톤
   
    // Start is called before the first frame update
   void Awake()
{
    if (instance == null) //instance가 비어있다면
    {
        instance = this; //자기 자신을 넣어줌
        DontDestroyOnLoad(gameObject); //씬이 바뀌어도 삭제되지 않음
    }
    else //instance에 이미 다른 오브젝트가 들어있다면
    {
        Destroy(gameObject); //자기 자신을 삭제
    }
  
    cg = gameObject.GetComponent<CanvasGroup>();
}
    // Update is called once per frame

  

   

   public void StartFadeIn()
{
    if (fadecor != null) //페이드 인 코루틴이 실행중이라면
    {
        StopCoroutine(fadecor); //코루틴 정지
        fadecor = null; //코루틴 초기화
    }
    fadecor = StartCoroutine(FadeInAndOut());
}

private IEnumerator FadeInAndOut()
{
    yield return new WaitForSeconds(0.5f); //0.5초 대기

    float startAlpha = cg.alpha;
    float endAlpha = 1f;

    accumTime = 0f; //누적 시간 초기화

    while (accumTime < fadeTime) //누적 시간이 페이드 인 시간보다 작다면
    {
        accumTime += Time.deltaTime; //누적 시간 증가
        
        cg.alpha = Mathf.Lerp(startAlpha, endAlpha, accumTime / fadeTime); //알파값 설정
        
        yield return null; //1프레임 대기
    }

    yield return new WaitForSeconds(3f); //3초 대기

    startAlpha = cg.alpha;
    endAlpha = 0f;

   accumTime = 0f; //누적 시간 초기화

   while (accumTime < fadeTime) //누적 시간이 페이드 아웃 시간보다 작다면
   {
       accumTime += Time.deltaTime; //누적 시간 증가
      
       cg.alpha = Mathf.Lerp(startAlpha, endAlpha, accumTime / fadeTime); //알파값 설정
      
       yield return null; //1프레임 대기
   }
}



 
}
