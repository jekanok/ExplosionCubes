using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalingRotation : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 2.0f;
    [SerializeField] private float _rotationSpeed = 30.0f;
    [SerializeField] private float _scaleSpeed = 1.0f;

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        transform.Translate(Vector3.forward * _moveSpeed * Time.deltaTime);

        transform.Rotate(Vector3.up * _rotationSpeed * Time.deltaTime);

        transform.localScale += Vector3.one * _scaleSpeed * Time.deltaTime;
    }
}