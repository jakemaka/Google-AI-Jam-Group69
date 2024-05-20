using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float moveSpeed = 50f;
    public float moveSpeed2 = 150f;
    public float upForece = 250;
    private bool isMoving = true;
    private bool isMoving2 = false;
    public int playerHealth = 1;
    private Rigidbody2D rb;
    public Button move, stop, run,tryAgain;

    private Animator animator;

    void Start()
    {
        Time.timeScale = 1.0f;
        tryAgain.gameObject.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        move.GetComponent<Button>().interactable = false;
    }
    private void FixedUpdate()
    {
        if (isMoving == true && isMoving2 == false)
        {
            rb.velocity = new Vector2(moveSpeed * Time.deltaTime, rb.velocity.y);
            animator.SetBool("moved",true);
        }
        else if (isMoving2 == true && isMoving == false)
        {
            rb.velocity = new Vector2(moveSpeed2 * Time.deltaTime, rb.velocity.y);
            animator.SetBool("moved", true);

        }
        else if (isMoving == false && isMoving2 == false)
        {
            rb.velocity = new Vector2(0,rb.velocity.y);
            animator.SetBool("moved", false);

        }
    }
    public void MovedPlayer()
    {
        isMoving = true;
        isMoving2 = false;
        move.GetComponent<Button>().interactable = false;
        run.GetComponent<Button>().interactable = true;
        stop.GetComponent<Button>().interactable = true;
    }
    public void StopPlayer()
    {
        isMoving = false;
        isMoving2 = false;
        move.GetComponent<Button>().interactable = true;
        run.GetComponent<Button>().interactable = true;
        stop.GetComponent<Button>().interactable = false;
    }
    public void RunPlayer()
    {
        isMoving2 = true;
        isMoving = false;
        move.GetComponent<Button>().interactable = true;
        run.GetComponent<Button>().interactable = false;
        stop.GetComponent<Button>().interactable = true;
    }

    public void TakeDamage()
    {
        Debug.Log("TakeDamage metodu çaðrýldý.");
        playerHealth--;
        Debug.Log("Oyuncunun Kalan Caný: " + playerHealth);

        if (playerHealth <= 0)
        {
            Time.timeScale = 0.0f;
            tryAgain.gameObject.SetActive(true);
            Debug.Log("Game Over!");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage();
        }
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}