using UnityEngine;


public class GameManager : MonoBehaviour
{
    public SpawnManager spawnManager;
    public ItemManager itemManager;
    public GameObject Cover;

    void Start()
    {

    }

    public void OnClickStartButton()
    {
        Cover.SetActive(false);
        spawnManager.SpawnRandom();
        itemManager.SpawnRandom();
    }
}