using UnityEngine;
using UnityEngine.Pool;

public class Stair : MonoBehaviour, IStair
{
    private IObjectPool<Stair> m_StairPool;
    private SpriteRenderer m_SpriteRenderer;

    [Header("Check Information")]
    [Space]
    [SerializeField] private int m_floor;
    [SerializeField] private bool isLeft;
    

    public void Refresh()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void RegisterObjectInPool(IObjectPool<Stair> obj)
    {
        m_StairPool = obj;
    }

    public void ReturnObjectInPool()
    {
        m_StairPool.Release(this);
    }

  
    public Vector2 GetStairPosition()
    {
        return transform.position;
    }

    public void SetStairPositionAndParentTransform(Vector2 stairWorldPosition, Transform parentTransform)
    {
        transform.position = stairWorldPosition;
        transform.SetParent(parentTransform);
    }

    public void SetStairSprite(Sprite image)
    {
        m_SpriteRenderer.sprite = image;
    }

    public void RegistStairInformation(int floorCount, bool isLeft)
    {
        m_floor = floorCount;
        this.isLeft = isLeft;
    }

    public bool GetStairDirection()
    {
        return this.isLeft;
    }
}
