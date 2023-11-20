using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Level : MonoBehaviour
{
    
    public Animator Transition;

     private bool isFirstCall = true;

    public float TransitionTime = 1f;

    // Update is called once per frame
    public void LevelStart() // 스태틱 함수로 만들어서 다른 스크립트에서 호출 가능하게 만듦 
    {   
       

    
            Transition.SetTrigger("Start");
            Transition.SetBool("Return", true);
            
        
        

        

    }


    public void Update()
    {
       
    }


    // public void OnTransitionComplete()
    // {   
    //     Debug.Log("OnTransitionComplete");
    //     Transition.SetBool("Return", true);
    // }
}
