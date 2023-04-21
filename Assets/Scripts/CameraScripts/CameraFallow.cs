using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFallow : MonoBehaviour
{
    private Transform playerTransform;
    private Transform myTransform;

    [SerializeField] private Vector3 offset = new Vector3(7.5f, 11f, 4.2f);
    
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag(TagManager.PLAYER_TAG).transform;
        myTransform = transform;
    }
    
    void LateUpdate()
    {
        if (playerTransform != null)
        {
            myTransform.position = playerTransform.position + offset;
        }
    }
}
