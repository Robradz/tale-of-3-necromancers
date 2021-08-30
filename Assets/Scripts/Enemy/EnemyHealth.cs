using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] float hitPoints;

    public void TakeDamage(float damage)
    {
        hitPoints -= damage;
        if (hitPoints <= 0) 
        {
            Die();
        }
        BroadcastMessage("OnDamageTaken");
    }

    private void Die()
    {
        GetComponent<Animator>().SetTrigger("death");
        BroadcastMessage("EnemyDeath");
        GetComponent<CapsuleCollider>().enabled = false; // This makes it so the TakeDamage can never be called since this is what detected damage.
    }

}
