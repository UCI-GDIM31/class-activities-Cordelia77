using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ball : MonoBehaviour
{
    [SerializeField] private TMP_Text _bouncesText;
    [SerializeField] private TMP_Text _brightnessText;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Rigidbody2D _rigidbody;

    private int _bounces;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // STEP 1 Add 1 to the number of bounces
        _bounces++;

        // Update the bounces text on screen
        _bouncesText.text = "Bounces: " + _bounces;

        // Get the current color values
        float r = _spriteRenderer.color.r;
        float g = _spriteRenderer.color.g;
        float b = _spriteRenderer.color.b;

        // STEP 2 Add 0.1 to the red value
        r = r + 0.1f;

        // STEP 3 If red is above 1.0, reset it to 0.0
        if (r > 1.0f)
        {
            r = 0.0f;
        }

        // STEP 4 Subtract 0.1 from the green value
        g -= 0.1f;

        // STEP 5 If green is below 0.0, reset it to 1.0
        if (g < 0.0f)
        {
            g = 1.0f;
        }

        // STEP 6 Multiply the blue value by 1.2
        b = b * 1.2f;

        // STEP 7 If blue is greater than or equal to 1.0, reset it to 0.1
        if (b >= 1.0f)
        {
            b = 0.1f;
        }

        // Apply the new color to the ball
        Color newColor = new Color(r, g, b);
        _spriteRenderer.color = newColor;

        // Print the new color to the Console
        Debug.Log(newColor);

        // STEP 8 Calculate the brightness (average of r, g, b)
        float brightness = (r + g + b) / 3f;

        // STEP 9 Update the brightness text
        _brightnessText.text = "brightness = " + brightness;
    }
}
