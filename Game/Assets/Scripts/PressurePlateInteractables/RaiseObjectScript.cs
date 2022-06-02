using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiseObjectScript : PressurePlateInteractableBaseScript
{
    Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(startPos.x, Mathf.Lerp(startPos.y, startPos.y + this.GetComponent<Collider>().bounds.size.y - 1, timer / maxTime), startPos.z);
    }
}
