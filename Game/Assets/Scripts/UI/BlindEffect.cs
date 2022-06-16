using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlindEffect : MonoBehaviour
{
    public GameObject blindUI;
    
    public void EnableBlind()
    {
        blindUI.SetActive(true);
    }

    public void DisableBlind()
    {
        blindUI.SetActive(false);   
    }
}
