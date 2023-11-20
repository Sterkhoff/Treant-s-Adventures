using UnityEngine;

public class LocationChangerProvider : MonoBehaviour
{
    private LocationChanger LocChanger;
    public GameObject LocationToLoad;
    public GameObject CurrentScene;

    private void Start()
    {
        LocChanger = GameObject.Find("LocationChanger").GetComponent<LocationChanger>();
    }
    public void ChangeLocation()
    {
        LocChanger.FadeToLevel(CurrentScene, LocationToLoad);
    }
}
