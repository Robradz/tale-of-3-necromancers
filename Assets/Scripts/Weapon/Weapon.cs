using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    
    [SerializeField] float range = 50f;
    [SerializeField] float damage = 20f;
    float timeOfLastShot;

    [SerializeField] ParticleSystem powerUp;
    [SerializeField] ParticleSystem fire;
    [SerializeField] ParticleSystem hitEffect;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] float shotDelay = .25f; // In the fire particle effect change the duration to match this
    [SerializeField] Text ammoText;

    [SerializeField] Canvas pauseCanvas;
    [SerializeField] Canvas winCanvas;
    [SerializeField] Canvas gameOverCanvas;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DisplayAmmo();
        if (!pauseCanvas.isActiveAndEnabled && !winCanvas.isActiveAndEnabled && !gameOverCanvas.isActiveAndEnabled)
        {
            if (Input.GetMouseButtonDown(0) && Time.time - timeOfLastShot > shotDelay && ammoSlot.GetAmmoAmount(ammoType) > 0)
            {
                ammoSlot.DecrementAmmo(ammoType);
                ShotAnimation();
                Invoke(nameof(Shoot), shotDelay);
                timeOfLastShot = Time.time;
            }
        }
    }
    
    private void DisplayAmmo()
    {
        ammoText.text = FindObjectOfType<Ammo>().GetAmmoAmount(ammoType).ToString();
    }


    private void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            CreateHitEffect(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;
            target.TakeDamage(damage);
        }
        else
        {
            return;
        }
    }

    private void CreateHitEffect(RaycastHit hit)
    {
        ParticleSystem impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact.gameObject, 1f);
    }

    private void ShotAnimation()
    {
        powerUp.Play();
        fire.Play();
    }
}
