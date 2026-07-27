using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AttackAnimation : MonoBehaviour
{
    public AnimationCurve curve;
    public float duration = 0.5f;
    public Button attackButton;

    public IEnumerator Attack()
    {
        Vector3 startPos = transform.position;
        Vector3 endPos = startPos + Vector3.right * 2f;

        float t = 0;

        while (t < duration)
        {
            t += Time.deltaTime;

            float value = curve.Evaluate(t / duration);
            transform.position = Vector3.Lerp(startPos, endPos, value);

            yield return null;
        }

        transform.position = startPos;
    }


    public void AttackPressed()
    {
        StartCoroutine(AttackRoutine());
    }

    IEnumerator AttackRoutine()
    {
        attackButton.interactable = false;

        yield return StartCoroutine(Attack());

        attackButton.interactable = true;
    }

}