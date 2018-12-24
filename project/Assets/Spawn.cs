using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

    public GameObject enemyBunny;
    public GameObject enemyBear;
    public GameObject enemyHelle;
    public float spawnTimebunny = 15;
    public float spawnTimebear = 20;
    public float spawnTimehelle = 30;
    private float timerbunny = 0;
    private float timerbear = 0;
    private float timerhelle = 0;

    void Start()
    {
        InvokeRepeating("ACC", 0, 1);
    }

    void ACC()
    {
        spawnTimebunny -= 0.05f;
        spawnTimebear-= 0.05f;
        spawnTimehelle -= 0.05f;
    }

    void Update()
    {
        timerbunny += Time.deltaTime;
        timerbear += Time.deltaTime;
        timerhelle += Time.deltaTime;
        if (timerbunny >= spawnTimebunny)
        {
            timerbunny -= spawnTimebunny;
            SpawnBunny();
        }
        if (timerbear >= spawnTimebear)
        {
            timerbear -= spawnTimebear;
            SpawnBear();
        }
        if (timerhelle >= spawnTimehelle)
        {
            timerhelle -= spawnTimehelle;
            SpawnHelle();
        }
    }

    void SpawnBunny()
    {
        GameObject.Instantiate(enemyBunny, transform.position, transform.rotation);
    }
    void SpawnBear()
    {
        GameObject.Instantiate(enemyBear, transform.position, transform.rotation);
    }
    void SpawnHelle()
    {
        GameObject.Instantiate(enemyHelle, transform.position, transform.rotation);
    }

}
