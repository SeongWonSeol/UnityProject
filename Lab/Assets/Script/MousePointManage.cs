using UnityEngine;

public class CenterMouseOnStart : MonoBehaviour
{
    void Start()
    {
        // ���콺 �����͸� �� �߾����� �̵�
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // �ʱ� �������� ���콺�� ��ġ�� �߾����� �̵�
        SetMouseToCenter();
    }

    void SetMouseToCenter()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // ���콺�� ȭ�� �� ����� �̵�
        int centerX = Screen.width / 2;
        int centerY = Screen.height / 2;

        // ScreenToWorldPoint�� ����Ͽ� ���콺 ��ġ�� ���� ��ǥ�� ��ȯ
        Vector3 centerPosition = Camera.main.ScreenToWorldPoint(new Vector3(centerX, centerY, 0));
        transform.position = new Vector3(centerPosition.x, centerPosition.y, transform.position.z);
    }
}
