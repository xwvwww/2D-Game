using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;  


    void Update()
    {
        if (_target == null)
            return;

        Vector3 newPosition = new Vector3(_target.position.x,
                                          _target.position.y,
                                          transform.position.z);

        transform.position = Vector3.Lerp(transform.position, newPosition, _speed * Time.deltaTime);
    }
}
