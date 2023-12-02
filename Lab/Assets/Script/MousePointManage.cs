using UnityEngine;

public class CenterMouseOnStart : MonoBehaviour
{
    void Start()
    {
        // 마우스 포인터를 정 중앙으로 이동
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // 초기 시점에서 마우스의 위치를 중앙으로 이동
        SetMouseToCenter();
    }

    void SetMouseToCenter()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // 마우스를 화면 정 가운데로 이동
        int centerX = Screen.width / 2;
        int centerY = Screen.height / 2;

        // ScreenToWorldPoint를 사용하여 마우스 위치를 세계 좌표로 변환
        Vector3 centerPosition = Camera.main.ScreenToWorldPoint(new Vector3(centerX, centerY, 0));
        transform.position = new Vector3(centerPosition.x, centerPosition.y, transform.position.z);
    }
}
