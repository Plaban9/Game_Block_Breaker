using UnityEngine;
using System.Collections;
using System;
using Effects.Camera;
using Managers;

public class Brick : MonoBehaviour
{
    // Public Variables
    #region
    public Sprite[] damageSprites;
    public static int numBreakableBricks = 0;
    public AudioClip hitSound;
    public AudioClip destroySound;
    public GameObject particleEmission;
    public static float sfxVolume = 1.0f;
    #endregion

    private int timesHit;
    private LevelManager levelManager;
    private bool isBreakable;


    public const int BRICK_HIT_SCORE = 10;
    public const int BRICK_DESTROY_SCORE = 50;
    public const int ALL_BRICK_DESTROY_SCORE = 100;

    [SerializeField]
    private GameObject _increaseSizePowerUp;
    [SerializeField]
    private GameObject _bulletPowerUp;

    // Use this for initialization
    void Start()
    {
        timesHit = 0;
        levelManager = FindObjectOfType<LevelManager>();
        isBreakable = (this.tag == "Breakable");
        sfxVolume = MusicPlayer.sfxVolume;

        // Keep track of breakable objects 
        if (isBreakable)
        {
            ++numBreakableBricks;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //OnCollisionEnter2D();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);

            if (isBreakable)
            {
                HandleHits();
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isBreakable)
        {
            HandleHits();
        }

        else
        {
            AudioSource.PlayClipAtPoint(hitSound, transform.position, sfxVolume);
        }
    }

    void HandleHits()
    {
        ++timesHit;

        //maximum no. of hits is damageSprites.Length + 1.
        //TODO Emit particle from bricks

        if (timesHit >= (damageSprites.Length + 1))
        {
            GameObject particleColor = Instantiate(particleEmission, gameObject.transform.position, Quaternion.identity) as GameObject;
            particleColor.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
            AudioSource.PlayClipAtPoint(destroySound, transform.position, sfxVolume);
            --numBreakableBricks;
            if (ScoreManager.Instance != null)
                ScoreManager.Instance.AddScore(BRICK_DESTROY_SCORE);
            levelManager.BrickDestroyed();
            SpawnPowerUp();
            Destroy(gameObject);
        }

        else
        {
            AudioSource.PlayClipAtPoint(hitSound, transform.position, sfxVolume);
            if (ScoreManager.Instance != null)
                ScoreManager.Instance.AddScore(BRICK_HIT_SCORE);
            LoadSprites();
        }


        try
        {
            this.transform.GetComponent<CameraShake>().Shakecamera();
        }
        catch (Exception ignored)
        {

        }

        print("Bricks Left: " + numBreakableBricks);
    }

    private void SpawnPowerUp()
    {
        int chance = UnityEngine.Random.Range(0, 101);

        if (chance < 20) // 20% chance
        {
            GameObject spawnedObject = null;

            switch (UnityEngine.Random.Range(0, 2))
            {
                case 0:
                    spawnedObject = Instantiate(_increaseSizePowerUp);

                    break;

                case 1:
                    spawnedObject = Instantiate(_bulletPowerUp);
                    break;
            }

            spawnedObject.transform.position = this.transform.position;
        }
    }

    void LoadSprites()
    {
        //int spriteIndex = timesHit - 1;

        //To guard if any of the sprites is not supplied
        if (damageSprites[timesHit - 1])
        {
            this.GetComponent<SpriteRenderer>().sprite = damageSprites[timesHit - 1];
        }
    }
}