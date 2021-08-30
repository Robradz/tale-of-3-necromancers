using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    float timeOfLastHit = 0f;
    [SerializeField] float playerHP = 100f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnParticleCollision(GameObject other)
    {
        if(Time.time - timeOfLastHit >= 0.1f)
        {
            print("hit");
            TakeDamage(25f);
            GetComponent<DisplayDamage>().DisplayBlood();
            timeOfLastHit = Time.time;
        }
    }

    public void TakeDamage(float damage)
    {
        playerHP -= damage;
        if (playerHP <= 0)
        {
            GetComponent<DeathHandler>().HandleDeath();
        }
    }
}
