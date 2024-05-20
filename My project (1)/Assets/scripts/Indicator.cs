using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Indicator : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(time());
    }
    IEnumerator time()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(.2f);
        GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(.2f);
        GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(.2f);
        GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(.2f);
        GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(.2f);
        Destroy(gameObject);
    }
}
