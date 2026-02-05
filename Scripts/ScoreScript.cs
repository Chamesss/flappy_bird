using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class ScoreScript : MonoBehaviour
{
    private Label scoreLabel;
    private int score = 0;
    [SerializeField] private GameObject gameOverScreen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        scoreLabel = root.Q<Label>("score");
        scoreLabel.text = "Score: " + score;
       
    }
    
    public void SetScore(int amount = 1)
    {
        if (scoreLabel != null)
        {
            score += amount;
            scoreLabel.text = "Score: " + score;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0;
    }
    
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
