using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D m_Rb2d;
    private PhotonView m_PhotonView;
    private Text m_TextScore;

    public float m_ThrustForce = 0.5f;
    public float m_Torque = 1.2f;
    public int m_Score = 0;

    // Start is called before the first frame update
    void Start()
    {
        m_Rb2d = GetComponent<Rigidbody2D>();
        m_PhotonView = GetComponent<PhotonView>();
        m_TextScore = this.gameObject.transform.GetChild(0).GetChild(2).GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(m_PhotonView.IsMine) {
            Move();
        }
    }

    void Move()
    {
        float turn = Input.GetAxis("Horizontal");
        m_Rb2d.AddTorque(-1 * (turn*1.2f) * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftControl)) {
            m_Rb2d.AddForce(transform.up * m_ThrustForce);
        }
    }

    public void AddScore(int points)
    {
        this.m_Score += points;
        this.m_TextScore.text = this.m_Score.ToString();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Gem")) {
            AddScore(1);
            Destroy(col.gameObject);
        }
    }


}
