using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wildsong;

public class ZRotator : OptimizedRepeater
{
    [SerializeField] private float _rotationVelocity = 0.5f;
    private Vector3 _rotationVector;

    protected override void DoRepeatedLogic(float delta)
    {
        _rotationVector.z = delta * _rotationVelocity;
        transform.Rotate(_rotationVector);
    }
}
