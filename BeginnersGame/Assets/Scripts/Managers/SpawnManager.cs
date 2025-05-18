using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject Enemy1Prefabs;
    public GameObject Enemy2Prefabs;


    void Start()
    {
        SpawnEnemy(Enemy1Prefabs, new Vector3(1, 2, 0));
        SpawnEnemy(Enemy2Prefabs, new Vector3(-1, 2, 0));
    }

    public void SpawnEnemy(GameObject prefab, Vector3 _position)
    {
        GameObject enemy = Instantiate(prefab);
        enemy.transform.position = _position;
        enemy.GetComponent<Enemy>().Move();
    }

}