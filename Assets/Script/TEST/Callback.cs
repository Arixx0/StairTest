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
                Debug.Log("�۾� �Ϸ�"); 
            });

            StartCoroutine(funtion(callback));

            yield return new WaitUntil(() => isComplete);
        }

        yield return new WaitForSeconds(1);
        
        Debug.Log("�۾� �Ϸ�");
    }

    

    private IEnumerator task1(Testallback callbacks)
    {
        Debug.Log("�۾�1����");
        callbacks?.Invoke();
        yield return null;
    }

    private IEnumerator task2(Testallback callbacks)
    {
        Debug.Log("�۾�2����");
        callbacks?.Invoke();
        yield return null;
    }

    private IEnumerator task3(Testallback callbacks)
    {
        Debug.Log("�۾�3����");
        callbacks?.Invoke();
        yield return null;
    }
}
