using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Box : MonoBehaviour, IInteractable, IDestructable
{
    private Rigidbody rb;
    private bool beingHold = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (beingHold && Vector3.Distance(transform.position, transform.parent.position) > .1f)
        {
            Vector3 moveDir = (transform.parent.position - transform.position);
            rb.AddForce(moveDir * 10);
        }
    }

    public void Interact(GameObject boxHolder = null)
    {
        if (boxHolder != null)
        {
            if (!beingHold)
                Pickup(boxHolder);
            else
                Drop();
        }
        else if (beingHold)
        {
            Debug.Log("out of range");
            Drop();
        }
    }

    private void Pickup(GameObject boxHolder)
    {
        Debug.Log("pickup");
        transform.SetParent(boxHolder.transform);
        transform.localPosition = new(0, 0, transform.localScale.z + 1);
        transform.rotation = Quaternion.identity;
        rb.useGravity = false;
        rb.freezeRotation = true;
        rb.drag = 10;
        beingHold = true;
    }

    private void Drop()
    {
        Debug.Log("drop");
        transform.parent = null;
        rb.useGravity = true;
        rb.freezeRotation = false;
        rb.drag = 1;
        beingHold = false;
    }
}
