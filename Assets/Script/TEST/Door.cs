using UnityEngine;

public class Door : MonoBehaviour, ISwitchbale
{
    private bool isActive;
    public bool IsActive => isActive;

    public void Activate()
    {
        isActive = true;
        Debug.Log("�� ����");

    }

    public void Deactivate()
    {
        isActive = false;
        Debug.Log("�� ����");
    }

}
