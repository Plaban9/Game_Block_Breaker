using Managers;

using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    /*// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}*/

    public void LoadLevel(string name)
    {
        Debug.Log("Level load requested for " + name);
        Brick.numBreakableBricks = 0;
        LoseCollider.lifeCounter = 3;
        SceneManager.LoadScene(name);
    }

    public void LoadNextLevel()
    {
        Brick.numBreakableBricks = 0;
        SceneManager.LoadScene(Application.loadedLevel + 1);
    }

    public void QuitRequest()
    {
        Debug.Log("Exit Requested " + name);
        Application.Quit();
    }

    public void BrickDestroyed()
    {
        if (Brick.numBreakableBricks <= 0)
        {
            if (ScoreManager.Instance != null)
                ScoreManager.Instance.AddScore(Brick.ALL_BRICK_DESTROY_SCORE);
            LoadNextLevel();
        }
    }
}