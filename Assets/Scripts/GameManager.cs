using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public MadnessBar madnessBar;
    public GameObject enemyPrefab;
    public GameObject spikePrefab;
    private GameObject player;
    public float enemySpawnInterval = 5f;
    public float spikeSpawnInterval = 7f;
    public float madnessThreshold = 100f;

    public Text timeSurvivedText;
    private float timeSurvived;
    private bool isGameOver = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.LogError("Player GameObject not found!");
            return;
        }

        InvokeRepeating("SpawnEnemies", 0f, CalculateEnemySpawnInterval());
        InvokeRepeating("SpawnSpikes", 0f, CalculateSpikeSpawnInterval());

        timeSurvived = 0f;
        isGameOver = false;
    }

    void Update()
    {
        if (!isGameOver)
        {
            timeSurvived += Time.deltaTime;
            timeSurvivedText.text =  FormatTime(timeSurvived);

            if (madnessBar.getMadness() > madnessThreshold)
            {
                // Add your wacky event here when the madness bar reaches full
            }

            if (player.GetComponent<PlayerMovement>().currHealth <= 0)
            {
                GameOver();
            }
        }
    }

    float CalculateEnemySpawnInterval()
    {
        return Mathf.Max(enemySpawnInterval - madnessBar.getMadness() / 10f, 1f);
    }

    float CalculateSpikeSpawnInterval()
    {
        return Mathf.Max(spikeSpawnInterval - madnessBar.getMadness() / 10f, 1f);
    }

    void SpawnEnemies()
    {
        if (madnessBar.getMadness() > madnessThreshold)
        {
            SpawnEnemy(player.transform.position + (Vector3)Random.insideUnitCircle * 5f);
        }
    }

    void SpawnSpikes()
    {
        if (madnessBar.getMadness() > madnessThreshold)
        {
            SpawnSpike(player.transform.position + Vector3.up * 2f);
        }
    }

    void SpawnEnemy(Vector3 position)
    {
        Instantiate(enemyPrefab, position, Quaternion.identity);
    }

    void SpawnSpike(Vector3 position)
    {
        Instantiate(spikePrefab, position, Quaternion.identity);
    }

    void GameOver()
    {
        // Save the timeSurvived value to PlayerPrefs
        PlayerPrefs.SetFloat("TimeSurvived", timeSurvived);
        PlayerPrefs.Save();

        // Load the Game Over scene
        SceneManager.LoadScene("GameOverScene");
    }

    string FormatTime(float timeInSeconds)
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
