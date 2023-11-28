using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBoi : MonoBehaviour
{
    [SerializeField]
    public float speed = 10;
    public bool movingUp = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(movingUp){
            transform.Translate(0, speed*Time.deltaTime, 0);
        }
        else if(!movingUp){
            transform.Translate(0, -speed*Time.deltaTime,0);
        }
        if(transform.position.y >= 11)
        {
            movingUp = false;
        }
        else if (transform.position.y <= -5)
        {
            movingUp = true;
        }
    }
}
