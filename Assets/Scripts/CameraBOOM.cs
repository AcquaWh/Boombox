using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBOOM : MonoBehaviour
{
    public GameObject target;

    Camera camaralol;

    // Start is called before the first frame update
    void Start()
    {
       camaralol = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        camaralol.transform.LookAt(target.transform);
    }
}
