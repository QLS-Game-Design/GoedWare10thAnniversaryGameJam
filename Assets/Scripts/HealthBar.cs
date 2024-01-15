using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Add this line

public class HealthBar : MonoBehaviour
{
    public GameObject player;
    private PlayerMovement playerMovement;
    private static UnityEngine.UI.Image Healthbar;
    public GameObject gameOverPanel; // Reference to the Game Over panel

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerMovement = player.GetComponent<PlayerMovement>();
        Healthbar = GetComponent<UnityEngine.UI.Image>();
    }

    // Update is called once per frame
    void Update()
    {
        Healthbar.fillAmount = playerMovement.currHealth / playerMovement.maxHealth;

        // Check if the player's health is equal to or less than 0
        if (playerMovement.currHealth <= 0)
        {
            // Display the Game Over panel
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
