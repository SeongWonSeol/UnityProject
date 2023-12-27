using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    private AudioSource playerAudio;

    [Header("Set in Inspector(edit mode only)")]
    public float gravityModifier = 1.0f;

    [Header("Set in Inspector")]
    public float jumpForce = 10.0f;

    [Header("Set Dynamically")]
    public bool isOnGround = true;
    public bool gameOver = false;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public int jumpIndex = 0;
    public bool isRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

        if (Physics.gravity.magnitude < 15)
            Physics.gravity *= gravityModifier;
            //playerRb.AddForce(Vector3.up * 1000);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver && jumpIndex < 2) 
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            jumpIndex += 1;
            if (jumpIndex == 2)
            {
                isOnGround = false;
            }
        }

        if (Input.GetKey(KeyCode.LeftShift) && !isRunning)
        {
            isRunning = true;
            playerAnim.SetFloat("Speed_f", 1f);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isRunning = false;
            playerAnim.SetFloat("Speed_f", 0.25f);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
            jumpIndex = 0;
        }

        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over!");
            playerAnim.SetInteger("DeathType_int", 1);
            playerAnim.SetBool("Death_b", true);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
        
    }
}
