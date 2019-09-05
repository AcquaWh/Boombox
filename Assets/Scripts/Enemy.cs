using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    AudioSource cancion;

    Renderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();

        Debug.Log("I am an enemy, Renderer: " + renderer);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            StartCoroutine("Fade");
        }
    }

    void OnCollisionEnter(Collision otherObj)
    {
        if (otherObj.gameObject.tag == "Player")
        {
            cancion = otherObj.gameObject.GetComponent<AudioSource>();
            Debug.Log("I am an enemy, Cancion: " + cancion.name);
            if (!cancion.isPlaying)
            {
                cancion.Play();
            }
        }
    }

    private void OnCollisionExit(Collision otherObj)
    {
        if (otherObj.gameObject.tag == "Player")
        {
            cancion = otherObj.gameObject.GetComponent<AudioSource>();
            Debug.Log("I am an enemy, Cancion: " + cancion.name);
            cancion.Pause();
        }
    }

    IEnumerator Fade()
    {
        for (float ft = 1f; ft >= 0; ft -= 0.1f)
        {
            Color c = renderer.material.color;
            c.a = ft;
            renderer.material.color = c;
            yield return null;
        }
    }
}
