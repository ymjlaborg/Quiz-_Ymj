using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class testing_nav : MonoBehaviour
{   

    public Transform[] targetPoints; // 이동할 목표 위치들
    //private int currentTargetIndex = 0; // 현재 이동 중인 목표 위치의 인덱스
    private NavMeshAgent agent; // Navigation 컴포넌트
    public GameObject useer; 

    
   private Coroutine moveCoroutine;

    // Start is called before the first frame update
    
   private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }


private void OnTriggerEnter(Collider other)
{
    
        Debug.Log("Enter");
        moveCoroutine = StartCoroutine(MoveToTargetPoints());
    
}

private void OnTriggerExit(Collider other)
{
    
        StopCoroutine(moveCoroutine);
    
}

private IEnumerator MoveToTargetPoints()
{
    int currentTargetIndex = 0;
    Debug.Log("실행");
    while (true)
    {
        if (agent.pathPending)
            yield return null;

        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            currentTargetIndex++;
            if (currentTargetIndex >= targetPoints.Length)
                currentTargetIndex = 0;

            agent.SetDestination(targetPoints[currentTargetIndex].position);
        }

        yield return null;
    }
}



    
}
