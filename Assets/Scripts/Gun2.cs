using UnityEngine;
using UnityEngine.InputSystem;

public class Gun2 : MonoBehaviour
{
    public LayerMask ropeLayerMask;

    public float distance = 90.0f;

    public Transform firePoint;

    LineRenderer line;
    DistanceJoint2D rope;

    Vector2 lookDirection;

    bool checker = true;

    void Start()
    {
        rope = gameObject.AddComponent<DistanceJoint2D>();
        line = GetComponent<LineRenderer>();

        rope.enabled = false;
        line.enabled = false;
    }

    void Update()
    {
        line.SetPosition(0, firePoint.position);

        lookDirection = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()) - transform.position; 

        if (Mouse.current.rightButton.wasPressedThisFrame && checker == true)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, lookDirection, distance, ropeLayerMask);

            if (hit.collider != null)
            {
                checker = false;
                SetRope(hit);
            }
        }
        else if (Mouse.current.rightButton.wasReleasedThisFrame && checker == false)
        {
            checker = true;
            DestroyRope();
        }
    }

    void SetRope(RaycastHit2D hit)
    {
        rope.enabled = true;
        rope.enableCollision = true;
        rope.connectedAnchor = hit.point;
        SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.Player_Grapple);

        line.enabled = true;
        line.SetPosition(1, hit.point);
    }

    void DestroyRope()
    {
        rope.enabled = false;
        line.enabled = false;
    }
}
