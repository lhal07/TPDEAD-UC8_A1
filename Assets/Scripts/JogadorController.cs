using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JogadorController : MonoBehaviour
{

    private Animator m_Anim;
    private Rigidbody2D m_Rb2d;
    public GameObject m_Projectile;

    public int m_Life = 5;
    public float m_Speed = 0.2f;
    private float m_Timer = 0.0f;
    public float m_ShotInterval = 0.5f;

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
        m_Timer += Time.deltaTime;
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A)) {
            MoveLeft();
        }
        if (Input.GetKey(KeyCode.D)) {
            MoveRight();
        }
        if (Input.GetKey(KeyCode.Space)) {
            Shoot();
        }
    }

    void MoveLeft()
    {
      transform.Translate((-1*m_Speed),0,0);
    }

    void MoveRight()
    {
      transform.Translate((m_Speed),0,0);
    }

    void Shoot()
    {
        if (m_Timer > m_ShotInterval) {
            m_Timer = 0.0f;
            Instantiate(m_Projectile,this.transform.GetChild(0).position, Quaternion.identity);
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
