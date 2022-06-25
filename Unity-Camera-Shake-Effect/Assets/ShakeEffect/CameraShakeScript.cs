using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class CameraShakeScript : MonoBehaviour
{
    private bool keyTrigger = true; // Added a bool to trigger effect once at the time

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) && keyTrigger)
        {

            StartCoroutine(Shake(0.2f, 0.1f));

            keyTrigger = false;
        }
    }

    private IEnumerator Shake(float duration, float magnitude)
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
