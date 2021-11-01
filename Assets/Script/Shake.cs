using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{

    public bool start = false;
    public AnimationCurve curve;
    public float duration = 0.5f;

    void Update() {
        // start = PlayerPrefs.GetInt("isShake");
        if (start) {
            start = false;
            // PlayerPrefs.SetInt("isShake", start);
            StartCoroutine(Shaking());
        }
    }

    IEnumerator Shaking() { 
        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < duration) {
            elapsedTime += Time.deltaTime;
            float strength = curve.Evaluate(elapsedTime / duration);
            Debug.Log(strength);
            transform.position = startPosition + Random.insideUnitSphere * strength;
            yield return null;
        }

        transform.position = startPosition;
    }
}
