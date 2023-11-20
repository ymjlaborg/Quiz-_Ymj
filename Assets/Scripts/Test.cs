using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator Transition;

     public void LevelStart() // 스태틱 함수로 만들어서 다른 스크립트에서 호출 가능하게 만듦 
    {   
       

    
            Transition.SetTrigger("Start");
            Transition.SetBool("Return", true);
            
        
        

        

    }
}
