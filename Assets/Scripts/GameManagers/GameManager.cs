using UnityEngine;

namespace GameManagers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;

        [HideInInspector] public int selectedHeroIndex;

        private void Awake()
        {
            if (instance!=null)
                Destroy(gameObject);
            else
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }
    }
}
