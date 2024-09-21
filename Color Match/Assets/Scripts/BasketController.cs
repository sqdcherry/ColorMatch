using System;
using System.Collections;
using UnityEngine;

public class BasketController : MonoBehaviour
{
    [SerializeField] private ColorType colorType;
    [SerializeField] private float _delayPerSecond = 2f;

    private float spawnDelay = 0;

    private Collider2D collider;
    private SpriteRenderer spriteRenderer;
    //private PlayerInputs inputs;

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
        if (collision.CompareTag("Figure") && collision.GetComponent<Figure>().collorType == colorType)
        {
            Debug.Log("+1");
        }
        else
            Debug.Log("-1");
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
