using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    public float m_LifeTimeSec = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject,m_LifeTimeSec);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
