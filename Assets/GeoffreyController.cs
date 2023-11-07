using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeoffreyController : MonoBehaviour
{
    [SerializeField]
    float jumpForce = 300;
    [SerializeField]
    Transform feet;
    float groundRadius = 0.2f;
    [SerializeField]
    int speed = 10;
    [SerializeField]
    LayerMask groundLayer;

    Vector2 bottomColliderSize = Vector2.zero;
    Vector2 footPosition;
    bool hasReleasedJumpButton = true;
    Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");

        Vector2 movement = new Vector2(moveX, 0);
        movement = movement.normalized * speed * Time.deltaTime;

        transform.Translate(movement);
        
        // bool isGround = Physics2D.OverlapBox(GetFootPosition(), GetFootSize(), 0, groundLayer);
        // if (Input.GetAxisRaw("Jump") > 0 && hasReleasedJumpButton == true && isGround)
        // {
        //     rigidBody.AddForce(Vector2.up * jumpForce);
        //     hasReleasedJumpButton = false;
        //     Debug.Log(hasReleasedJumpButton);
        // }
        // if (Input.GetAxisRaw("Jump") == 0)
        // {
        //     hasReleasedJumpButton = true;
        //     Debug.Log(hasReleasedJumpButton);

        // }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Portal Level Main")
        {
            SceneManager.LoadScene(1);
        }
        else if(other.gameObject.tag == "Portal Level 2")
        {
            SceneManager.LoadScene(2);
        }
        else if(other.gameObject.tag == "Portal Level 3")
        {
            SceneManager.LoadScene(3);
        }
        else if(other.gameObject.tag == "Portal Level 4")
        {
            SceneManager.LoadScene(4);
        }
    }
    // private Vector2 GetFootPosition()
    // {
    //     float height = GetComponent<Collider2D>().bounds.size.y;
    //     return transform.position + Vector3.down * height / 2;
    // }
    // private Vector2 GetFootSize()
    // {
    //     return new Vector2(GetComponent<Collider2D>().bounds.size.x * 0.9f, 0.1f);
    // }
    // private void OnDrawGizmos()
    // {
    //     Gizmos.DrawWireCube(GetFootPosition(), GetFootSize());
    // }

}