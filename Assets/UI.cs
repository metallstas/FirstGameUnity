using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    public static UI instace;

    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI killsCountText;

    private int killCount;

    private void Awake()
    {
        instace = this;
    }

    private void Update()
    {
        timerText.text = Time.time.ToString("F2") + "s.";
    }

    public void AddKillCount()
    {
        killCount++;
        killsCountText.text = killCount.ToString();
    }
}
