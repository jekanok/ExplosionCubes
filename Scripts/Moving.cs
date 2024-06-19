using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Moving : MonoBehaviour
{
    [SerializeField] private float _speed = 2.0f;

    private float _distance = 7f;

    private Vector3 _startPosition;

    private void Start()
    {
        _startPosition = transform.position;
    }

    private void Update()
    {
        MovingSphere();
    }

    private void MovingSphere()
    {
        float z = _startPosition.z + Mathf.PingPong(Time.time * _speed, _distance);
        transform.position = new Vector3(transform.position.x, transform.position.y, z);
    }
}