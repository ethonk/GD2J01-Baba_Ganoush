using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisObject : PressurePlateInteractableBaseScript
{
    private Renderer renderedObj;
    private bool enabled = false;
    public PressurePlateScript pressurePlateScript;
    Collider Collider;


    // Start is called before the first frame update
    void Start()
    {
        renderedObj = GetComponent<Renderer>();
        Collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!enabled && pressurePlateScript.InvisObj == false)
        {
            renderedObj.enabled = !renderedObj.enabled;
            Collider.enabled = !Collider.enabled;
            enabled = true;
        }
        else if (pressurePlateScript.InvisObj == true)
        {
            enabled = false;
        }
    }
}
