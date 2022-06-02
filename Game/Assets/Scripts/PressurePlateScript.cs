using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateScript : MonoBehaviour
{
    float timer = 0.0f;
    int direction = -1;
    int onPlateCount = 0;
    public List<PressurePlateInteractableBaseScript> interactables;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        foreach(PressurePlateInteractableBaseScript interactable in interactables)
        {
            interactable.timer += Time.deltaTime * direction;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        onPlateCount += 1;
        direction = 1;
    }

    private void OnTriggerExit(Collider other)
    {
        onPlateCount -= 1;
        if(onPlateCount == 0)
        {
            direction = -1;
        }
    }


}
