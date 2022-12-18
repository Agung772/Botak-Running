using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnBox : MonoBehaviour
{
    public bool pauseSpawn;
    public float moveSpeed, speedSpawn, pause;
    public float time, timePause;
    public int randomSpawn;
    public GameObject[] boxPrefab;

    private void Start()
    {
        time = speedSpawn;
        timePause = pause;

        Instantiate(boxPrefab[0], transform.position + new Vector3(0, Random.Range(0, 3), Random.Range(0, 3)), transform.rotation);
        //StartCoroutine(SpawnCoroutine());
        IEnumerator SpawnCoroutine()
        {
            yield return new WaitForSeconds(speedSpawn);

            Instantiate(boxPrefab[0], transform.position + new Vector3(0, Random.Range(0, 3), Random.Range(0, 3)), transform.rotation);

            StartCoroutine(SpawnCoroutine());
        }
    }

    void Update()
    {
        timePause -= Time.deltaTime;
        if (timePause <= 0)
        {
            pauseSpawn = true;
            timePause = 0;
        }

        if (!pauseSpawn)
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);


            time -= Time.deltaTime;
            if (time <= 0)
            {
                randomSpawn = Random.Range(0, boxPrefab.Length);
                Instantiate(boxPrefab[randomSpawn], transform.position + new Vector3(0, Random.Range(0, 3), Random.Range(0, 3)), transform.rotation);
                time = speedSpawn;
            }
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SensorPlayer"))
        {
            pauseSpawn = false;
            timePause = pause;
        }
    }
}
