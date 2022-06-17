using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeelSpinner : MonoBehaviour
{
    [SerializeField] private float _spinSpeed;
    public float SpinSpeed { get => _spinSpeed; set => _spinSpeed = value; }

    private void Update()
    {
        WheelSpin();
    }

    public void WheelSpin()
    {
        transform.Rotate(Vector3.forward * SpinSpeed*Time.deltaTime);
    }
}
