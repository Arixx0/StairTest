
using Unity.VisualScripting;

public interface ISwitchbale
{
    bool IsActive { get; }
    void Activate();
    void Deactivate();

}

public interface IClickSpriteEvent
{
    void OnMouseDown();
}
