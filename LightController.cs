using UnityEngine;
using System.Collections;
public class LightController : MonoBehaviour
{
    public Light targetLight;
    public float minIntensity = 0.1f;
    public float maxIntensity = 1.0f;
    public float transitionDuration = 0.1f;

    private void Start()
    {
        StartCoroutine(RandomizeIntensity());
    }

    private IEnumerator RandomizeIntensity()
    {
        System.Random random = new System.Random();

        while (true)
        {
            double randomNumber = random.NextDouble(); // Genera un n mero aleatorio entre 0 (inclusive) y 1 (exclusivo)
            yield return StartCoroutine(ChangeIntensity(targetLight.intensity, minIntensity));

            yield return StartCoroutine(ChangeIntensity(targetLight.intensity, maxIntensity));

            yield return new WaitForSeconds((float)randomNumber); // Convierte el n mero aleatorio en float para usarlo como espera
        }
    }


    private IEnumerator ChangeIntensity(float startIntensity, float targetIntensity)
    {
        float elapsedTime = 0f;

        while (elapsedTime < transitionDuration)
        {
            float t = elapsedTime / transitionDuration;
            targetLight.intensity = Mathf.Lerp(startIntensity, targetIntensity, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        targetLight.intensity = targetIntensity;
    }
}