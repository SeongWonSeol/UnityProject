using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset = new Vector3(0, 0, 0);

    public float sensitivity = 5.0f;

    void Update()
    {
        transform.position = player.transform.position + offset;

        // 마우스 입력 감지
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // 수평 회전
        transform.Rotate(Vector3.up * mouseX * sensitivity);

        // 수직 회전 (카메라만 위아래로 회전)
        transform.Rotate(Vector3.left * mouseY * sensitivity);

        // 카메라의 각도를 제한 (옵션)
        float clampedX = Mathf.Clamp(transform.rotation.eulerAngles.x, -90f, 90f);
        transform.rotation = Quaternion.Euler(clampedX, transform.rotation.eulerAngles.y, 0f);
    }
}
