using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teleport : MonoBehaviour
{
    // Start is called before the first frame update
    //플레이어가 닿았을경우

    //public 버튼
    public Button buttons;

    public GameObject UI;

    public GameObject[] pos;

    public GameObject player;


    public void Start()
    {
    
     
        buttons.onClick.AddListener(() =>
        {
            if (UI.activeSelf == false)
            {
                UI.SetActive(true);
            }
            else
            {
                UI.SetActive(false);
            }
        });

              
       
       
    }

    


       



   
}
