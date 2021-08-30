using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NecromancerAttack : MonoBehaviour
{

    [SerializeField] ParticleSystem enemyProjectile;

    PlayerHealth target;
    [SerializeField] float damage = 25f;


    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
    }

    public void LaunchProjectile()
    {
        Transform projectileDirection = enemyProjectile.transform;
        projectileDirection.LookAt(target.transform);
        enemyProjectile.Play();
    }
}
