using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timerText.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCountdown();
    }

    private void UpdateCountdown()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime < 0)
        {
            remainingTime = 0;
        }

        int minutes = Mathf.FloorToInt(remainingTime / 60); // To calculate the minutes from the time
        int seconds = Mathf.FloorToInt(remainingTime % 60); // To calculate the seconds from the time
        timerText.text = string.Format("{0:0}:{1:00}", minutes, seconds);
    }
}
