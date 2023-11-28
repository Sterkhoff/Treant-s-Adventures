using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class LocationChanger : MonoBehaviour
{
    public GameObject LocationToLoad;
    public GameObject CurrentLocation;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void FadeToLevel(GameObject currentLocation, GameObject locationToLoad)
    {
        CurrentLocation = currentLocation;
        LocationToLoad = locationToLoad;
        anim.SetTrigger("Fade");
    }

    public void OnFaidComplete()
    {
        PlayLocationStartAnimation();
        LocationToLoad.SetActive(true);
        CurrentLocation.SetActive(false);
    }

    public void PlayLocationStartAnimation()
    {
        anim.SetTrigger("Reset");
    }
}
