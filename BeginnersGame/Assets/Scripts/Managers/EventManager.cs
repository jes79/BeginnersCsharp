using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static event Action EnemyDieEvent;

    public static void RunEnemyDieEvent()
    {
        if (EnemyDieEvent != null)
        {
            EnemyDieEvent();
        }
    }
}
