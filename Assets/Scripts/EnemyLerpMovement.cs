using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is not used.. It is just a test

public class EnemyLerpMovement : MonoBehaviour
{
    private int currentIndex = 0;
    [SerializeField] private List<Transform> points;
    private Vector3 previousPoint;
    private Vector3 localScale;

    private float currentDistance;
    private int direction;

    private void Start()
    {
        direction = 1;
        localScale = transform.localScale;
        // facing left localScale.x = +ve
        // facing right localScale.x = -ve
    }

    private void Update()
    {

        if ((points[currentIndex].position - transform.position).sqrMagnitude < 0.1f)
        {
            previousPoint = points[currentIndex].position;
            if (currentIndex >= points.Count - 1 && direction > 0)
            {
                direction = -1;
                localScale.x *= -1;
                transform.localScale = localScale;
            }
            else if (currentIndex <= 0 && direction < 0)
            {
                direction = 1;
                localScale.x *= -1;
                transform.localScale = localScale;
            }
            currentIndex += direction;
            //totalTime = 0;
            currentDistance = (points[currentIndex].position - previousPoint).sqrMagnitude;
        }

        transform.position = Vector2.Lerp(transform.position, points[currentIndex].position, Time.deltaTime);


    }
}
