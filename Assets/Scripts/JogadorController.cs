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
    [HideInInspector] public int m_Score = 0;
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
        float playerPosX = this.transform.position.x;
        if ((playerPosX >= m_ScreenLeftLimit)) {
            transform.Translate((-1*m_Speed),0,0);
        }
    }

    void MoveRight()
    {
        float playerPosX = this.transform.position.x;
        if ((playerPosX <= m_ScreenRightLimit)) {
            transform.Translate((m_Speed),0,0);
        }
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
