using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    Vector3 startPosition;
    Vector3 finalPosition;

    void Start()
    {
        startPosition = new Vector3(GameObject.Find("Platform").transform.position.x, GameObject.Find("Platform").transform.position.y - GetComponent<SpriteRenderer>().size.y - GameObject.Find("Platform").transform.localScale.y, 10);
        finalPosition = new Vector3(transform.position.x, GameObject.Find("Platform").transform.position.y + GetComponent<SpriteRenderer>().size.y / 3, 10);
        
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            StartCoroutine(LerpPosition(startPosition, finalPosition, .2f));
        }

        if(Input.GetMouseButtonDown(1))
        {
            StartCoroutine(LerpPosition(finalPosition, startPosition, .2f));
        }
    }

    IEnumerator LerpPosition(Vector3 startPosition, Vector3 target, float lerpDuration)
    {
        float timeElapsed = 0f;

        while(timeElapsed < lerpDuration)
        {
            transform.position = Vector3.Lerp(startPosition, target, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = target;
    }
}
