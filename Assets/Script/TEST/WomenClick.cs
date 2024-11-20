using UnityEngine;
using UnityEngine.EventSystems;

public class WomenClick : MonoBehaviour, IClickSpriteEvent
{
    [SerializeField] bool isClick;
    [SerializeField] Vector3 mousePos;
    private void Update()
    {
        if (isClick)
        {
            mousePos = Camera.main.ScreenToWorldPoint(new Vector3(
                Input.mousePosition.x,
                Input.mousePosition.y,
                Camera.main.transform.position.z * -1 // ī�޶��� z���� ������ ó��
            ));

            // z���� 0���� ���� (2D ���)
            mousePos.z = 0;

            // ������Ʈ ��ġ ������Ʈ
            gameObject.transform.position = mousePos;
        }
    }

    public void OnMouseDown()
    {
        isClick = true;
    }

    private void OnMouseUp()
    {
        isClick = false;
    }
}
