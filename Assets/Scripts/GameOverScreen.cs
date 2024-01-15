using UnityEngine;
using UnityEngine.UI;

public class GameOverScene : MonoBehaviour
{
    public Text timeSurvivedText;

    void Start()
    {
        // Retrieve the time survived value from PlayerPrefs
        float timeSurvived = PlayerPrefs.GetFloat("TimeSurvived", 0f);

        // Display the time survived in the UI Text
        timeSurvivedText.text = "Time Survived: " + FormatTime(timeSurvived);
    }

    string FormatTime(float timeInSeconds)
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
