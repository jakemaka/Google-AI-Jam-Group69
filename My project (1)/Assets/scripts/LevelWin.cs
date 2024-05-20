using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelWin : MonoBehaviour
{
    public int levelIndex = 0;

    public GameObject Kapý;
    public GameObject parent;
    private void Start()
    {
        Kapý.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (levelIndex != 5)
            {
                Kapý.SetActive(true);
            }
            else if (levelIndex == 5)
            {
                SceneManager.LoadScene(5);
            }
        }
    }
}
