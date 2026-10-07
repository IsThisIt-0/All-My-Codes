using UnityEngine;
using System.Collections;

public class Phase2CoffeCup : MonoBehaviour
{
    [SerializeField] private Animator MugAnimator;

    public Transform pointA;
    public Transform pointB;
    public float moveSpeed = 2f;
    public bool lockY = true;

    private Transform targetPoint;
    private float fixedY;

    void Start()
    {
        fixedY = transform.position.y;
        targetPoint = pointB;
        SetRotation(targetPoint); // Set initial rotation
        StartCoroutine(MoveLoop());
    }

    IEnumerator MoveLoop()
    {
        while (true)
        {
            // Resume animation while moving
            if (MugAnimator != null)
                MugAnimator.speed = 1f;

            // Move toward target
            while (true)
            {
                Vector2 currentPos = transform.position;
                Vector2 targetPos = targetPoint.position;

                if (lockY) targetPos.y = fixedY;

                currentPos = Vector2.MoveTowards(currentPos, targetPos, moveSpeed * Time.deltaTime);
                transform.position = currentPos;

                if (Vector2.Distance(currentPos, targetPos) < 0.01f)
                    break;

                yield return null;
            }

            // Snap exactly to the target
            Vector3 snapPos = targetPoint.position;
            if (lockY) snapPos.y = fixedY;
            transform.position = snapPos;

            // Pause animation while waiting
            if (MugAnimator != null)
                MugAnimator.speed = 0f;

            // Wait at the position
            float waitTime = Random.Range(0.3f, 3f);
            yield return new WaitForSeconds(waitTime);

            // Switch target
            targetPoint = (targetPoint == pointA) ? pointB : pointA;

            // Update rotation for next movement
            SetRotation(targetPoint);
        }
    }

    private void SetRotation(Transform target)
    {
        Vector3 euler = transform.eulerAngles;

        if (target == pointA)
            euler.y = 182f; // Facing left/backwards
        else
            euler.y = 0f;   // Facing right/forwards

        transform.eulerAngles = euler;
    }
}
