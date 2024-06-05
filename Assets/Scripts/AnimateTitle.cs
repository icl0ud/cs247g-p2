using System.Collections;
using UnityEngine;

public class AnimateTitle : MonoBehaviour
{
    public float amplitude = 10f; // The amount of vertical movement
    public float frequency = 1f;  // The speed of the animation

    private Vector3 originalPosition;

    private void Start()
    {
        originalPosition = transform.position;
        StartCoroutine(Animate());
    }

    private IEnumerator Animate()
    {
        while (true) // Infinite loop for continuous animation
        {
            // Calculate the vertical offset based on sine wave
            float yOffset = Mathf.Sin(Time.time * frequency) * amplitude;

            // Apply the vertical offset to the title's position
            Vector3 newPosition = originalPosition + new Vector3(0f, yOffset, 0f);
            transform.position = newPosition;

            yield return null; // Wait for the next frame
        }
    }
}