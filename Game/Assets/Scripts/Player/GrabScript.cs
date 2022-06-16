using UnityEngine;
using UnityEngine.InputSystem;

public class GrabScript : MonoBehaviour
{
    // input
    [SerializeField] private InputActionReference inputGrab;
    [SerializeField] private InputActionReference inputDrop;
    
    bool canGrab = true;
    GameObject grabObject = null;
    public float throwForce = 100.0f;
    public float throwHeight = 100.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inputGrab.action.triggered && grabObject != null && canGrab)
        {
            grabObject.transform.parent = this.transform;
            grabObject.transform.position = this.transform.GetChild(0).position;
            grabObject.GetComponent<Rigidbody>().isKinematic = true;
            Physics.IgnoreCollision(this.transform.parent.GetComponent<Collider>(), grabObject.GetComponent<Collider>());
            canGrab = false;
        }
        else if (inputGrab.action.triggered && grabObject != null)
        {
            grabObject.transform.parent = null;
            Physics.IgnoreCollision(this.transform.parent.GetComponent<Collider>(), grabObject.GetComponent<Collider>(), false);
            grabObject.GetComponent<Rigidbody>().isKinematic = false;
            canGrab = true;
        }

        if (inputThrow.action.triggered && !canGrab)
        {
            grabObject.transform.parent = null;
            Physics.IgnoreCollision(this.transform.parent.GetComponent<Collider>(), grabObject.GetComponent<Collider>(), false);
            grabObject.GetComponent<Rigidbody>().isKinematic = false;
            canGrab = true;
            grabObject.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * throwForce + this.transform.up*throwHeight);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Grabbable" && canGrab)
        {
            grabObject = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Grabbable" && canGrab)
        {
            grabObject = null;
        }
    }
}