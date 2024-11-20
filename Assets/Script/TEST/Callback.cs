using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Callback : MonoBehaviour
{
    public delegate void Testallback();

    private Queue<Func<Testallback, IEnumerator>> funtionQue = new();
    
    void Start()
    {
        funtionQue.Enqueue(task1);
        funtionQue.Enqueue(task2);
        funtionQue.Enqueue(task3);

        PlayAsync();
    }

    private void PlayAsync()
    {
        StartCoroutine(playAsync());
    }

    private IEnumerator playAsync()
    {
        yield return null;

        while(funtionQue.Count > 0)
        {
            var funtion = funtionQue.Dequeue();
            bool isComplete = false;

            Testallback callback = new Testallback(() => 
            { 
                isComplete = true; 
                Debug.Log("작업 완료"); 
            });

            StartCoroutine(funtion(callback));

            yield return new WaitUntil(() => isComplete);
        }

        yield return new WaitForSeconds(1);
        
        Debug.Log("작업 완료");
    }

    

    private IEnumerator task1(Testallback callbacks)
    {
        Debug.Log("작업1실행");
        callbacks?.Invoke();
        yield return null;
    }

    private IEnumerator task2(Testallback callbacks)
    {
        Debug.Log("작업2실행");
        callbacks?.Invoke();
        yield return null;
    }

    private IEnumerator task3(Testallback callbacks)
    {
        Debug.Log("작업3실행");
        callbacks?.Invoke();
        yield return null;
    }
}
