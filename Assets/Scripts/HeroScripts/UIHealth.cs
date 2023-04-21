using UnityEngine;
using UnityEngine.UI;

namespace HeroScripts
{
    public class UIHealth : MonoBehaviour
    {

        [SerializeField] Image healthSlider;

        public void DisplayHealthValue(float value)
        {

            value /= 100f;

            if (value < 0)
            {
                value = 0f;
            }
            
            healthSlider.fillAmount = value;
        }
        
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
