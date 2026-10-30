using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    public float speed = 2f;
    public float moveDistance = 3.5f;
    public bool moveHorizontal = true;
    private Vector3 startPosition;
    private bool movingForward = true;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        Vector3 direction = moveHorizontal ? Vector3.right : Vector3.forward;
        Vector3 targetPosition = movingForward
            ? startPosition + (direction * moveDistance)
            : startPosition - (direction * moveDistance);

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) < 0.05f)
        {
            movingForward = !movingForward;
        }
    }
}
