using UnityEngine;

public class LocationChangerProvider : MonoBehaviour
{
    private LocationChanger LocChanger;
    public GameObject LocationToLoad;
    public GameObject CurrentLocation;

    private void Start()
    {
        LocChanger = GameObject.Find("Navigator").GetComponent<LocationChanger>();
    }
    public void ChangeLocation()
    {
        LocChanger.FadeToLevel(CurrentLocation, LocationToLoad);
    }
}
