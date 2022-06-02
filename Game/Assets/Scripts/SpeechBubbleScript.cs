using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpeechBubbleScript : MonoBehaviour
{
    public Text speechBubbleText;
    public GameObject trackingObject;
    public List<string> texts;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Activate(texts[Random.Range(0, texts.Count)]);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            Deactivate();
        }
        this.transform.LookAt(Camera.main.transform);
        this.transform.forward *= -1;
        this.transform.eulerAngles = new Vector3(0, this.transform.eulerAngles.y, 0);
    }

    public void Activate(string text)
    {
        speechBubbleText.text = text;
        this.transform.GetChild(0).gameObject.SetActive(true);
        this.transform.GetChild(1).gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        this.transform.GetChild(0).gameObject.SetActive(false);
        this.transform.GetChild(1).gameObject.SetActive(false);
    }
}
