using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupRotation : MonoBehaviour
{

    [Tooltip("Rotations per second")][SerializeField] float rps = 1f; //rotations per second

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(transform.rotation.x, transform.rotation.y + (rps * Time.deltaTime), transform.rotation.z, Space.World);
        transform.Rotate(0, (rps * 360f * Time.deltaTime), 0);
    }
}
