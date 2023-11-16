using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float magnitude = 1f;

    [SerializeField]
    private GameObject beamPrefab;

    public float firingRate = 1f;

    Rigidbody2D rigidbody2D;

    public float minX;
    public float maxX;

    public float minY;
    public float maxY;

    public Vector2 getVelocity()
    {
        return rigidbody2D.velocity;
    }

    Vector2 newVelocity;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMovement;
        float verticalMovement;

        horizontalMovement = Input.GetAxis("Horizontal");
        verticalMovement = Input.GetAxis("Vertical");

        //Debug.Log("Horizontal: " + horizontalMovement + ", Vertical: " + verticalMovement);

        newVelocity = new Vector2(horizontalMovement, verticalMovement);
        rigidbody2D.velocity = newVelocity * magnitude;
        //Debug.Log("Vector: " + rigidbody2D.velocity);

        float newX, newY;

        newX = Mathf.Clamp(GetComponent<Rigidbody2D>().position.x, minX, maxX);
        newY = Mathf.Clamp(GetComponent<Rigidbody2D>().position.y, minY, maxY);

        GetComponent<Rigidbody2D>().position = new Vector2(newX, newY);

        HandleShoot();
    }

    void HandleShoot()
    {
        //Debug.Log("Space Pressed");
        //GameObject gameObject = Instantiate(beamPrefab, this.transform);

        //if (Input.GetAxis("Fire1") > 0f)
        //{
        //    InvokeRepeating("ShootLaser", 0.01f, firingRate);
        //}

        //if (Input.GetAxis("Fire1") == 0)
        //{
        //    CancelInvoke("ShootLaser");
        //}

        if (Input.GetButtonDown("Fire1"))
        {
            InvokeRepeating("ShootLaser", 0.01f, firingRate);
        }

        if (Input.GetButtonUp("Fire1"))
        {
            CancelInvoke("ShootLaser");
        }
    }

    void ShootLaser()
    {
        if (beamPrefab)
        {
            GameObject laserShot = Instantiate(beamPrefab, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 0.1f), Quaternion.identity) as GameObject;
            //laserShot.GetComponent<Rigidbody2D>().velocity = Vector3.right * projectileSpeed;
            laserShot.transform.rotation = Quaternion.Euler(0f, 0f, -90f);
        }

        //if (shootSound)
        //{
        //    AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, sfxVolume);
        //}
    }
}
