using System.Collections;
using UnityEditor.SceneManagement;
using UnityEngine;

public class TreeSpanwer : MonoBehaviour
{
    private Scriptable m_treeScriptableData;

    private int m_SpawnCount = 200;
    private float m_SpawnInterval = 0.25f;
    private WaitForSeconds m_SpawnWaitTime;
    void Start()
    {
        m_treeScriptableData = Resources.Load<Scriptable>("Sciptable/TreeData");
        m_SpawnWaitTime = new WaitForSeconds(m_SpawnInterval);

        StartCoroutine(StartSpawn());
        
    }

    IEnumerator StartSpawn()
    {
        int spawnCount = 0;
        
        while (spawnCount < m_SpawnCount)
        {
            float posX = Random.Range(-6f, 6f);
            float posY = Random.Range(-6f, 6f);

            GameObject treeObj = new GameObject("Tree", typeof(SpriteRenderer), typeof(Tree));
            treeObj.transform.localScale = new Vector3(5, 5, 0);
            treeObj.transform.SetParent(transform.Find("TreeRoom"));
            //treeObj.GetComponent<Tree>().SetTreeSpirteAndPostion(m_treeScriptableData.treeSprite, new Vector2(posX, posY), spawnCount);

            spawnCount++;
            yield return m_SpawnWaitTime;
        }
    }

}
