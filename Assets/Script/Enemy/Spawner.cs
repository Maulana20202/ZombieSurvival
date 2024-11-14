using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject Enemy;

    public TotalEnemy totalEnemy;

    public float Duration;

    // Start is called before the first frame update
    void Start()
    {
        totalEnemy = GetComponentInParent<TotalEnemy>();
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn()
    {
        if(totalEnemy.TotalEnemys < 20)
        {
            GameObject Enemys = Instantiate(Enemy, this.transform.position, Quaternion.identity, this.transform);

            EnemyAI enemyAI = Enemys.GetComponent<EnemyAI>();

            enemyAI.totalEnemy = totalEnemy;
            totalEnemy.TotalEnemys++;
            
        }

        Invoke("Spawn", Duration);

    }
}
