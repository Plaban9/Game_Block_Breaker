using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PowerType : MonoBehaviour
{
    [SerializeField]
    PowerUpType powerUpType;

    [SerializeField]
    private float _magnitude;

    public PowerUpType PowerUpType { get => powerUpType; private set => powerUpType = value; }

    public float min = 3f;
    public float max = 3f;
    public float movementSpeed = 1f;


    // Start is called before the first frame update
    void Start()
    {
        min = transform.position.x;
        max = transform.position.x + 2;
    }

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(Vector3.up * _magnitude * Time.deltaTime);
        transform.position -= transform.up * Time.deltaTime * movementSpeed;
        transform.position = new Vector3(Mathf.PingPong(Time.time * 2, max - min) + min, transform.position.y, transform.position.z);

    }
}
