using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicRotationEffect : MonoBehaviour {
    public float rotationSpeed = 10.0f;

    private void FixedUpdate()
    {
        transform.Rotate(Vector3.forward * -rotationSpeed);
    }
}
