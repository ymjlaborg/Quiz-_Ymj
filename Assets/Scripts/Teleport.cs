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

    public void findeplayer()
    {
        
       GameObject player = GameObject.FindWithTag("Player");
         if (player != null) {
    // Player 오브젝트를 찾았으므로 여기에 로직을 추가합니다.
           } else {
                   Debug.Log("Player 오브젝트를 찾을 수 없습니다.");
                   } 
 
        PlayerSingleton.instance.test = player;
    }


    public void TeleportPlayer(int poi)
    {
        findeplayer();
        Debug.Log("플레이어 위치 이동");
        PlayerSingleton.instance.TeleportPlayer(pos[poi].transform.position);


    
    }
       



   
}
