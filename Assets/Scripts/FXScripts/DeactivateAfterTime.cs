using UnityEngine;

namespace FXScripts
{
    public class DeactivateAfterTime : MonoBehaviour
    {

        [SerializeField] private float timer = 2f;
    
        // Start is called before the first frame update
        void Start()
        {
            Invoke("DeactivateGameObject", timer);
        }

        void DeactivateGameObject()
        {
            gameObject.SetActive(false);
        }
    }
}
