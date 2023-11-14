using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField]
    private float smallStarScrollSpeed;

    [SerializeField]
    private float bigStarScrollSpeed;

    [SerializeField]
    GameObject[] smallStarsBackgrounds;

    [SerializeField]
    GameObject[] bigStarsBackgrounds;
    // Start is called before the first frame update

    //private int counterSmallStars = 1;
    //private int counterBigStars = 1;
    [SerializeField]
    PlayerController player;

    private float currentVelocitySmallStar;
    private float currentVelocityBigStar;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        updateScrollSpeed();
        scrollBigStars();
        scrollSmallStars();
    }

    private void scrollBigStars()
    {
        for (int i = 0; i < bigStarsBackgrounds.Length; i++)
        {
            if (bigStarsBackgrounds[i].transform.position.x < -19f)
            {
                bigStarsBackgrounds[i].transform.position = new Vector3(37f, bigStarsBackgrounds[i].transform.position.y, bigStarsBackgrounds[i].transform.position.z);
            }

            bigStarsBackgrounds[i].transform.Translate(Vector2.left * Time.deltaTime * currentVelocityBigStar);
        }
    }

    private void scrollSmallStars()
    {
        for (int i = 0; i < smallStarsBackgrounds.Length; i++)
        {
            if (smallStarsBackgrounds[i].transform.position.x < -19f)
            {
                smallStarsBackgrounds[i].transform.position = new Vector3(37f, smallStarsBackgrounds[i].transform.position.y, smallStarsBackgrounds[i].transform.position.z);
            }

            smallStarsBackgrounds[i].transform.Translate(Vector2.left * Time.deltaTime * currentVelocitySmallStar);
        }
    }

    private void updateScrollSpeed()
    {
        //currentVelocitySmallStar = Mathf.Abs(player.getVelocity().x < 0 ? smallStarScrollSpeed - player.getVelocity().x % smallStarScrollSpeed : smallStarScrollSpeed + player.getVelocity().x % smallStarScrollSpeed);
        ////Debug.Log(player.getVelocity().x);
        //currentVelocityBigStar = Mathf.Abs(player.getVelocity().x < 0 ? bigStarScrollSpeed - player.getVelocity().x % bigStarScrollSpeed : bigStarScrollSpeed + player.getVelocity().x % bigStarScrollSpeed);

        currentVelocitySmallStar = Mathf.Abs(smallStarScrollSpeed + player.getVelocity().x);
        //Debug.Log(player.getVelocity().x);
        currentVelocityBigStar = Mathf.Abs(bigStarScrollSpeed + player.getVelocity().x);

        if (player.getVelocity().x < 0f)
        {
            currentVelocityBigStar = Mathf.Max(currentVelocityBigStar % bigStarScrollSpeed, 0.75f);
            currentVelocitySmallStar = Mathf.Max(currentVelocitySmallStar % smallStarScrollSpeed, 0.25f);
        }

        if (currentVelocityBigStar < currentVelocitySmallStar)
        {
            float exchangeVariable = currentVelocitySmallStar;
            currentVelocitySmallStar = currentVelocityBigStar;
            currentVelocityBigStar = exchangeVariable;
        }

        //Debug.Log("Current Speed - Big: " + currentVelocityBigStar + ", Small: " + currentVelocitySmallStar);
    }

}
