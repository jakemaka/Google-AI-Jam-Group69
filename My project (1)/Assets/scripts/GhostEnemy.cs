using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GhostEnemy : MonoBehaviour
{
    public Transform point1, point2;

    public int time;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(Timer());
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(time);
        animator.SetBool("teleported", true);
        transform.localScale = new Vector3(-1, 1, 1);
        transform.position = point1.position;
        yield return new WaitForSeconds(.4f);
        animator.SetBool("teleported", false);
        yield return new WaitForSeconds(time);
        animator.SetBool("teleported", true);
        transform.position = point2.position;
        transform.localScale = new Vector3(1, 1, 1);
        yield return new WaitForSeconds(.4f);
        animator.SetBool("teleported", false);
        StartCoroutine(Timer());

    }



}
