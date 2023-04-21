using UnityEngine;

namespace FXScripts
{
    public class RotateEffect : MonoBehaviour
    {
        [SerializeField] private float rotationSpeedx;
        [SerializeField] private float rotationSpeedy;
        [SerializeField] private float rotationSpeedz;
    
        // Update is called once per frame
        void Update()
        {
            transform.Rotate(new Vector3(rotationSpeedx, rotationSpeedy,rotationSpeedz) * Time.deltaTime);
        }
    }
}
