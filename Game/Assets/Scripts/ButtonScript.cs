using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    float timer = 0.0f;
    float cooldownTimer = 0.0f;
    int direction = -1;
    public List<PressurePlateInteractableBaseScript> interactables;
    public float startDelay;
    public float cooldown;

    public bool InvisObj = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer = Mathf.Max(timer - Time.deltaTime, 0.0f);
        cooldownTimer = Mathf.Max(cooldownTimer - Time.deltaTime, 0.0f);

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
        if (cooldownTimer <= 0)
        {
            timer = startDelay;
            cooldownTimer = cooldown;
            direction *= -1;
        }
    }
}
