using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorController : MonoBehaviour
{
    private Rigidbody2D m_rb;
    private Animator m_anim;
    public JogadorController m_player;
    public float m_Damage = 1.0f;
    public int m_points = 5;
    private bool destroyed = false;

    // Start is called before the first frame update
    void Start()
    {
        m_rb = gameObject.GetComponent<Rigidbody2D>();
        m_anim = gameObject.GetComponent<Animator>();
        m_player = (JogadorController)FindObjectOfType(typeof(JogadorController));
        m_rb.velocity = new Vector2(0.0f, -1.0f);
    }

    void FixedUpdate()
    {

    } 

    // Update is called once per frame
    void Update()
    {

    }

    void Hit()
    {
        destroyed = true;
        m_rb.velocity = new Vector2(0.0f, 0.0f);
        m_anim.SetTrigger("explode");
        Destroy(this.gameObject,0.5f);
    }
}
