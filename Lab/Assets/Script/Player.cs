using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool canMoving = true;
    private bool isJumping = false;

    private Rigidbody rb;

    public float speed = 1f;
    public float runSpeed = 2f;
    public float jumpHeight = 2f;

    public KeyCode forward;
    public KeyCode backward;
    public KeyCode left;
    public KeyCode right;
    public KeyCode run;
    public KeyCode jump;

    public float sensitivity = 5.0f;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = new Vector3(0f, -0.5f, 0f);
    }

    // Update is called once per frame
    void Update()
    {

        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up * mouseX * sensitivity);


        if (canMoving)
        {
            float currentSpeed = Input.GetKey(run) ? runSpeed : speed;

            if (Input.GetKey(forward))
            {
                transform.Translate(0, 0, currentSpeed * Time.deltaTime);
            }

            if (Input.GetKey(backward))
            {
                transform.Translate(0, 0, -currentSpeed * Time.deltaTime);
            }

            if (Input.GetKey(left))
            {
                transform.Translate(-currentSpeed * Time.deltaTime, 0, 0);
            }

            if (Input.GetKey(right))
            {
                transform.Translate(currentSpeed * Time.deltaTime, 0, 0);
            }

            if (Input.GetKeyDown(jump) && !isJumping)
            {
               JumpSystem();
            }
        }
    }

    void JumpSystem()
    {
        if (canMoving)
        {
            isJumping = true;
            rb.AddForce(Vector3.up * Mathf.Sqrt(2 * jumpHeight * Mathf.Abs(Physics.gravity.y)), ForceMode.VelocityChange);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
}
