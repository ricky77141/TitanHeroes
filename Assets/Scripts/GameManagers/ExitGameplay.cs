using MainMenuScripts;
using UnityEngine;

namespace GameManagers
{
    public class ExitGameplay : MonoBehaviour
    {
        public void ToMainMenu()
        {
            LoadingScreen.instance.LoadLevel(SceneNames.MAIN_MENU);
        }
    }
}
