using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class PoolManager : MonoBehaviour
{
    [SerializeField] private GameObject m_StairPrefab;

    private IObjectPool<Stair> m_StairPool;

    private void Awake()
    {
        m_StairPool = new ObjectPool<Stair>(CreateStair, OnGetStairObject, ReturnStairObject, DestoryStairObject, maxSize: 100);
    }
    
    private Stair CreateStair()
    {
        Stair stair = Instantiate(m_StairPrefab).GetComponent<Stair>();
        stair.RegisterObjectInPool(m_StairPool);
        return stair;
    }

    private void OnGetStairObject(Stair obj)
    {
        obj.gameObject.SetActive(true);
    }

    private void ReturnStairObject(Stair obj)
    {
        obj.gameObject.SetActive(false);
    }

    private void DestoryStairObject(Stair obj)
    {
        Destroy(obj.gameObject);
    }

    public Stair GetStairObject()
    {
        return m_StairPool.Get();
    }


}
