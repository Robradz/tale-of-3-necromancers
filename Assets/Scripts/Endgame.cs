using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Endgame : MonoBehaviour
{
    [SerializeField] Canvas winCanvas;
    bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        winCanvas.enabled = false;
    }

    private void Update()
    {
        if (transform.childCount <= 0 && !gameOver)
        {
            HandleWin();
            gameOver = true;
        }
    }

    public void HandleWin()
    {
        winCanvas.enabled = true;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        FindObjectOfType<WeaponSwitcher>().enabled = false;
    }
}
