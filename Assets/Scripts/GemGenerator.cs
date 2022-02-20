using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemGenerator : MonoBehaviour
{

    public int m_GemSpawnTimeSec = 5;
    public GameObject m_Gem;
    private float m_Timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        m_Timer += Time.deltaTime;

        if (m_Timer > m_GemSpawnTimeSec) {
            m_Timer = 0.0f;
            Spawn();
        }
    }

    void Spawn()
    {
        float spawnX = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, 
                                    Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);
        float spawnY = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, 
                                    Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
        Vector2 spawnPosition = new Vector2(spawnX, spawnY);
        Instantiate(m_Gem, spawnPosition, Quaternion.identity);
    }
}
