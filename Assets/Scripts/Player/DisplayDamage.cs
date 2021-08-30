using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class DisplayDamage : MonoBehaviour
{

    [SerializeField] Canvas DamageDisplay;
    [SerializeField] float displayTime = .5f;

    private void Start()
    {
        DamageDisplay.enabled = false;
    }

    public void DisplayBlood()
    {
        StartCoroutine(ShowSplatter());
    }

    IEnumerator ShowSplatter()
    {
        DamageDisplay.enabled = true;
        yield return new WaitForSeconds(displayTime);
        DamageDisplay.enabled = false;
    }


}
