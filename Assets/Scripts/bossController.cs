using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class bossController : MonoBehaviour
{
    [Header("object")]
    [SerializeField] GameObject bomb;
    [SerializeField] GameObject shark;
    [Header("time")]
    [SerializeField] float bombInterval = 0.5f;
    [SerializeField] float sharkInterval = 10;

    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private int hookCount = 5;
    void Start()
    {
        GameObject newEnemy1 = Instantiate(bomb, new Vector3(Random.Range(-5f, 5), Random.Range(-6f, 6f), 0), Quaternion.identity);
        GameObject newEnemy2 = Instantiate(bomb, new Vector3(Random.Range(-5f, 5), Random.Range(-6f, 6f), 0), Quaternion.identity);
        StartCoroutine(spawnBomb(bombInterval, bomb));
        StartCoroutine(spawnBomb(bombInterval, bomb));
        StartCoroutine(spawnBomb(bombInterval, bomb));
        StartCoroutine(spawnBomb(bombInterval, bomb));
        StartCoroutine(spawnBomb(bombInterval, bomb));
        StartCoroutine(spawnShark(sharkInterval, shark));
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
    
        private IEnumerator spawnBomb(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        Vector3 safePos = GetSafeSpawnPosition(2.0f);
        GameObject newEnemy = Instantiate(enemy, safePos, Quaternion.identity);
        StartCoroutine(spawnBomb(interval, enemy));
    
    }

    private IEnumerator spawnShark(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        Vector3 safePos = GetSafeSpawnPosition(4.0f);
        Instantiate(enemy, safePos, Quaternion.identity);
        StartCoroutine(spawnShark(interval, enemy));
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