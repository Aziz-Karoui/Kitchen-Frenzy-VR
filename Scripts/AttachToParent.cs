using UnityEngine;

public class AttachToParent : MonoBehaviour
{
    // child.
    public GameObject childObject;

    public Vector3 positionOffset = new Vector3(0f, 0.05f, 0f);

    private bool isExecuted = false;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject == childObject && !isExecuted)
        {
            childObject.transform.parent = transform;

            childObject.transform.position = transform.position + positionOffset;
            isExecuted = true; 
        }
    }
}
