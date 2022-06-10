using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleCanvasToOneUnitWidth : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var rectT = GetComponent<RectTransform>();
        var scale = 1f / rectT.rect.width;
        rectT.localScale = new Vector3(scale, scale, scale);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
