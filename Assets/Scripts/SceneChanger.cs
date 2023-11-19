using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private Animator anim;
    public int LevelToLoad;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void FadeToLevel()
    {
        anim.SetTrigger("Fade");
    }

    public void OnFaidComplete()
    {
        SceneManager.LoadScene(LevelToLoad);
    }
}
