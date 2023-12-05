using UnityEngine;

public class MiniGameManager : Minigame
{

    private Camera mainCamera;
    public Root[] Roots;
    public int[] RootsOrder;
    private int turnNumber;
    public LocationChangerProvider LocChanger;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            var rayHit = Physics2D.GetRayIntersection(mainCamera.ScreenPointToRay(Input.mousePosition));
            if (rayHit.collider && rayHit.collider.gameObject.CompareTag("Root"))
            {
                if (rayHit.collider.gameObject.GetComponent<Root>().Number == RootsOrder[turnNumber])
                {
                    rayHit.collider.gameObject.GetComponent<Root>().Close();
                    turnNumber++;
                }
                else
                {
                    rayHit.collider.gameObject.GetComponent<Root>().Shake();
                    Restart();
                    turnNumber = 0;
                }
                if (turnNumber == 8)
                    EndGame();
            }
        }
    }

    public void Restart()
    {
        foreach (var root in Roots)
            root.Back();
    }

    private void EndGame()
    {
        IsComplete = true;
        LocChanger.ChangeLocation();
    }
}
