using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingSceneController : MonoBehaviour
{
    
    static string nextScene;
    
    [SerializeField]
    Image progressBar;

    private void Start()
    {
        StartCoroutine(LoadScene());
    }

    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene("LoadingScene");
    }

    IEnumerator LoadScene()
    {
        //PlayerSingleton.instance.TeleportPlayer(new Vector3(0, 1, 0));
        yield return null;
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;
        float timer = 0.0f;
        while (!op.isDone)
        {
            yield return null;
            timer += Time.deltaTime;
            if (op.progress < 0.9f)
            {
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, op.progress, timer);
                if (progressBar.fillAmount >= op.progress)
                {
                    timer = 0f;
                }
            }
            else
            {   
                //로딩이 끝나면 5초간 로딩바가 차도록
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, 1f, timer/2f);
                if (progressBar.fillAmount == 1.0f)
                {
                    //로딩이 끝나면 씬 활성화
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }
    }
}
