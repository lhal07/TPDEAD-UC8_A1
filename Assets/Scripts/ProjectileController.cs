using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private Rigidbody2D m_Rb2d;
    private Animator m_Anim;
    private Camera m_Camera;
    private float m_ScreenTopLimit;
    private bool m_Destroyed = false;
    public float m_Speed = 100.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        m_Rb2d = gameObject.GetComponent<Rigidbody2D>();
        m_Rb2d.AddForce(new Vector2(0.0f, m_Speed));
        m_Anim = gameObject.GetComponent<Animator>();
        m_Camera = (Camera)FindObjectOfType(typeof(Camera));
        m_ScreenTopLimit = m_Camera.transform.position.y + (m_Camera.rect.height * m_Camera.orthographicSize);
    }

    void FixedUpdate()
    {
        float projectilePosY = this.transform.position.y;
        if ((projectilePosY >= m_ScreenTopLimit)) {
            DestroyProjectile();
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Meteor")) {
            MeteorController meteor = col.GetComponent<MeteorController>();
            if (meteor && !(meteor.IsDestroyed() || m_Destroyed)) {
                meteor.GotHit();
                Hit();
            }
        }
    }

    void Hit()
    {
        if(!m_Destroyed && m_Rb2d && m_Anim) {
            m_Rb2d.velocity = new Vector2(0.0f, 0.0f);
            m_Anim.SetTrigger("explode");
            DestroyProjectile();
        }
    }

    void DestroyProjectile(float delay=0.0f) {
        if (!m_Destroyed) {
            m_Destroyed = true;
            Destroy(this.gameObject,delay);
        }
    }

}
