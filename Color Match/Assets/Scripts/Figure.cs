using UnityEngine;
public enum ColorType
{
    Red, Blue, Green, Yellow
}

public class Figure : MonoBehaviour
{
    public ColorType colorType;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        SetRandomColor();
    }

    private void SetRandomColor()
    {
        var values = System.Enum.GetValues(typeof(ColorType));
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