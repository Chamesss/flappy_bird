using System;
using UnityEngine;
using UnityEngine.UIElements;

public class RestartGame : MonoBehaviour
{
    private ScoreScript _scoreScript;

    [Obsolete("Obsolete")]
    void Awake()
    {
        _scoreScript = FindObjectOfType<ScoreScript>();
        if (_scoreScript == null)
        {
            Debug.LogError("RestartGame: ScoreScript not found in scene.");
        }
    }

    void Start()
    {
        var uiDoc = GetComponent<UIDocument>();
        var root = uiDoc.rootVisualElement;

        var restartButton = root.Q<Button>("replay");
        if (restartButton == null)
        {
            Debug.LogError("RestartGame: Button name=\"replay\" not found.");
            return;
        }

        restartButton.clicked += _scoreScript.RestartGame;
    }
}