using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public Point[] Points = {
        new Point(0,0),
        new Point(1,0),
        new Point(0,1),
        new Point(2,0),
        new Point(0,2),

    };
    public GameObject[] ItemPrefabs = new GameObject[3];


    private void Start()
    {
        for(int i = 0; i < 3; i++)
        {
            GameObject prefab = ItemPrefabs[Random.Range(0,ItemPrefabs.Length)];
            Vector2 pos = Points[Random.Range(0, Points.Length)].GetPos();
            SpawnItem(prefab, pos);
        }
    }


    public void SpawnItem(GameObject itemPrefab, Vector2 pos)
    {
        GameObject obj = Instantiate(itemPrefab);
        obj.transform.position = pos;
    }

}

public struct Point
{
    public int x;
    public int y;

    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public Vector2 GetPos()
    {
        return new Vector2(x, y);
    }
}
