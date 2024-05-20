using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class enemyController : MonoBehaviour
{
    [SerializeField] private Transform point;

    private bool detected = false;
    private bool rising = false;

    public int range = 3;
    public LayerMask mask;
    public float riseSpeed = 1f;  

    private Animator _animator;
    private Rigidbody2D _rb;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
    }

    private bool EnemyTrigger()
    {
        if (!detected)
        {
            RaycastHit2D hit = Physics2D.Raycast(point.transform.position, Vector2.down, range, mask);

            if (hit.collider != null && hit.collider.CompareTag("Player"))
            {
                Debug.DrawLine(point.transform.position, hit.point, Color.blue);
                detected = true;
            }
        }
        else
        {
            return true;
        }
        return false;
    }

    private void Update()
    {
        if (EnemyTrigger())
        {
            _animator.SetBool("Active", true);
            _rb.AddForce(-transform.up * 350 * Time.deltaTime);
        }
        else
        {
            if (!rising)
            {
                transform.position = new Vector2(transform.position.x, Mathf.PingPong(Time.time, 3));
            }
            else
            {
                transform.position += new Vector3(0, riseSpeed * Time.deltaTime, 0);
                if (transform.position.y >= 2)
                {
                    rising = false;
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _animator.SetBool("Active", false);
            detected = false;
            _rb.velocity = Vector2.zero; 
            rising = true;
        }
    }
}
