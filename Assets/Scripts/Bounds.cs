using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D anotherObject)
    {
        if (anotherObject.CompareTag("Bullet"))
        {
            Debug.Log("BUllet");
            Destroy(anotherObject.gameObject);
        }
    }
}
