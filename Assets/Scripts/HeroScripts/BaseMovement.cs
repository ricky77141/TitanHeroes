using UnityEngine;

namespace HeroScripts
{
    public class BaseMovement : MonoBehaviour
    {
        [HideInInspector] public Vector3 movementDirection;

        private Rigidbody myBody;
    
        [SerializeField] private float walkSpeed = 5f;
        [SerializeField] private float walkingForce = 50f;
        [SerializeField] private float turningSmooth = 0.1f;
    
        // Start is called before the first frame update
        void Awake()
        {
            myBody = GetComponent<Rigidbody>();
        }
    
        void FixedUpdate()
        {
            HandleMovement();    
        }

        void HandleMovement()
        {
            Vector3 targetVelocity = movementDirection * walkSpeed;
            Vector3 deltaVelocity = targetVelocity - myBody.velocity;

            if (myBody.useGravity)
                deltaVelocity.y = 0f;
        
            myBody.AddForce(deltaVelocity * walkingForce, ForceMode.Acceleration);

            Vector3 faceDirection = movementDirection;

            if (faceDirection == Vector3.zero)
            {
                myBody.angularVelocity = Vector3.zero;
            }
            else
            {
                float rotationAngle = AngleAroundAxis(transform.forward, faceDirection, Vector3.up);
                myBody.angularVelocity = Vector3.up * rotationAngle * turningSmooth;
            }

            float AngleAroundAxis(Vector3 dirA, Vector3 dirB, Vector3 axis)
            {
                float angle = Vector3.Angle(dirA, dirB);

                return angle * (Vector3.Dot(axis, Vector3.Cross(dirA, dirB)) > 0 ? 1 : -1);
            }
            
        }
    }
}
