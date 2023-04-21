using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MainMenuScripts
{
    public class LoadingScreen : MonoBehaviour
    {
        public static LoadingScreen instance;

        [SerializeField] private GameObject loadingBarHolder;
        [SerializeField] private Image loadingBarProgress;
        [SerializeField] private bool loadMainMenuFirstTime;

    
        private float progressValue = 1.1f;
        private float progressMultiplier1 = 0.5f;
        private float progressMultiplier2 = 0.07f;

    
        private void Awake()
        {
            if (instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }

        private void Update()
        {
            ShowLoadingScreen();
        }

        public void LoadLevel(string levelName)
        {
            loadingBarHolder.SetActive(true);
            progressValue = 0f;

            Time.timeScale = 0f;
            
            SceneManager.LoadScene(levelName);
        }

        void ShowLoadingScreen()
        {
            if (progressValue < 1f)
            {
                progressValue += progressMultiplier1 * progressMultiplier2;
                loadingBarProgress.fillAmount = progressValue;
                if (progressValue >= 1f)
                {
                    progressValue = 1.1f;
                    loadingBarProgress.fillAmount = 0f;
                    loadingBarHolder.SetActive(false);

                    Time.timeScale = 1f;
                }
            
            }
        }

        public void LoadLevelAsync(string levelName)
        {
            StartCoroutine(LoadAsync(levelName));
        }

        IEnumerator LoadAsync(string levelName)
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(levelName);
            
            loadingBarHolder.SetActive(true);

            while (!operation.isDone)
            {
                float progress = operation.progress / 0.9f;
                loadingBarProgress.fillAmount = progress;
                
                //if (progress >=1) 
                  //  loadingBarHolder.SetActive(false);

                yield return null;
            }
            loadingBarHolder.SetActive(false);
        }
    }
}
