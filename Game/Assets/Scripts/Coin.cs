using System.Collections;
using System.Collections.Generic;
using Managers.EventManagement;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private bool OnTriggerEnter(Collider col)
    {
        if (!col.CompareTag("Player"))
            return false;       // dont run if not a player
        
        GameObject.Find("EVENT_MANAGER").GetComponent<EventManagement>().AddCoins();
        Destroy(gameObject);    // kill coin instance
        return true;
    }
}
