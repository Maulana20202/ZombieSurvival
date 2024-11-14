using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject[] Enemy;

    public TotalEnemy totalEnemy;

    public float Duration;

    public int index = 1;

    // Start is called before the first frame update
    void Start()
    {
        totalEnemy = GetComponentInParent<TotalEnemy>();
        Spawn();

        CountdownManager.OnWaveUp += IndexPlus;
    }

    private void OnDestroy()
    {
        CountdownManager.OnWaveUp -= IndexPlus;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn()
    {
        int RandomNumber = Random.Range(0, index);

            GameObject Enemys = Instantiate(Enemy[RandomNumber], this.transform.position, Quaternion.identity, this.transform);

            EnemyAI enemyAI = Enemys.GetComponent<EnemyAI>();

            enemyAI.totalEnemy = totalEnemy;
            totalEnemy.TotalEnemys++;

        Invoke("Spawn", Duration);

    }

    public void IndexPlus()
    {
        index += 1;
    }
}
