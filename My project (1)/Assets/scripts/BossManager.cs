using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class BossManager : MonoBehaviour
{
    public Transform point;
    public LayerMask mask;

    public Transform[] points;
    public GameObject indicator;
    private float initialXPosition;
    public GameObject ball;
    public int health = 3;
    public Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        initialXPosition = transform.position.x;
        StartCoroutine(Timer());
    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(point.position, Vector2.down, 10, mask);

        if (hit.collider != null)
        {
            Vector3 targetPosition = new Vector3(hit.collider.gameObject.transform.position.x, transform.position.y, transform.position.z);
            transform.position = new Vector3(targetPosition.x, transform.position.y, transform.position.z);

        }
        else
        {
            transform.position = new Vector3(initialXPosition, transform.position.y, transform.position.z);
        }
    }

    private IEnumerator Timer()
    {
        int randomNumber = Random.Range(0, points.Length);
        Vector2 position = points[randomNumber].position;
        GameObject obj = Instantiate(indicator, new Vector2(position.x, -4.75f), Quaternion.identity);

        yield return new WaitForSeconds(1);
        Destroy(obj);
        Instantiate(ball, position, Quaternion.identity);
        StartCoroutine(Timer());
    }
}
