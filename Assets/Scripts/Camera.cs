using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject target;

    Camera camara;

    // Start is called before the first frame update
    void Start()
    {
       camara = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        camara.transform.LookAt(target.transform);
    }
}
