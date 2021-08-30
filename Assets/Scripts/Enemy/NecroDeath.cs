using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NecroDeath : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void EnemyDeath()
    {
        Invoke("DestroyEnemy", 3f);
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
