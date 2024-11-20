using System.Collections;
using UnityEngine;

public class CharacterMove : MonoBehaviour, IGameResetTarget
{
    [SerializeField] private SpriteRenderer m_SpriteRenderer;
    [SerializeField] private float nextMoveDuration;
    [SerializeField] private float playerPositionOffsetY = 0.35f;
    private Vector2 defaultPostion;
    private void Awake()
    {
        defaultPostion = transform.position;
    }

    public void SucessAction(Vector2 targetPosition)
    {
        StartCoroutine(MovePlayerCharacter(targetPosition));
    }
    public IEnumerator MovePlayerCharacter(Vector2 targetPosition)
    {
        float time = 0f;

        Vector3 startingPosition = transform.position;
        Vector3 targetingPosition = targetPosition;
        targetingPosition.y += playerPositionOffsetY;


        if (startingPosition.x < targetPosition.x)
        {
            m_SpriteRenderer.flipX = true;

        }
        else
        {
            m_SpriteRenderer.flipX = false;
        }

        while(time < nextMoveDuration)
        {
            time += Time.deltaTime;
            transform.position = Vector3.Lerp(startingPosition, targetingPosition, time / nextMoveDuration);
            yield return null;
        }
        transform.position = targetingPosition;
    }

    public void FailAction()
    {
        Debug.Log("게임종료");
    }

    public void GameReset()
    {
        transform.position = defaultPostion;
    }
}
