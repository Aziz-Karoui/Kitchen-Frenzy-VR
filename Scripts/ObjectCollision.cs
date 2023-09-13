using UnityEngine;

public class ObjectCollision : MonoBehaviour
{
    public GameObject objectA;  // Object that collides with objectB
    public GameObject objectB;  // Object that objectA collides with
    public GameObject objectC; 
    public float offset = 0.1f; 

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == objectB)
        {
            Vector3 position = objectB.transform.position;
            position.z += offset;

            Instantiate(objectC, position, Quaternion.identity);
        }
    }
}
