using System;
using System.Collections;
using UnityEngine;
using TMPro;

public class BasketController : MonoBehaviour
{
    [SerializeField] private ColorType colorType;
    [SerializeField] private float _delayPerSecond = 2f;
    [SerializeField] private TMP_Text scoreText;

    private float spawnDelay = 0;
    private int _currentScore;

    private Collider2D collider;
    private SpriteRenderer spriteRenderer;
    
    private void Start()
    {
        collider = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Time.time >= spawnDelay) //Delay for setting color
        {
            SetRandomColor();
            spawnDelay = Time.time + _delayPerSecond;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Figure") && collision.GetComponent<Figure>().colorType == colorType) //Score update
        {
            _currentScore++;
            if (PlayerPrefs.GetInt("Score") < _currentScore)
            { 
                PlayerPrefs.SetInt("Score", _currentScore);
            }

        }
        else
            _currentScore--;
        scoreText.text = _currentScore.ToString();
        Destroy(collision.gameObject);
    }

    private void SetRandomColor()
    {
        var values = Enum.GetValues(typeof(ColorType));
        colorType = (ColorType)UnityEngine.Random.Range(0, values.Length);

        switch (colorType)
        {
            case ColorType.Red:
                spriteRenderer.material.color = Color.red;
                break;
            case ColorType.Blue:
                spriteRenderer.material.color = Color.blue;
                break;
            case ColorType.Green:
                spriteRenderer.material.color = Color.green;
                break;
            case ColorType.Yellow:
                spriteRenderer.material.color = Color.yellow;
                break;
        }
    }
}
