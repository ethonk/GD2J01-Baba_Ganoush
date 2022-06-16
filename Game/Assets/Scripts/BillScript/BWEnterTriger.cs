using System.Collections;
using System.Collections.Generic;
using Managers.EventManagement;
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
            GameObject.Find("EVENT_MANAGER").GetComponent<EventManagement>().Fading();

            check = true;
            // Calling OnEnterTrigger from the TrigerManager script
            //MovedObj.ObjMoveScript();


        }

    }

}
