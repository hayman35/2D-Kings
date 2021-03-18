using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GrappleGun : MonoBehaviour
{
    [SerializeField] float maxDistace = 10f;
    [SerializeField] float step = .2f;
    [SerializeField] LayerMask mask;
    [SerializeField] LineRenderer line;

    DistanceJoint2D joint;
    Vector3 targetPos;
    RaycastHit2D hit;


    // Start is called before the first frame update
    void Start()
    {
        joint = GetComponent<DistanceJoint2D>();   
        joint.enabled = false;
        line.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (joint.distance > 1f)
        {
            joint.distance -= step;
        }else
        {
            line.enabled = false;
            joint.enabled = false;
        }
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            targetPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            targetPos.z = 0;
            hit = Physics2D.Raycast(transform.position,targetPos-transform.position, maxDistace, mask);

            // decide what to hook onto too
            if (hit.collider != null && hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
            {
                joint.enabled = true;
                joint.connectedBody = hit.collider.gameObject.GetComponent<Rigidbody2D>();
                joint.connectedAnchor = hit.point - new Vector2(hit.collider.transform.position.x, hit.collider.transform.position.y);
                joint.distance = Vector2.Distance(transform.position,hit.point);
                line.enabled = true;
                line.SetPosition(0, transform.position);
                line.SetPosition(1, hit.point);
            }
        }

        if (Mouse.current.leftButton.isPressed)
        {
            line.SetPosition(0, transform.position);
        }

        if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            joint.enabled = false;
            line.enabled = false;
        }
    }
}
