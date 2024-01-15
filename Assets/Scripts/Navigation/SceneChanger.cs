using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private Animator anim;
    private int LevelToLoad;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void FadeToLevel(int sceneNumber)
    {
        LevelToLoad = sceneNumber;
        anim.SetTrigger("FadeToScene");
    }

    public void OnSceneFaidComplete()
    {
        SceneManager.LoadScene(LevelToLoad);
    }
}
