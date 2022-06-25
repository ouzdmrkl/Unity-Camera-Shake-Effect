using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class CameraShakeScript : MonoBehaviour
{
    private bool keyTrigger = true; // Added a bool to trigger effect once at the time

    [SerializeField] private ParticleSystem explosionEffect;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) && keyTrigger)
        {
            explosionEffect.Play(); // Play the explosion effect
            
            StartCoroutine(Shake(0.3f, 0.5f)); // Start camera shake coroutine

            keyTrigger = false;
        }
    }

    private IEnumerator Shake(float duration, float magnitude) // Duration, how long cam will shake, magnitude how hard camera will shake
    {
        Vector3 original_Pos = transform.localPosition; // Original start position of the camera
      
        var elapsed = 0f; // We will make calculation on elapsed time

        while (elapsed < duration)
        {
            var x = Random.Range(-1f, 1f) * magnitude;
            var y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(original_Pos.x + x, original_Pos.y + y, original_Pos.z); // We get random values and add it to original position of cam
            // This is how we get shake effect

            elapsed += Time.deltaTime;
            
            yield return null;
        }

        transform.localPosition = original_Pos;

        keyTrigger = true;
    }
}
