using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour
{
    // Public Variables
    #region
    public AudioClip hitSound;
    public static float sfxVolume = 1.0f;
    #endregion

    // Use this for initialization
    void Start()
    {
        sfxVolume = MusicPlayer.sfxVolume;
    }

    void OnTriggerEnter2D(Collider2D triggerObject)
    {
        if (triggerObject.CompareTag("Bullet") || triggerObject.CompareTag("PowerUp"))
        {
            Destroy(triggerObject.gameObject);
            return;
        }
    }

    void OnCollisionEnter2D(Collision2D collisison)
    {
        AudioSource.PlayClipAtPoint(hitSound, transform.position, sfxVolume);
    }
}