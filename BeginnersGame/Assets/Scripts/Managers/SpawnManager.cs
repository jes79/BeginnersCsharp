using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] EnemyPrefabs;

    public List<Point> Points = new List<Point>
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
        // SpawnRandom();
        EventManager.EnemyDieEvent += OnEnemyDie;
    }

    public void SpawnEnemy(GameObject prefab, Vector3 _position)
    {
        GameObject enemy = Instantiate(prefab);
        enemy.transform.position = _position;
        enemy.GetComponent<Enemy>().Move();
    }

    public IEnumerator SpawnRandom()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.3f);
            SpawnEnemy(EnemyPrefabs[Random.Range(0, 2)], Points[Random.Range(0, Points.Count)].GetPos());
        }
    }

    // public void SpawnRandom()
    // {
    //     SpawnEnemy(EnemyPrefabs[Random.Range(0, 2)], Points[Random.Range(0, Points.Count)].GetPos());
    //     Invoke("SpawnRandom", 0.3f);
    // }

    public void OnEnemyDie()
    {
        Point point = new Point(Random.Range(-3, 3), Random.Range(-5, 5));
        Points.Add(point);
    }
}

