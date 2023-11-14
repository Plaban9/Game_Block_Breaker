using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PowerType : MonoBehaviour
{
    [SerializeField]
    PowerUpType powerUpType;

    [SerializeField]
    private float _magnitude;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(Vector3.up * _magnitude * Time.deltaTime);
    }
}
