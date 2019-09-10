using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cassette : MonoBehaviour
{
    public string name;
    public int speed;
    public int driveForce;
    public int jumpForce;
    public GameObject player;
    Renderer renderer;
    AudioSource cancion;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cancion = GetComponent<AudioSource>();
        renderer = GetComponent<Renderer>();

        

        Debug.Log("I am alive and my name is " + name + ", Rigidbody: " + rb + ", cancion: " + cancion);
    }

    // Update is called once per frame
    void Update()
    {
        float distance = speed * Time.deltaTime * Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * distance);
    }

    void FixedUpdate()
    {
        Vector3 force = transform.forward * driveForce * Input.GetAxis("Vertical");
        rb.AddForce(force);
    }

    private void OnTriggerEnter(Collider other) {
        cancion.Play();
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 150, 100), "Game Over");
        if (GUI.Button(new Rect(10, 10, 150, 100), "Reproducir"))
        {
            if (!cancion.isPlaying)
            {
                cancion.Play();
            }
            /*Vector3 force = transform.up * jumpForce;
            rb.AddForce(force);*/
        }
        if (GUI.Button(new Rect(160, 10, 150, 100), "Pausar"))
        {
            cancion.Pause();
            /*Vector3 force = transform.up * jumpForce;
            rb.AddForce(force);*/
        }
        if (GUI.Button(new Rect(310, 10, 150, 100), "Detener"))
        {
            cancion.Stop();
            /*Vector3 force = transform.up * jumpForce;
            rb.AddForce(force);*/
        }
    }

    void Pause()
    {
        Time.timeScale = 0;
    }

    void Resume()
    {
        Time.timeScale = 1;
    }
}
