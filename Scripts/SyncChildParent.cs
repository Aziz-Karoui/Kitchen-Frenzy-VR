using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncChildParent : MonoBehaviour
{
    private Vector3 initialChildPosition;
    private Vector3 initialParentPosition;
    private bool isParentMoveEnabled = false;

    private void Start()
    {
        initialChildPosition = transform.localPosition;
        if (transform.parent != null)
        {
            initialParentPosition = transform.parent.localPosition;
        }
    }

    private void Update()
    {
        if (transform.localPosition != initialChildPosition)
        {
            if (transform.parent != null)
            {
                isParentMoveEnabled = true;
            }
        }
        if (isParentMoveEnabled)
        {
            transform.parent.localPosition = transform.parent.localPosition + (transform.localPosition - initialChildPosition);
        }
    }
}