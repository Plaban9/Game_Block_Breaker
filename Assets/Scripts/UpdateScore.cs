using Managers;

using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class UpdateScore : MonoBehaviour
{
    // Start is called before the first frame update
    private Text text;

    void Start()
    {
        text = GetComponent<Text>();

        StartCoroutine(nameof(TrackScoreWithInterval), 1f);
    }

    IEnumerator TrackScoreWithInterval(int delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);

            if (ScoreManager.Instance != null)
                text.text = "SCORE:_" + ScoreManager.Instance.Score;
        }
    }
}
