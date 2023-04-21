using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForwardAndBackward : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;

    [SerializeField] private bool moveFwdBwd;

    private void Start()
    {
        if (moveFwdBwd)
            StartCoroutine(ChangeDirection());
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.Translate(transform.forward * moveSpeed * Time.deltaTime, Space.World);
    }

    IEnumerator ChangeDirection()
    {
        yield return new WaitForSeconds(2f);
        moveSpeed *= -1f;
    }
}
