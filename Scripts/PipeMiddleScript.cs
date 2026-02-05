using System;
using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

   private ScoreScript _scoreScript;
    private void OnTriggerEnter2D(Collider2D collision )
    {
        if (_scoreScript != null)
        {
            _scoreScript.SetScore();
        }
    }

    private void Awake()
    {
        _scoreScript = GameObject.FindGameObjectWithTag("logic").GetComponent<ScoreScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
