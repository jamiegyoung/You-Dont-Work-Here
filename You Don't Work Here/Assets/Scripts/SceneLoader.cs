using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Animator animator;

    public enum Level
    {
        Menu,
        Intro,
        House,
        Walk,
        Reception,
        BillPayment
    }

    public void LoadLevel(Level levels)
    {
        StartCoroutine(AnimationLoad(levels));
    }

    private IEnumerator AnimationLoad(Level level)
    {
        animator.SetTrigger("Start");

        yield return new WaitForSecondsRealtime(.3f);
        Time.timeScale = 1f;
        SceneManager.LoadScene((int)level);
    }
}
