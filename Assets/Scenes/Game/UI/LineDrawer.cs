using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LineDrawer : MonoBehaviour
{
    [SerializeField] private Transform _line;

    public void Draw(Vector2[] dots, float cellSide)
    {
        var scale = _line.localScale;
        scale.y = (Vector2.Distance(dots[0], dots.Last()) + cellSide*0.5f) / 100f;
        scale.x = cellSide / 100f*0.2f;
        _line.localScale = scale;

        var mid = FindMid(dots[0], dots.Last());
        _line.localPosition = new Vector3(mid.x, mid.y, _line.position.z);

        _line.localRotation = Quaternion.FromToRotation(Vector2.up, dots[0]-dots.Last());
    }

    private Vector2 FindMid(Vector2 a, Vector2 b)
    {
        return (a+b)/2;
    }
}
