using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public Rigidbody2D rb;
    private Vector2 startPos;
    public float fallHeight = 10f;
    public bool respawns = true;
    
    
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        rb.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        float dist = startPos.y - transform.position.y;
        if (dist > fallHeight && respawns)
        {
            rb.isKinematic = true;
            rb.velocity = new Vector3(0, 0, 0);
            transform.position = startPos;
        }
    }

}
