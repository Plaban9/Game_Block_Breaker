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

    private Vector3 _initialScale;
    private bool _isInTurretMode;
    private int _currentBullets;
    [SerializeField]
    private Sprite _turretPaddleSprite;
    private Sprite _defaultSprite;
    [SerializeField]
    private GameObject _bullets;

    [SerializeField]
    private Transform _leftBulletSpawn;
    [SerializeField]
    private Transform _rightBulletSpawn;

    [SerializeField]
    private bool _hasSizeIncreased;

    [SerializeField]
    private bool _isTopTurret;

    private void Awake()
    {
        if (isKeyboardMovement)
        {
            paddlePosition = this.transform.position;
        }

        _initialScale = this.transform.localScale;
        _isInTurretMode = false;
        _hasSizeIncreased = false;
        _currentBullets = 0;
        _defaultSprite = GetComponent<SpriteRenderer>().sprite;
    }

    // Use this for initialization
    void Start()
    {
        //paddlePosition = this.transform.position;
        ball = FindObjectOfType<Ball>();
        sfxVolume = MusicPlayer.sfxVolume;
    }

    // Update is called once per frame
    void Update()
    {
#if DEBUG
        if (!_isTopTurret)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                HandlePowerUp(PowerUpType.ATTACH_GUN);
            }
            else if (Input.GetKeyDown(KeyCode.I))
            {
                HandlePowerUp(PowerUpType.INCREASE_SIZE);
            }
        }
#endif

        HandleTurret();
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

    private void HandleTurret()
    {
        if (_isTopTurret)
            return;

        if (_isInTurretMode)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (_currentBullets > 0)
                {
                    _currentBullets--;

                    Instantiate(_bullets, _leftBulletSpawn.position, Quaternion.identity, null);
                    Instantiate(_bullets, _rightBulletSpawn.position, Quaternion.identity, null);

                }
                else
                {
                    _isInTurretMode = true;
                    GetComponent<SpriteRenderer>().sprite = _defaultSprite;
                }
            }
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PowerUp"))
        {
            HandlePowerUp(collision.transform.GetComponent<PowerType>().PowerUpType);
            Destroy(collision.gameObject);
        }
    }

    private void HandlePowerUp(PowerUpType powerUpType)
    {
        if (_isTopTurret)
            return;

        switch (powerUpType)
        {
            case PowerUpType.INCREASE_SIZE:
                if (!_hasSizeIncreased)
                    StartCoroutine(nameof(IncreaseSizePowerUp), 10f);
                break;
            case PowerUpType.ATTACH_GUN:
                EnableTurret();
                break;
        }
    }

    private IEnumerator IncreaseSizePowerUp(float duration)
    {
        transform.localScale = new Vector3(transform.localScale.x * 1.25f, transform.localScale.y, transform.localScale.z);
        _hasSizeIncreased = true;
        yield return new WaitForSeconds(duration);
        _hasSizeIncreased = false;
        transform.localScale = _initialScale;
    }

    private void EnableTurret()
    {
        if (_isInTurretMode)
        {
            _isInTurretMode = true;
            _currentBullets += 10;
        }
        else
        {
            _isInTurretMode = true;
            _currentBullets = 10;
            GetComponent<SpriteRenderer>().sprite = _turretPaddleSprite;
        }
    }
}