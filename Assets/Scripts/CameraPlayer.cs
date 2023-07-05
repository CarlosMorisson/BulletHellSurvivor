using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    public bool shake = false;
    [SerializeField] private AnimationCurve curve;
    private float duration = 1f;
    [SerializeField] private Transform pivotPos;

    public object main { get; internal set; }
    void Update()
    {
        if (shake)
        {
            shake = false;
            StartCoroutine(Shaking());
        }
    }
    IEnumerator Shaking() 
    {
        Vector3 startPosition = transform.position;
        float elapse = 0f;
        while (elapse < duration)
        {
            elapse += Time.deltaTime;
            float strength = curve.Evaluate(elapse / duration);
            transform.position = startPosition + Random.insideUnitSphere * strength;
            yield return null;
        }
        transform.position = startPosition;
    }
    void FixedUpdate()
    {
        this.transform.position = Vector3.Lerp(transform.position, pivotPos.position, 0.1f);
    }
}
