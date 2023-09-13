using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    public Material newMaterial; 
    public GameObject targetCube; 
    public float materialChangeDelay = 5.0f; 

    private MeshRenderer meshRenderer;
    private Collider cubeCollider;
    private float timeEnteredTriggerArea = -1.0f;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        cubeCollider = targetCube.GetComponent<Collider>(); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == cubeCollider)
        {
            timeEnteredTriggerArea = Time.time; 
        }
    }

    private void Update()
    {
        if (timeEnteredTriggerArea >= 0.0f && Time.time >= timeEnteredTriggerArea + materialChangeDelay)
        {
            meshRenderer.material = newMaterial; 
            timeEnteredTriggerArea = -1.0f; // reset 
        }
    }
}
