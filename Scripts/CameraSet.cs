using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSet : MonoBehaviour
{
    public GameObject Cameraa;
    public GameObject Ob1;
    public GameObject Ob2;
    public GameObject Ob3;
    public GameObject Ob4;
    public Vector3 positionOffset = new Vector3(0f, 1f, 0f);

    void Update()
    {
        Cameraa.transform.position = positionOffset;
    }
}
