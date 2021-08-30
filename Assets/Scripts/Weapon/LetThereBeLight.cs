using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetThereBeLight : MonoBehaviour
{
    [SerializeField] float spotAngle = 70f;
    [SerializeField] float intensity;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponentInChildren<FlashLightSystem>().RestoreLightAngle(spotAngle);
            other.GetComponentInChildren<FlashLightSystem>().RestoreLightIntensity(intensity);
            Destroy(gameObject);
        }
    }
}
