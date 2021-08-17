using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private Rigidbody2D m_Rb2d;
    private Animator m_Anim;
    private Camera m_Camera;
    private float m_ScreenTopLimit;
    
    // Start is called before the first frame update
    void Start()
    {
        m_Rb2d = gameObject.GetComponent<Rigidbody2D>();
        m_Rb2d.velocity = new Vector2(0.0f, 1.0f);
        m_Anim = gameObject.GetComponent<Animator>();
        m_Camera = (Camera)FindObjectOfType(typeof(Camera));
        m_ScreenTopLimit = m_Camera.transform.position.y + (m_Camera.rect.height * m_Camera.orthographicSize);
    }

    void FixedUpdate()
    {
        float projectilePosY = this.transform.position.y;
        if ((projectilePosY >= m_ScreenTopLimit)) {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Meteor")) {
            col.GetComponent<MeteorController>().GotHit();
            Hit();
        }
    }

    void Hit()
    {
        m_Rb2d.velocity = new Vector2(0.0f, 0.0f);
        m_Anim.SetTrigger("explode");
        Destroy(this.gameObject,0.5f);
    }
}
