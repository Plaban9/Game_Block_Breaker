namespace Managers
{
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class ScoreManager : MonoBehaviour
    {
        public int Score { get; private set; }
        public static ScoreManager Instance { get; private set; }


        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(Instance);
            }
            else
            {
                Destroy(this);
            }
        }

        public void AddScore(int score)
        {
            Score += score;
        }

        private void ResetScore()
        {
            Debug.Log("Reset Called");
            Score = 0;
        }

        void OnEnable()
        {
            Debug.Log("OnEnable called");
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            Debug.Log("OnSceneLoaded: " + scene.name);
            Debug.Log(mode);

            if (scene.name.Equals("Start"))
            {
                ResetScore();
            }
        }
    }
}
