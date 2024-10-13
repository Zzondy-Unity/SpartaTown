using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class PoolManager : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabs;
    public List<GameObject>[] pools;

    private void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];

        for(int i = 0; i < pools.Length; i++)
        {
            pools[i] = new List<GameObject>() { prefabs[i] };
        }
    }


    public GameObject GetMonster(int index, Vector2 position)
    {
        GameObject select = pools[index].FirstOrDefault(prefab => prefab.activeSelf == false);

        if (!select)
        {
            select = Instantiate(prefabs[index], transform);
            pools[index].Add(select);
        }
        else
        {
            select.SetActive(true);
        }

        select.transform.position = position;
        return select;
    }
}