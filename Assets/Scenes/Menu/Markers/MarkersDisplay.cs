using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkersDisplay : MonoBehaviour
{
    [SerializeField] private GameObject m_Prefab;

    public void Display()
    {
        Debug.Log("Display...");
        DeleteOld();
        DisplayAll();
    }

    private void DeleteOld()
    {
        foreach(Transform t in transform)
            if (t.gameObject.tag == "marker")
                Destroy(t.gameObject);
    }

    private void DisplayAll()
    {
        var markers = MarkersVault.GetAll;
        foreach (var kp in markers)
            DisplayButton(kp.Key, kp.Value);
    }

    private void DisplayButton(string name, Sprite sprite)
    {
        var markerBut = GameObject.Instantiate(m_Prefab, transform).GetComponent<MarkerButton>();
        var index = transform.childCount - 2;
        markerBut.gameObject.transform.SetSiblingIndex(index);
        markerBut.gameObject.tag = "marker";
        markerBut.MarkerName = name;
        markerBut.SetSprite(sprite);
    }
}
