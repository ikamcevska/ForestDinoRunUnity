using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureScroll : MonoBehaviour
{
    public float scrollSpeed;
    public bool scroll = true;
    Material bgMaterial;
    
    private void Awake()
    {
        bgMaterial = GetComponent<Renderer>().material;
    }
   


    void FixedUpdate()
    {
        if (scroll)
        {
            Vector2 offset = new Vector2(scrollSpeed * Time.time, 0);
            bgMaterial.mainTextureOffset = offset;
        }
    }
}
