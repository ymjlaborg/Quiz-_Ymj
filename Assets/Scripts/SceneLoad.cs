using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{   
   public string nextScene;
    public void OnTriggerEnter(Collider other)
    {   
      
        SceneManager.LoadScene(nextScene);
    }

   
}
