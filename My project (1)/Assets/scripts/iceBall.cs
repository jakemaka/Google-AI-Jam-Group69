using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class iceBall : MonoBehaviour
{
    private GameObject Target;

    private void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Enemy");
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, .2f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<BossManager>().health--;
            collision.gameObject.GetComponent<BossManager>().animator.SetBool("Damage", true);
            Invoke("ResetDamageAnimation", .5f);

            if (collision.gameObject.GetComponent<BossManager>().health <= 0)
            {
                SceneManager.LoadScene(5);
            }

            Destroy(gameObject, .6f);
        }
    }

    private void ResetDamageAnimation()
    {
        Debug.Log("aaaa");
        Target.GetComponent<BossManager>().animator.SetBool("Damage", false);
    }
}
