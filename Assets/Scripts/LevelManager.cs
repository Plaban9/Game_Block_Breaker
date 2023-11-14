using Managers;

using System.Collections;

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

    [SerializeField]
    private Animator _loadAnimator;

    public void LoadLevel(string name)
    {
        StartCoroutine(nameof(LoadLevelCoroutine), name);
    }

    private IEnumerator LoadLevelCoroutine(string name)
    {
        _loadAnimator.SetTrigger("exit");
        yield return new WaitForSeconds(2.1f);
        Debug.Log("Level load requested for " + name);
        Brick.numBreakableBricks = 0;
        LoseCollider.lifeCounter = 3;
        SceneManager.LoadScene(name);
    }

    private IEnumerator LoadLevelCoroutine(float delay)
    {
        _loadAnimator.SetTrigger("exit");
        yield return new WaitForSeconds(delay);

        Brick.numBreakableBricks = 0;
        SceneManager.LoadScene(Application.loadedLevel + 1);
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