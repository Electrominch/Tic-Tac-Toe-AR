using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextWithBack : MonoBehaviour
{
    [SerializeField] private Image _back;
    [SerializeField] private TextMeshProUGUI _text;

    public void Hide()
    {
        _back.enabled = false;
        _text.enabled = false;
    }

    public void Show(string text, Color back)
    {
        _back.enabled = true;
        _text.enabled = true;

        _back.color = back;
        _text.text = text;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
