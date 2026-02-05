using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class ScoreScript : MonoBehaviour
{
    private Label scoreLabel;
    private int score = 0;
    [SerializeField] private GameObject gameOverScreen;
    public static ScoreScript Instance { get; private set; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
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
        if (gameOverScreen == null)
        {
            Debug.LogError("No game over screen found");
            return;
        }
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
