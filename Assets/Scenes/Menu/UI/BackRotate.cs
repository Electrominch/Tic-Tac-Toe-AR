using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackRotate : MonoBehaviour
{
    [SerializeField] private float speed = 4f;
    
    public void Restart()
    {
        transform.rotation = Quaternion.Euler(Random.value*40-20, Random.value * 40-20, Random.rotation.z*180);
        transform.localPosition = new Vector3(Random.value*400-200, Random.value * 400 - 200, 0);
    }

    void Update()
    {
        transform.Rotate(new Vector3(0,0,-Time.deltaTime*speed));
    }
}
