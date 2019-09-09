using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureScroll : MonoBehaviour
{
    // Scroll main texture based on time
    public bool x, y;
    [Range(0.0f,1.0f)]
    public float scrollSpeed = 0.01f;
    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        
        float offset = Time.time * scrollSpeed;
        if (x)
            rend.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
        if (y)
            rend.material.SetTextureOffset("_MainTex", new Vector2(0, offset));
    }
}
