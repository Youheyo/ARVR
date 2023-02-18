using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    [SerializeField] private GameObject EnemyObjectReference;
    public Transform Target;

    List<GameObject> EnemyList;

    public float maxSpawnInterval = 5.0f;
    public float minSpawnInterval = 1.0f;
    bool spawnAvailable = false;

    // Start is called before the first frame update
    void Start()
    {
        EnemyObjectReference.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnAvailable)
        {
            StartCoroutine(SpawnEnemy());
        }
    }

    IEnumerator SpawnEnemy()
    {
        spawnAvailable = false;
        //instantiate enemy
        GameObject enemyInstance = Instantiate(EnemyObjectReference, this.transform.position, Quaternion.identity);
        enemyInstance.GetComponent<EnemyScript>().targetTransform = Target.transform;
        enemyInstance.SetActive(true);
        //EnemyList.Add(enemyInstance);
        yield return new WaitForSeconds(Random.Range(minSpawnInterval, maxSpawnInterval));
        spawnAvailable = true;
    }

    public void StartSpawn(){
        StartCoroutine(StartSpawnTimer());
    }
    public void SpawnerGameEndState(){
        StopAllCoroutines();
        spawnAvailable = false;
        //ClearEnemies();
    }

    public void ClearEnemies(){
        foreach(GameObject x in EnemyList){
            Destroy(x.gameObject);
        }
    }

    public IEnumerator StartSpawnTimer(){
        yield return new WaitForSeconds(5);
        spawnAvailable = true;

    }
}
