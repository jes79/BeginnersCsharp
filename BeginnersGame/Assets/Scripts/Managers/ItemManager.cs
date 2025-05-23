using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public Point[] Points = {
        new Point(0,0),
        new Point(1,1),
        new Point(1,-1),
        new Point(-1,1),
        new Point(-1,-1),
        new Point(2,2),
        new Point(2,-2),
        new Point(-2,2),
        new Point(-2,-2),
        new Point(3,3),
        new Point(3,-3),
        new Point(-3,3),
        new Point(-3,-3),
    };

    public GameObject[] ItemPrefabs = new GameObject[3];

    void Start()
    {
        //SpawnRandom();
    }

    /*
    GameObject GetItem(Items item) //Items enum
    {
        return ItemPrefabs[(int)item];
    }
    */

    public void SpawnItem(GameObject itemPrefab, Vector2 pos)
    {
        GameObject obj = Instantiate(itemPrefab);
        obj.transform.position = pos;
    }

    public void SpawnRandom()
    {
        GameObject prefab = ItemPrefabs[Random.Range(0, ItemPrefabs.Length)];
        Vector2 pos = Points[Random.Range(0, Points.Length)].GetPos();
        SpawnItem(prefab, pos);
        Invoke("SpawnRandom", 1.0f);
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
