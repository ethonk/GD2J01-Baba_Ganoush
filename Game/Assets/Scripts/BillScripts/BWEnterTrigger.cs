using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BWEnterTrigger : MonoBehaviour
{
    //Reference of BWTriggerManager script
    public BWTriggerManager MovedObjScript;

    [Header("InteractedObj")]
    [SerializeField] private GameObject[] MovedObject;


    // Update is called once per frame
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            //BWTriggerManager ObjMoveManager = GetComponent<BWTriggerManager>();
            //ObjMoveManager.GetComponent<BWTriggerManager>().Trigger();


            // Calling OnEnterTrigger from the TrigerManager script
            MovedObjScript.ObjMoveScript();

        }

    }

}

