using UnityEngine;

public class LocationSwitch : MonoBehaviour
{
    public GameObject activeFrame;
    public LocationChanger LocationSwitcher;

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            activeFrame.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            LocationSwitcher.PlayLocationStartAnimation();
            activeFrame.SetActive(true);
        }
    }
}
