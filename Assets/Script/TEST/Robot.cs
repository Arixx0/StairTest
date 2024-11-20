using System.Collections;
using UnityEngine;

public class Robot : MonoBehaviour, ISwitchbale
{
    private bool isActive;
    public bool IsActive => isActive;

    public void Activate()
    {
        isActive = true;
        StartCoroutine(DestoryRobot(3f));
    }

    public void Deactivate()
    {
        if(gameObject.activeSelf == false)
        {
            return;
        
        }
        isActive = false;
        Debug.Log("����");
    }

    IEnumerator DestoryRobot(float leftTimer)
    {
        yield return null;
        
        while (leftTimer > 0)
        {
            Debug.Log($"{leftTimer} ��");
            leftTimer--;
            yield return new WaitForSeconds(1f);
        }

        Debug.Log("����");
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }


}
