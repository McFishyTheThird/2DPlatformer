using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGeoffreyController : MonoBehaviour
{
    [SerializeField]
    float jumpForce = 300;
    bool hasReleasedJumpButton = true;
    Rigidbody2D rigidBody;
    Vector2 pos;
    // Start is called before the first frame update
    void Start()
    {
        pos.x = transform.position.x;
        pos.y = transform.position.y;
        transform.position = pos;
    }
    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Jump") > 0 && hasReleasedJumpButton == true)
        {
            rigidBody.AddForce(Vector2.up * jumpForce);
            hasReleasedJumpButton = false;
            Debug.Log(hasReleasedJumpButton);
        }
        if (Input.GetAxisRaw("Jump") == 0)
        {
            hasReleasedJumpButton = true;
            Debug.Log(hasReleasedJumpButton);

        }

        if(transform.position.y < -Camera.main.orthographicSize - 1)
        {
            pos.y = Camera.main.orthographicSize + 1;
            transform.position = pos;
        }
        else if(transform.position.y > Camera.main.orthographicSize + 1)
        {
            pos.y = -Camera.main.orthographicSize - 1;
            transform.position = pos;
        }
    }

    private Vector2 GetFootPosition()
    {
        float height = GetComponent<Collider2D>().bounds.size.y;
        return transform.position + Vector3.down * height / 2;
    }
    private Vector2 GetFootSize()
    {
        return new Vector2(GetComponent<Collider2D>().bounds.size.x * 0.9f, 0.1f);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(GetFootPosition(), GetFootSize());
    }
}
