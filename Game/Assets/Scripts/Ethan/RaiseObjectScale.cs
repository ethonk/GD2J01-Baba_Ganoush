using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiseObjectScale : MonoBehaviour
{
    public bool raising;        // is it currently raising?
    public float raiseSpeed;    // how fast does it raise?

    public float startHeight;
    public float desiredHeight;
    
    // Start is called before the first frame update
    void Start()
    {
        startHeight = transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (raising)
        {
            Vector3 currentScale = transform.localScale;
            transform.localScale = Vector3.Lerp(transform.localScale, 
                new Vector3(currentScale.x, desiredHeight, currentScale.z), raiseSpeed * Time.deltaTime);
        }
        else
        {
            Vector3 currentScale = transform.localScale;
            transform.localScale = Vector3.Lerp(transform.localScale, 
                new Vector3(currentScale.x, startHeight, currentScale.z), raiseSpeed * Time.deltaTime);
        }
    }
}
