using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    // Public
    public float lerpTime;
    public bool useLerp = false;
    private bool lerping = false;

    Vector3 offset;

    GameObject player;

    // Use this for initialization before any Start() functions are called
    void Start()
    {
        player = GameObject.Find("Player");
        offset = transform.position - player.transform.position;
    }

    void Update()
    {
        // Check if the camera is using lerp or if it is snapping to position
        if (useLerp)
        {
            LerpToPosition(player.transform.position + offset);
        }
        else
        {
            MoveToPosition(player.transform.position + offset);
        }
    }

    // Jump to position
    void MoveToPosition(Vector3 pos)
    {
        transform.position = pos;
    }

    // Lerp to position (Linear transform to position) which moves from point A to point B
    void LerpToPosition(Vector3 pos)
    {
        if (lerping == false)
        {
            lerping = true;
            StartCoroutine(LerpRoutine(pos));
        }
    }

    IEnumerator LerpRoutine(Vector3 targetPosition)
    {
        float timer = 0f;
        Vector3 originalPosition = transform.position;
        // While our timer is still counting
        while (timer < lerpTime)
        {
            // Increment out timer by the time between frames since this happens every frame
            timer += Time.deltaTime;
            // Here we have and start and end point and a fraction of time to the max time we want to lerp
            // By using the timer as our faction we can control how long it takes to move from our original position to our end position
            // Lerp takes fractions from 0 to 1
            transform.position = Vector3.Lerp(originalPosition, targetPosition, timer / lerpTime);
            yield return new WaitForEndOfFrame();
        }
        lerping = false;
    }

}