using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartAnim : MonoBehaviour
{
    private Animator anim;
    public LevelWin levelWin;

    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("anim1", false);
        anim.SetBool("anim2", false);
        anim.SetBool("anim3", false);
        anim.SetBool("anim4", false);
    }
    public void animGec()
    {
        anim.SetBool("anim1", true);
    }
    public void animGec1()
    {
        anim.SetBool("anim2", true);
    }
    public void animGec2()
    {
        anim.SetBool("anim3", true);
    }
    public void animGec3()
    {
        anim.SetBool("anim4", true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(2);
    }

    public void NewLevel()
    {
        if (levelWin != null)
            SceneManager.LoadScene(levelWin.levelIndex);
    }

    public void startMethod()
    {
        SceneManager.LoadScene(1);
    }
}
