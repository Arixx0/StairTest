using UnityEngine;

public class Switch : MonoBehaviour
{
    public MonoBehaviour obejct;
    public ISwitchbale Client;

    private void Awake()
    {
        Client = obejct as ISwitchbale;
    }

    public void UsingObejct()
    {
        if (Client.IsActive)
        {
            Client.Deactivate();
        }
        else if(!Client.IsActive)
        {
            Client.Activate();
        }
    }
}
