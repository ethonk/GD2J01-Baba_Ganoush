using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BWEnterTrigger : MonoBehaviour
{
    //Reference of BWMoveManager script
    public BWMoveManager MovedObj;

    //Boolean to check if player is in area of trigger
    public bool check = false;

    [Header("InteractedObj")]
    [SerializeField] private GameObject MovedObject;


    // Update is called once per frame
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            check = true;

            // Calling OnEnterTrigger from the TrigerManager script
            //MovedObj.ObjMoveScript();

        }
        else
        {
            check = false;

        }

    }

}
