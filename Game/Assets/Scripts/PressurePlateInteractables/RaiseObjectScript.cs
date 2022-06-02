using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiseObjectScript : PressurePlateInteractableBaseScript
{
    [SerializeField] Vector3 startPos;
    public Vector3 movementOffset;
    [SerializeField] Vector3 startRot;
    public Vector3 rotationOffset;
    // Start is called before the first frame update
    void Start()
    {
        startPos = this.transform.position;
        startRot = this.transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        timer = Mathf.Clamp(timer, 0, moveTime);
        this.transform.position = Vector3.Lerp(startPos, startPos + movementOffset, timer / moveTime);
        this.transform.eulerAngles = Vector3.Lerp(startRot, startRot + rotationOffset, timer / moveTime);
    }
}
