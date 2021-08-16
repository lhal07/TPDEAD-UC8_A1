using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorController : MonoBehaviour
{
    private Rigidbody2D m_rb;
    private Animator m_anim;
    private Camera m_camera;
    public JogadorController m_player;
    public int m_Damage = 1;
    public int m_points = 5;
    private bool m_Destroyed = false;
    private float m_ScreenBottomLimit;

    // Start is called before the first frame update
    void Start()
    {
        m_rb = gameObject.GetComponent<Rigidbody2D>();
        m_anim = gameObject.GetComponent<Animator>();
        m_player = (JogadorController)FindObjectOfType(typeof(JogadorController));
        m_rb.velocity = new Vector2(0.0f, -1.0f);
        m_camera = (Camera)FindObjectOfType(typeof(Camera));
        m_ScreenBottomLimit = m_camera.transform.position.y - (m_camera.rect.height * m_camera.orthographicSize);
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
        if (col.tag == "Jogador")
        Hit();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void DestroyMeteor()
    {
        m_Destroyed = true;
        Destroy(this.gameObject,0.5f);
    }

    void Hit()
    {
        m_rb.velocity = new Vector2(0.0f, 0.0f);
        m_player.DecrementLife(m_Damage);
        m_player.AddScore(m_points);
        m_anim.SetTrigger("explode");
        DestroyMeteor();
    }
}
