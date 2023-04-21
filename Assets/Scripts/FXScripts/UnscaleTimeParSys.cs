using UnityEngine;

namespace FXScripts
{
    public class UnscaleTimeParSys : MonoBehaviour
    {
        private ParticleSystem partFX;

        private void Awake()
        {
            partFX = GetComponent<ParticleSystem>();
        }
    
        // Update is called once per frame
        void Update()
        {
            if (Time.timeScale < 0.01f)
            {
                partFX.Simulate(Time.unscaledDeltaTime, true, false);
            }    
        }
    }
}
