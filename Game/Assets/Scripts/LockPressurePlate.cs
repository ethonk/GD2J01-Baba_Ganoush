using Managers.EventManagement;
using UnityEngine;
using TMPro;

public class LockPressurePlate : MonoBehaviour
{
    [Header("Coins Required")]
    public int coinsRequired;
    
    [Header("References")]
    public GameObject ui;
    public TextMeshProUGUI ui_txt;
    public GameObject particlePrefab;
    
    private EventManagement _eventManagement;
    
    // Start is called before the first frame update
    void Start()
    {
        // set event manager
        _eventManagement = GameObject.Find("EVENT_MANAGER").GetComponent<EventManagement>();
        
        // lock the pressure plate on start
        GetComponent<PressurePlateScript>().enabled = false;
    }

    void Update()
    {
        ui_txt.text = "Unlock: (" + coinsRequired.ToString() + ") coins.";
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && _eventManagement._coinCount >= coinsRequired 
                                       && GetComponent<PressurePlateScript>().enabled == false)
        {
            UnlockPressurePlate();
        }
    }

    private void UnlockPressurePlate()
    {
        GetComponent<PressurePlateScript>().enabled = true;
        ui.SetActive(false);
        
        // enable particle
        particlePrefab.SetActive(true);
    }
}
