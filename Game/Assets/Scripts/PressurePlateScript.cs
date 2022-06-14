using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateScript : MonoBehaviour
{
    float timer = 0.0f;
    int direction = -1;
    int onPlateCount = 0;
    public List<PressurePlateInteractableBaseScript> interactables;
    public float startDelay;
    public float endDelay;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer = Mathf.Max(timer - Time.deltaTime, 0.0f);
        if (timer <= 0.0f)
        {
            foreach (PressurePlateInteractableBaseScript interactable in interactables)
            {
                interactable.timer += Time.deltaTime * direction;
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (onPlateCount == 0)
        {
            timer = startDelay;
        }
            onPlateCount += 1;
        direction = 1;
    }

    private void OnTriggerExit(Collider other)
    {
        onPlateCount -= 1;
        if(onPlateCount == 0)
        {
            direction = -1;
            timer = endDelay;
        }
    }


}