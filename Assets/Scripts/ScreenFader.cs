using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScreenFader : MonoBehaviour
{
    public static ScreenFader Instance { get; private set; }
    [SerializeField] Image fadeImage;
    [SerializeField] float fadeDuration = 1f;


    Coroutine fadeCoroutine;
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }


    public void FadeIn()
    {
        StartFade(1f, 0f);
    }

    public void FadeOut()
    {
        StartFade(0f, 1f);
    }

    void StartFade(float from, float to)
    {
        if (fadeCoroutine != null)
            StopCoroutine(fadeCoroutine);

        fadeCoroutine = StartCoroutine(FadeRoutine(from, to));
    }

    IEnumerator FadeRoutine(float from, float to)
    {
        float t = 0f;
        Color c = fadeImage.color;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            c.a = Mathf.Lerp(from, to, t / fadeDuration);
            fadeImage.color = c;
            yield return null;
        }

        c.a = to;
        fadeImage.color = c;
    }

    public float Duration => fadeDuration;

    public IEnumerator FadeOutRoutine()
    {
        FadeOut();
        yield return new WaitForSeconds(fadeDuration);
    }

    public IEnumerator FadeInRoutine()
    {
        FadeIn();
        yield return new WaitForSeconds(fadeDuration);
    }
}
