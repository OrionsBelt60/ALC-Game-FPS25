using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Flag Stats")]
    public bool hasFlag;
    public bool flagPlaced;
    [Header("Game State")]
    public bool gamePaused;
    public static GameManager instance;
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        hasFlag = false;
        flagPlaced = false;
        Time.timeScale = 1.0f;// this is real time
    }


    // Update is called once per frame
    void Update()
    {
        if (flagPlaced)
        {
            Debug.Log("You have placed the flag! You have won the game!");
        }
        if (Input.GetButtonDown("Cancel"))
        {
            TogglePauseGame();
        }
    }
    public void TogglePauseGame()
    {
        gamePaused = !gamePaused;

        Time.timeScale = gamePaused == true ? 0.0f : 1.0f;

        Cursor.lockState = gamePaused == true ? CursorLockMode.None : CursorLockMode.Locked;
    }
    public void PlaceFlag()
    {
        flagPlaced = true;
    }

}
