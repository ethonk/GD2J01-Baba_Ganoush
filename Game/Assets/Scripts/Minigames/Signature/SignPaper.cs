using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignPaper : MonoBehaviour
{
    public Texture2D paperTexture;
    public Vector2 textureSize = new Vector2(2048, 2048);
    
    // Start is called before the first frame update
    void Start()
    {
        var _renderer = GetComponent<Renderer>();

        // Initialize texture
        paperTexture = new Texture2D((int)textureSize.x, (int)textureSize.y);
        _renderer.material.mainTexture = paperTexture;
    }
}
