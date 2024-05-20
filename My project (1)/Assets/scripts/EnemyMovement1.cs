using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Vector3 startPosition;
    public Vector3 endPosition;
    public float teleportInterval = 5f;

    private float elapsedTime;
    private bool isAtStartPosition = true;

    void Start()
    {
        transform.position = startPosition;
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= teleportInterval)
        {
            elapsedTime = 0f;

            if (isAtStartPosition)
            {
                transform.position = endPosition;
                isAtStartPosition = false;
            }
            else
            {
                transform.position = startPosition;
                isAtStartPosition = true;
            }
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().TakeDamage();
        }
    }
}
