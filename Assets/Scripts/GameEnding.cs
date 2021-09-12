using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnding : MonoBehaviour
{
    [SerializeField] GameObject[] endMenu;

    private void OnTriggerEnter(Collider other)
    {
        foreach(GameObject menu in endMenu)
        {
            menu.SetActive(true);
        }
        Cursor.lockState = CursorLockMode.Confined;
        Time.timeScale = 0;
    }
    public void FinishGame()
    {
        Application.Quit();
    }
}
