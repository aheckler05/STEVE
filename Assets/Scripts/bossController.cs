using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class bossController : MonoBehaviour
{
    [Header("object")]
    [SerializeField] GameObject bomb;
    [SerializeField] GameObject shark;
    [Header("time")]
    [SerializeField] float bombInterval = 3.5f;
    [SerializeField] float sharkInterval = 7.5f;

    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private int hookCount = 5;
    void Start()
    {
        StartCoroutine(spawn1(bombInterval, bomb));
        StartCoroutine(spawn2(sharkInterval, shark));
    }
    
    private Vector3 GetSafeSpawnPosition(float minDistance)
    {
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        Vector3 spawnPos;

        do
        {
            spawnPos = new Vector3(
                Random.Range(-5f, 5f),
                Random.Range(-6f, 6f),
                0
            );
        }
        while (Vector3.Distance(spawnPos, player.position) < minDistance);

        return spawnPos;
        }
    
        private IEnumerator spawn1(float interval1,  GameObject enemy1)
    {
        while(true) {
            yield return new WaitForSeconds(interval1);
                Vector3 safePos = GetSafeSpawnPosition(2.0f);
                GameObject newEnemy = Instantiate(enemy1, safePos, Quaternion.identity);
                Vector3 safePos2 = GetSafeSpawnPosition(2.0f);
                GameObject newEnemy3 = Instantiate(enemy1, safePos2, Quaternion.identity);
                Vector3 safePos3 = GetSafeSpawnPosition(2.0f);
                GameObject newEnemy4 = Instantiate(enemy1, safePos3, Quaternion.identity);
        }  
    }

            private IEnumerator spawn2(float interval1,  GameObject enemy1)
    {
        while(true) {
            yield return new WaitForSeconds(interval1);
                Vector3 safePos = GetSafeSpawnPosition(4.25f);
                GameObject newEnemy2 = Instantiate(enemy1, safePos, Quaternion.identity);
        }  
    }

    public void hookDecrease(int i) {
        hookCount = hookCount - i;
        if (hookCount == 0) {
            audioManager.PlaySFX(audioManager.win);
            SceneManager.LoadScene("Combat Victory");
        }
    }

}

//egg