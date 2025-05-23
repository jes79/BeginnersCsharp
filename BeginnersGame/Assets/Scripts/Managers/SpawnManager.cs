using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] EnemyPrefabs;

    public Point[] Points =
    {
        new Point(-3,-5),
        new Point(-3,-3),
        new Point(-3,-1),
        new Point(-3,1),
        new Point(-3,3),
        new Point(-3,5),
        new Point(3,-5),
        new Point(3,-3),
        new Point(3,-1),
        new Point(3,1),
        new Point(3,3),
        new Point(3,5),
    };


    void Start()
    {
        //SpawnRandom();

    }

    public void SpawnEnemy(GameObject prefab, Vector3 _position)
    {
        GameObject enemy = Instantiate(prefab);
        enemy.transform.position = _position;
        enemy.GetComponent<Enemy>().Move();
    }


    public void SpawnRandom()
    {
        GameObject prefab = EnemyPrefabs[Random.Range(0, EnemyPrefabs.Length)];
        Vector2 pos = Points[Random.Range(0, Points.Length)].GetPos();
        SpawnEnemy(prefab, pos);
        Invoke("SpawnRandom", 0.3f); //Àç±Í
    }

}

