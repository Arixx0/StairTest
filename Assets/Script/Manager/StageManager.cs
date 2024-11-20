using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField] private PoolManager m_poolManager;
    [SerializeField] private Transform m_stageStartPoint;
    [SerializeField] private Transform m_PoolTransform;
    [SerializeField] private int m_TotalStairCount;
    [SerializeField] private StairData stairData;

    private const float stiarWitdhInterval = 1.75f;
    private const float stiarHeightInterval = 0.8f;

    private Vector2 m_StartStairPosition;
    private Vector2 m_CurrentStairPosition;
    private Vector2 m_NextStairPosition;

    private Queue<Stair> m_StairQueue = new();
    private List<Stair> m_StairList = new();
    private Dictionary<int, Vector2> StairPositionDictionary = new();

    private void Start()
    {
        ReFreshStartPosition();
        MakeStageStair();
    }

    private void ReFreshStartPosition()
    {
        m_StartStairPosition = m_stageStartPoint.transform.position;
    }

    bool leftPoint;
    public void MakeStageStair() // 게임스타트에 옮겨야함
    {
        int totalCount = 0;
        bool isLeft = false;
        int sameDirectionMakeCount = 0;

        while (totalCount < m_TotalStairCount)
        {
            Stair stair = m_poolManager.GetStairObject();
            stair.Refresh();
            stair.SetStairSprite(stairData.GetStairImage());
            stair.SetStairPositionAndParentTransform(m_StartStairPosition, m_PoolTransform);
            stair.RegistStairInformation(totalCount, leftPoint);

            if (leftPoint)
            {
                leftPoint = false;
            }

            StairPositionDictionary.Add(totalCount, stair.transform.position);

            m_StairQueue.Enqueue(stair);
            m_StairList.Add(stair);

            if (totalCount > 0)
            {
                float randomValue = Random.Range(0f, 100f);

                if (randomValue < 20 && sameDirectionMakeCount <= 5)
                {
                    sameDirectionMakeCount = 0;
                    isLeft = !isLeft;
                    leftPoint = true;
                }
                else
                {
                    sameDirectionMakeCount++;
                }

                if (sameDirectionMakeCount > 5)
                {
                    sameDirectionMakeCount = 0;
                    isLeft = !isLeft;
                    leftPoint = true;
                }

            }


            

            if (isLeft)
            {
                m_StartStairPosition.x -= stiarWitdhInterval;
            }
            else
            {
                m_StartStairPosition.x += stiarWitdhInterval;
            }

            m_StartStairPosition.y += stiarHeightInterval;


            totalCount++;
        }
    }

    public Vector2 GetNextStairPosition(int playerCurrentFloor)
    {
        return StairPositionDictionary[playerCurrentFloor + 1];
    }

    public Dictionary<int, Vector2> GetStairInformationDictionary()
    {
        return StairPositionDictionary;
    }

    public Stair GetNextStairObject(int index)
    {
        return m_StairList[index];
    }
}
