using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_beweging : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float transitionTime = 1;

    void Update()
    {
        if (transform.position.x - target.position.x >= 8)
            startmove(-16, 0);
        if (transform.position.x - target.position.x <= -8)
            startmove(16, 0);
        if (transform.position.y - target.position.y >= 5.5f)
            startmove(0, -11);
        if (transform.position.y - target.position.y <= -5.5f)
            startmove(0, 11);


    }

    private void startmove(float x, float y)
    {
        StartCoroutine(IMoveCamera(x,y));
    }

    IEnumerator IMoveCamera(float x, float y)
    {


        float time = 0;
        Vector3 startPos = transform.position;
        Vector3 eindPos = transform.position + new Vector3(x, y, 0);

        while (time < 1)
        {
            transform.position = Vector3.Lerp(startPos, eindPos, time);
            time += Time.deltaTime / transitionTime;
            yield return new WaitForEndOfFrame();
        }

        transform.position = eindPos;

    }
}
