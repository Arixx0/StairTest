using UnityEngine;
using UnityEngine.UI;

public class InputEvaluator : MonoBehaviour
{
    public StageManager stageManager;
    public CharacterMove charActorMave;

    [SerializeField] private Button[] m_InGameControllButton;

    private int m_CurrentFloor;
    
    private void Start()
    {
        ResetGame();

        m_InGameControllButton[0].onClick.AddListener(() => { ClickLeftButton(); });
        m_InGameControllButton[1].onClick.AddListener(() => { ClickRightButton(); });
    }

  
    public void ClickRightButton()
    {
        CheckButton(false);
    }

    public void ClickLeftButton()
    {
        CheckButton(true);
    }

    private void CheckButton(bool isLeft)
    {
        // ���� ��� ��ü
        Stair stair = stageManager.GetNextStairObject(m_CurrentFloor);

        //���� (������)
        if(isLeft == stair.GetStairDirection())
        {
            Vector2 PlayerMovetargetPosition = stair.GetStairPosition();
            charActorMave.SucessAction(PlayerMovetargetPosition);
            m_CurrentFloor++; 
        }
        else //���� (��������)
        {
            charActorMave.FailAction();
        }

    }

    public void ResetGame()
    {
        m_CurrentFloor = 0;
    }

}
