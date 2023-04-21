using GameManagers;
using UnityEngine;


namespace MainMenuScripts
{
    public class MainMenuController : MonoBehaviour
    {
        [SerializeField] private GameObject heroSelectPanel;
        [SerializeField] private GameObject[] assigners;

        private int assignerNumb;
 
        public void StartGame()
        {
            LoadingScreen.instance.LoadLevel(SceneNames.GAMEPLAY);
            //LoadingScreen.instance.LoadLevelAsync(SceneNames.GAMEPLAY);
        }

        public void OpenHeroSelectPanel()
        {
            heroSelectPanel.SetActive(true);
        }

        public void CloseHeroSelectPanel()
        {
            heroSelectPanel.SetActive(false);
        }

        public void SelectHero()
        {
            GameManager.instance.selectedHeroIndex =
                int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

            assignerNumb = GameManager.instance.selectedHeroIndex;

            for (int i = 0; i < assigners.Length; i++)
            {
                if (i == assignerNumb)
                {
                    assigners[i].gameObject.SetActive(true);
                }
                else
                {
                    assigners[i].gameObject.SetActive(false);
                }
            }

        }
        
        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
