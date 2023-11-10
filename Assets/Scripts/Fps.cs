using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fps : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        //fps 제한 해제
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 120;
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
