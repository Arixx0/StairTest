
using UnityEngine;

public interface IStair 
{
    void Refresh();

    void SetStairPositionAndParentTransform(Vector2 stairWorldPosition, Transform parentTransform);

    Vector2 GetStairPosition();
}

public interface IGameResetTarget
{
    void GameReset();
}


