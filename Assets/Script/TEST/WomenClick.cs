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
                Camera.main.transform.position.z * -1 // 카메라의 z값을 음수로 처리
            ));

            // z값을 0으로 고정 (2D 평면)
            mousePos.z = 0;

            // 오브젝트 위치 업데이트
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
