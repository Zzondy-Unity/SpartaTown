using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MonsterType
{
    NormalZombie,
    PowerZombie,
    Skeleton,
    TombMonster,
    Wraith
}

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] PoolManager poolManager;
    [SerializeField] Transform[] spawnPoints;

    private void Start()
    {
        StartCoroutine(SpawnStart());
    }

    IEnumerator SpawnStart()
    {
        while (true)
        {
            int i = Random.Range(0, poolManager.pools.Length);
            int j = Random.Range(0, spawnPoints.Length);
            poolManager.GetMonster(i, spawnPoints[j].position);

            yield return new WaitForSeconds(2f);
        }
    }
}
