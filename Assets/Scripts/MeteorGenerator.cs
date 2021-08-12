using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorGenerator : MonoBehaviour
{
    
    public int MeteorSpawnTimeSec = 3;
    public GameObject Meteor;
    private float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
        if (timer > MeteorSpawnTimeSec) {
            timer = 0;
            Spawn();
        }
    }

    void Spawn()
    {
        float spawnX = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, 
                                    Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);
        Vector2 spawnPosition = new Vector2(spawnX, 1);
        Instantiate(Meteor, spawnPosition, Quaternion.identity);
    }
}
