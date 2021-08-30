using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target;
    [SerializeField] float damage = 25f;


    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
    }

    public void AttackHitEvent()
    {
        if (target == null) return;
        target.TakeDamage(damage);
        target.GetComponent<DisplayDamage>().DisplayBlood();
    }

    public void SpawnMinions()
    {
        //This is here so SpawnMinions has a reciever for skeletons. Only Necromancers need the broadcast.
    }

}
