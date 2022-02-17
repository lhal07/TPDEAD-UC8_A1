using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour
{

    public Vector2 cameraChange;
    public Vector3 playerChange;
    private CameraMovement cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.GetComponent<CameraMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Jogador") && !other.isTrigger) {
            cam.m_MinPosition += cameraChange;
            cam.m_MaxPosition += cameraChange;
            other.transform.position += playerChange;
        }
    }

}
