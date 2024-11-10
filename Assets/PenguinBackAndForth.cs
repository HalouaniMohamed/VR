using UnityEngine;

public class PenguinBackAndForth : MonoBehaviour
{
    public Animator animator;
    public float speed = 2f;
    public float moveDistance = 5f;

    private float startingPositionZ;
    private bool movingForward = true;
    private bool isMoving = false;

    void Start()
    {
        startingPositionZ = transform.position.z;
        animator.SetBool("isrunning", false);
    }

    void Update()
    {
        if (isMoving)
        {
            MovePenguin();
        }
    }

    private void MovePenguin()
    {
        if (movingForward && transform.position.z >= startingPositionZ + moveDistance - 0.1f)
        {
            movingForward = false;
            FlipPenguin();
        }
        else if (!movingForward && transform.position.z <= startingPositionZ - moveDistance + 0.1f)
        {
            movingForward = true;
            FlipPenguin();
        }

        float direction = movingForward ? 1 : -1;
        transform.position += new Vector3(0, 0, direction * speed * Time.deltaTime);
    }

    private void FlipPenguin()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    public void StartMovement()
    {
        isMoving = true;
        animator.SetBool("isrunning", true);
    }

    public void StopMovement()
    {
        isMoving = false;
        animator.SetBool("isrunning", false);
    }
}
