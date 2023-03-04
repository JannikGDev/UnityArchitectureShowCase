using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeImage : MonoBehaviour
{
    private float start;
    private float end;
    private float value;
    private float timeLeft;
    private float totalTime = -1;
    private float startTime;
    private float endTime;

    Image target;

    public void FadeIn(float time)
    {
        StartChange(0.0f, 1.0f, time);
    }

    public void FadeOut(float time)
    {
        StartChange(1.0f, 0.0f, time);
    }

    public void StartChange(float startVal, float endVal, float tweenTime)
    {
        startTime = Time.realtimeSinceStartup;
        endTime = startTime + tweenTime;
        
        totalTime = tweenTime;
        timeLeft = totalTime;
        start = startVal;
        end = endVal;
        value = start;
        target = GetComponent<Image>();

        var c = target.color;
        target.color = new Color(c.r, c.g, c.b, start);

        StartCoroutine(UpdateTween());
    }

    IEnumerator UpdateTween()
    {
        while (true)
        {
            var c = target.color;
            
            timeLeft = endTime - Time.realtimeSinceStartup;
            
            if (timeLeft <= 0 || timeLeft > totalTime)
            {
                target.color = new Color(c.r, c.g, c.b, end);
                yield break;
            }
            
            var t = (1 - timeLeft / totalTime);
            value = EasingFunction.EaseInOutQuad(start, end, t);

            target.color = new Color(c.r, c.g, c.b, value);

            yield return new WaitForEndOfFrame();
        }
    }
}
