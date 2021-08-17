using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorGenerator : MonoBehaviour
{
    
    public int m_MeteorSpawnTimeSec = 3;
    public GameObject m_Meteor;
    private float m_Timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        m_Timer += Time.deltaTime;
        
        if (m_Timer > m_MeteorSpawnTimeSec) {
            m_Timer = 0.0f;
            Spawn();
        }
    }

    void Spawn()
    {
        float spawnX = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, 
                                    Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);
        Vector2 spawnPosition = new Vector2(spawnX, 1);
        Instantiate(m_Meteor, spawnPosition, Quaternion.identity);
    }
}
