using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pen : MonoBehaviour
{
    [SerializeField] private Transform penTip;
    [SerializeField] private int penSize = 5;

    private Renderer _renderer;
    
    private Color[] _colors;
    
    private float _tipHeight; 

    private RaycastHit _touch;

    private SignPaper paper;
    private Vector2 _touchPos;

    private bool touchedLastFrame;
    private Vector2 _lastTouchPos;

    private void Start()
    {
        // Get the renderer of the pen.
        _renderer = penTip.GetComponent<Renderer>();
        _colors = Enumerable.Repeat(_renderer.material.color, penSize*penSize).ToArray();
        _tipHeight = penTip.localScale.y;
    }

    private void Update()
    {
        Draw();
    }

    private void Draw()
    {
        // Raycast to the pen.
        if (Physics.Raycast(penTip.position, transform.up, out _touch, _tipHeight))
        {
            // If it is a drawable.
            if(_touch.transform.CompareTag("Drawable") && paper == null)
            {
                if (paper == null)
                    paper = _touch.transform.GetComponent<SignPaper>();
            }

            // Set where the pen is touching.
            _touchPos = new Vector2(_touch.textureCoord.x, _touch.textureCoord.y);

            // btw this code is so shit, the guy writing it is shit so fix it up.
            var x = (int)(_touchPos.x * paper.textureSize.x - (penSize/2));
            var y = (int)(_touchPos.y * paper.textureSize.y - (penSize/2));

            // bounds check
            if (x < 0 || x > paper.textureSize.x || y < 0 || y > paper.textureSize.y)
                return;

            if (touchedLastFrame)
            {
                paper.paperTexture.SetPixels(x, y, penSize, penSize, _colors);
                
                for (float f = 0.01f; f < 1.00f; f+=0.03f)
                {
                    // Filling gaps
                    var _lerpX = (int)Mathf.Lerp(_lastTouchPos.x, x, f);
                    var _lerpY = (int)Mathf.Lerp(_lastTouchPos.y, y, f);
                    
                    paper.paperTexture.SetPixels(_lerpX, _lerpY, penSize, penSize, _colors);
                }
                
                // Apply changes to the new texture.
                paper.paperTexture.Apply();
            }

            _lastTouchPos = new Vector2(x,y);
            touchedLastFrame = true;
            return;
        }

        // Reset marker when released
        paper = null;
        touchedLastFrame = false;
    }
}
