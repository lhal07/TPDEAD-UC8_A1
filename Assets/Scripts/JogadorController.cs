using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JogadorController : MonoBehaviour
{

    private Animator m_Anim;
    private Rigidbody2D m_Rb2d;

    public int m_Life;
    public float m_Speed;
    [HideInInspector] public int m_Score = 0;

    // Start is called before the first frame update
    void Start()
    {
        m_Anim = GetComponent<Animator>();
        m_Rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        float translationY = 0;
        float translationX = m_Speed;
        if (Input.GetKey("a")) {
            transform.Translate((-1*translationX),translationY,0);
        }
        if (Input.GetKey("d")) {
            transform.Translate(translationX,translationY,0);
        }
    }

    public void AddScore(int points)
    {
        this.m_Score += points;
    }

    public void DecrementLife(int damage)
    {
        m_Life -= damage;
    }
}
