using System;
using System.Collections;
using UnityEngine;

public class MiniGameManager : MonoBehaviour
{

    private Camera mainCamera;
    public GameObject[] Roots;
    public int[] RootsOrder;
    private int level;

    private void Start()
    {
        mainCamera = Camera.main;
        level = 4;
        StartCoroutine(StartGame());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            var rayHit = Physics2D.GetRayIntersection(mainCamera.ScreenPointToRay(Input.mousePosition));
            if (rayHit.collider)
                if (rayHit.collider.gameObject.CompareTag("Root"))
                    rayHit.collider.gameObject.GetComponent<Root>().Shake();
        }
    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(1.5f);
        for (var j = 0; j <= level; j++)
        {
            Roots[j].GetComponent<Root>().Shake();
            yield return new WaitForSeconds(0.4f);
        }       

    }
}
