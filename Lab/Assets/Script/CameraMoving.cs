using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset = new Vector3(0, 0, 0);

    public float sensitivity = 5.0f;

    void Update()
    {
        transform.position = player.transform.position + offset;

        // ���콺 �Է� ����
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // ���� ȸ��
        transform.Rotate(Vector3.up * mouseX * sensitivity);

        // ���� ȸ�� (ī�޶� ���Ʒ��� ȸ��)
        transform.Rotate(Vector3.left * mouseY * sensitivity);

        // ī�޶��� ������ ���� (�ɼ�)
        float clampedX = Mathf.Clamp(transform.rotation.eulerAngles.x, -90f, 90f);
        transform.rotation = Quaternion.Euler(clampedX, transform.rotation.eulerAngles.y, 0f);
    }
}
