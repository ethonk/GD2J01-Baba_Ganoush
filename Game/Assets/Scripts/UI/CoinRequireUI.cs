using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRequireUI : MonoBehaviour
{
    private Transform PlayerCam;

    // Start is called before the first frame update
    void Start()
    {
        PlayerCam = GameObject.Find("Player").transform.Find("PlayerCamera").transform;
    }

    // Update is called once per frame
    void Update()
    {
        var lookDirection = PlayerCam.position - transform.position;
        lookDirection.x *= -1;
        lookDirection.y = 0;
        lookDirection.z *= -1;

        transform.rotation = Quaternion.LookRotation(lookDirection);
    }
}
