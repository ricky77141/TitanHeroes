using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ShakeCamera : MonoBehaviour
{

    [SerializeField] private float power = 0.7f;

    [HideInInspector] public float shakeDuration = 1f;

    [SerializeField] private float shakeSlowDownAmount = 1f;

    private bool shouldShake;

    private Vector3 startPosition;

    private float initialDuration;
    

    // Update is called once per frame
    void Update()
    {
        if (shouldShake)
        {
            if (shakeDuration > 0f)
            {
                transform.localPosition = startPosition + Random.insideUnitSphere * power;
                shakeDuration -= Time.unscaledDeltaTime * shakeSlowDownAmount;
            }
            else
            {
                shouldShake = false;
                shakeDuration = initialDuration;
                transform.localPosition = startPosition;
            }
        }
    }

    public void InitializeValues(float duration)
    {
        shakeDuration = duration;
        startPosition = transform.localPosition;
        initialDuration = shakeDuration;
        shouldShake = true;
    }
}
