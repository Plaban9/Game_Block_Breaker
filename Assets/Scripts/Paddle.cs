using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour
{

    // Public Variables
    #region
    public float minX = 0.5f;
    public float maxX = 15.5f;
    public static bool isSimulation;
    public AudioClip hitSound;
    public static float sfxVolume = 1.0f;
    #endregion

    // For Testing and Simulation
    private Ball ball = null;

    [SerializeField]
    private float _magnitude = 1.0f;

    private float mousePositionX;
    private Vector3 paddlePosition;

    [SerializeField]
    private bool isKeyboardMovement = false;

    private void Awake()
    {
        if (isKeyboardMovement)
        {
            paddlePosition = this.transform.position;
        }
    }

    // Use this for initialization
    void Start()
    {
        //paddlePosition = this.transform.position;
        ball = GameObject.FindObjectOfType<Ball>();
        sfxVolume = MusicPlayer.sfxVolume;

    }

    // Update is called once per frame
    void Update()
    {
        if (isSimulation)
        {
            // For Testing
            MoveWithBall();
        }
        else if (isKeyboardMovement)
        {
            MoveWithKeyboard();
        }
        else
        {
            mousePositionX = (Input.mousePosition.x / Screen.width) * 16;
            MoveWithMouse();
        }
    }

    void MoveWithMouse()
    {
        paddlePosition.Set(Mathf.Clamp(mousePositionX, minX, maxX), this.transform.position.y, this.transform.position.z);
        this.transform.position = paddlePosition;
    }

    void MoveWithBall()
    {
        paddlePosition.Set(Mathf.Clamp(ball.transform.position.x, minX, maxX), this.transform.position.y, this.transform.position.z);
        this.transform.position = paddlePosition;
    }

    void MoveWithKeyboard()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");

        paddlePosition.Set(Mathf.Clamp(paddlePosition.x + (horizontalMovement * _magnitude * Time.deltaTime), minX, maxX), this.transform.position.y, this.transform.position.z);
        this.transform.position = paddlePosition;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (ball.GetLaunchStatus())
        {
            AudioSource.PlayClipAtPoint(hitSound, transform.position, sfxVolume);
        }
    }
}