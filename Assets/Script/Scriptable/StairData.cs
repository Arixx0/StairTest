using UnityEngine;

[CreateAssetMenu(fileName = "StairData", menuName = "Scriptable Objects/StairData")]
public class StairData : ScriptableObject
{
    [Header("Insert Stiar IMG File")]
    [Space]
    public Sprite stiarIMG;

    public Sprite GetStairImage()
    {
        return stiarIMG;
    }
}
