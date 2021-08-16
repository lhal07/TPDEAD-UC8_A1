using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JogadorController : MonoBehaviour
{

    private Animator anim;
    private Rigidbody2D rb2d;

    public int Life;
    public float Speed;
    [HideInInspector] public int Score = 0;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        float translationY = 0;
        float translationX = Speed;
        if (Input.GetKey("a")) {
            transform.Translate((-1*translationX),translationY,0);
        }
        if (Input.GetKey("d")) {
            transform.Translate(translationX,translationY,0);
        }
    }

    public void AddScore(int points)
    {
        this.Score += points;
    }
}
