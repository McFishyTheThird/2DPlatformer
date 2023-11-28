using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField]
    float rotateSpeed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotateSpeed);
    }
}
