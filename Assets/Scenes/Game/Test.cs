using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    private GridLayoutGroup glg;
    private Rect rect;
    // Start is called before the first frame update
    void Start()
    {
        glg = GetComponent<GridLayoutGroup>();
        rect = GetComponent<RectTransform>().rect;
    }

    // Update is called once per frame
    void Update()
    {
        var wigth = rect.width - glg.padding.left - glg.padding.right;
        var childCount = transform.childCount;
        var cellSize = wigth / Mathf.Sqrt(childCount);
        glg.cellSize = new Vector2(cellSize, cellSize);
    }
}
