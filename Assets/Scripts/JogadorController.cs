using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JogadorController : MonoBehaviour
{

    private Animator m_Anim;
    private Rigidbody2D m_Rb2d;
    public GameObject m_Projectile;
    private Camera m_Camera;

    public int m_Life = 5;
    public float m_Speed = 0.2f;
    private float m_Timer = 0.0f;
    public float m_ShotInterval = 0.5f;
    public int m_Score = 0;
    public int m_VictoryScore = 30;
    private float m_ScreenRightLimit;
    private float m_ScreenLeftLimit;

    // Start is called before the first frame update
    void Start()
    {
        m_Anim = GetComponent<Animator>();
        m_Rb2d = GetComponent<Rigidbody2D>();
        m_Camera = (Camera)FindObjectOfType(typeof(Camera));
        m_ScreenRightLimit = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x;
        m_ScreenLeftLimit = Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x;
    }

    // Update is called once per frame
    void Update()
    {
        m_Timer += Time.deltaTime;
        Move();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space)) {
            Shoot();
        }
    }

    void Move()
    {
        float direction = Input.GetAxis("Horizontal");
        m_Rb2d.velocity = new Vector2(direction * m_Speed, m_Rb2d.velocity.y);
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
        TestVictoryCondition();
    }

    public void DecrementLife(int damage)
    {
        m_Life -= damage;
        TestDefeatCondition();
    }

    void TestVictoryCondition() {
        if (this.m_Score >= m_VictoryScore) {
            SceneManager.LoadScene("Scenes/Vitoria");
        }
    }

    void TestDefeatCondition() {
        if (this.m_Life <= 0) {
            SceneManager.LoadScene("Scenes/Derrota");
        }
    }
}
