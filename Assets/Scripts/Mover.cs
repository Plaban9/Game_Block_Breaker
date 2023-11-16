using UnityEngine;

public class Mover : MonoBehaviour
{
    public float beamSpeed = 12.0f;

    public Sprite[] spritesList;

    public AudioClip[] audioClips;

    [SerializeField]
    private const float lowDamage = 10f;
    private const float highDamage = 20f;

    private float damageGiven;


    [SerializeField]
    bool shouldRotate;
    [SerializeField]
    float maxAngularVelocity = 1f;


    [SerializeField]
    private GameObject particleSystemRock;

    [SerializeField]
    private GameObject explosionAnimation;



    // Start is called before the first frame update
    void Start()
    {
        try
        {
            //if (Random.Range(0, 100) < 25)
            //{
            //    GetComponent<SpriteRenderer>().sprite = spritesList[Random.Range(0, spritesList.Length)];
            //    beamSpeed = Random.Range(5f, 8f);
            //    AudioSource.PlayClipAtPoint(audioClips[1], transform.position);
            //    damageGiven = highDamage;

            //}
            //else
            {
                damageGiven = lowDamage;
                AudioSource.PlayClipAtPoint(audioClips[0], transform.position);
            }

        }
        catch (System.Exception ignored)
        {

        }

        GetComponent<Rigidbody2D>().velocity = new Vector3(0f, beamSpeed, 0f);

        if (shouldRotate)
        {
            GetComponent<Rigidbody2D>().angularVelocity = Random.value * maxAngularVelocity;
            GetComponent<Rigidbody2D>().velocity = new Vector3(0f, beamSpeed, 0f) * Random.value;
        }

        //explosionAnimation = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //public float GetDamage()
    //{
    //    return damageGiven;
    //}

    void FixedUpdate()
    {
        //if (shouldRotate)
        //{
        //    Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
        //    gameObject.GetComponent<Rigidbody2D>().MoveRotation(rigidbody2D.rotation + 5 * Time.fixedDeltaTime);
        //}
    }

    private void OnTriggerEnter2D(Collider2D anotherObject)
    {
        //if (anotherObject.CompareTag("Bullet"))
        //{
        //    Destroy(anotherObject.gameObject);

        //    TakeDamage();
        //}
    }

    //private void TakeDamage()
    //{
    //    if (this.gameObject.CompareTag("Rock"))
    //    {
    //        //Debug.Log("I am here");
    //        StartParticleEffect();
    //    }

    //    SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

    //    spriteRenderer.color = Color.red;

    //    Invoke(nameof(ResetDamage), 0.25f);

    //    Destroy(this.gameObject);
    //}

    //private void ResetDamage()
    //{
    //    SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

    //    spriteRenderer.color = Color.white;
    //}

    //private void StartParticleEffect()
    //{
    //    //particleSystemRock.GetComponent<ParticleSystem>().Play();
    //    //particleSystemRock.GetComponent<ParticleSystem>().Play();
    //    //Instantiate(particleSystemRock);

    //    Instantiate(explosionAnimation, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 0.2f), Quaternion.identity);
    //    Instantiate(particleSystemRock, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 0.1f), Quaternion.identity);        
    //}
}
