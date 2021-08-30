using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NecromancerAdds : MonoBehaviour
{
    [SerializeField] GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnMinions()
    {
        StartCoroutine(SpawnMinion());
    }

    IEnumerator SpawnMinion()
    {
        if(gameObject == null) 
        {
            print("GameObject null");
            StopCoroutine(SpawnMinion()); 
        }

        yield return new WaitForSeconds(30f);
        Transform minionTransform = transform;
        Transform minionTransform2 = transform;

        minionTransform.position += new Vector3(0f, 0f, 10f);
        minionTransform2.position += new Vector3(0f, 0f, -10f);

        GameObject minion1 = Instantiate<GameObject>(enemy, minionTransform);
        GameObject minion2 = Instantiate<GameObject>(enemy, minionTransform2);

        minion1.transform.parent = GameObject.Find("Enemies").transform;
        minion2.transform.parent = GameObject.Find("Enemies").transform;
        minion1.transform.localScale = new Vector3(4, 4, 4);
        minion2.transform.localScale = new Vector3(4, 4, 4);

        minion1.GetComponent<EnemyAI>().isProvoked = true;
        minion2.GetComponent<EnemyAI>().isProvoked = true;

    }

}
