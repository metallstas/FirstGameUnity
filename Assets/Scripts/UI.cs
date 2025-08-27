using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public static UI instace;

    [SerializeField] private GameObject gameOver_UI;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI killsCountText;

    private int killCount;

    private void Awake()
    {
        instace = this;
        Time.timeScale = 1f;
    }

    private void Update()
    {
        timerText.text = Time.time.ToString("F2") + "s.";
    }

    public void Restart()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);
    }

    public void EnableGameOver()
    {
        Time.timeScale = .5f;
        gameOver_UI.SetActive(true);
    }

    public void AddKillCount()
    {
        killCount++;
        killsCountText.text = killCount.ToString();
    }
}
