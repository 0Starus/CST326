using TMPro;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TextMeshProUGUI timeText;
    float timeLeft = 500;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeText.text = $"TIME\n {((int)timeLeft).ToString()}";
        timeLeft-= Time.deltaTime;
    }
}
