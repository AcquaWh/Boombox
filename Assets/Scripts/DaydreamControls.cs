using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DaydreamControls : MonoBehaviour
{

    [SerializeField]
    LayerMask layerMask;

    private void Update() 
    {
         RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            if(GvrControllerInput.ClickButton)
            {
                AudioCassette cassette = hit.collider.GetComponent<AudioCassette>();
                cassette.StartAudio();
            }
        }    
    }

    void OnDrawGizmos()
    {
       // Draws a 5 unit long red line in front of the object
        Gizmos.color = Color.red;
        Vector3 direction = transform.TransformDirection(Vector3.forward) * 200;
        Gizmos.DrawRay(transform.position, direction);
    }
}
