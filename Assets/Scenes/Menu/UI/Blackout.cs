using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blackout : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] [Range(0,1)] private float _maxA = 1f;
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _delayOnBlack =0.1f;

    public bool Started { get; private set;  } = false;
    public void StartBlackout(Action callbackOnBlack, float delayOnBlack = -1)
    {
        if(Started == false)
            StartCoroutine(DoBlackout(callbackOnBlack, delayOnBlack));
    }

    private IEnumerator DoBlackout(Action callbackOnBlack, float delayOnBlack = -1)
    {
        int count = 0;
        Started = true;
        _image.raycastTarget = true;
        if (delayOnBlack < 0)
            delayOnBlack = _delayOnBlack;
        while (_image.color.a < _maxA)
        {
            _image.color = new Color(_image.color.r, _image.color.g, _image.color.b, _image.color.a + Time.deltaTime * _speed);
            yield return null;
            count++;
        }
        yield return null;
        callbackOnBlack();
        yield return null;
        yield return new WaitForSeconds(delayOnBlack);
        while (_image.color.a > 0)
        {
            _image.color = new Color(_image.color.r, _image.color.g, _image.color.b, _image.color.a - Time.deltaTime * _speed);
            yield return null;
            count++;
        }
        Debug.Log(count + " " + Time.deltaTime);
        _image.raycastTarget = false;
        Started = false;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
