using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorController : MonoBehaviour
{
    private Rigidbody2D m_Rb2d;
    private Animator m_Anim;
    private Camera m_Camera;
    public JogadorController m_Player;
    public int m_Damage = 1;
    public int m_Points = 5;
    private bool m_Destroyed = false;
    private float m_ScreenBottomLimit;

    // Start is called before the first frame update
    void Start()
    {
        m_Rb2d = gameObject.GetComponent<Rigidbody2D>();
        m_Anim = gameObject.GetComponent<Animator>();
        m_Player = (JogadorController)FindObjectOfType(typeof(JogadorController));
        m_Rb2d.velocity = new Vector2(0.0f, -1.0f);
        m_Camera = (Camera)FindObjectOfType(typeof(Camera));
        m_ScreenBottomLimit = m_Camera.transform.position.y - (m_Camera.rect.height * m_Camera.orthographicSize);
    }

    void FixedUpdate()
    {
        float meteorPosY = this.transform.position.y;
        if ((meteorPosY <= m_ScreenBottomLimit) && !m_Destroyed) {
            DestroyMeteor();
        }
    } 

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Jogador")) {
            m_Player.DecrementLife(m_Damage);
            Explode();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DestroyMeteor(float delay=0.0f)
    {
        if(!m_Destroyed) {
            m_Destroyed = true;
            Destroy(this.gameObject,delay);
        }
    }

    public void GotHit() {
        if(!m_Destroyed) {
            Explode();
            m_Player.AddScore(m_Points);
        }
    }

    public void Explode()
    {
        if(!m_Destroyed && m_Rb2d && m_Anim) {
            m_Rb2d.velocity = new Vector2(0.0f, 0.0f);
            m_Anim.SetTrigger("explode");
            DestroyMeteor(0.5f);
        }
    }

    public bool IsDestroyed()
    {
        return m_Destroyed;
    }
}
