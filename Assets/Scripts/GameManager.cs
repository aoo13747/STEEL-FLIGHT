using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject pauseMenu;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        Time.timeScale = 0.3f;        
        StartCoroutine(StartGame());
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
        }
    }
    public void PlayerDied()
    {
        StartCoroutine(RestartGame());
    }
    IEnumerator RestartGame()
    {
        Time.timeScale = .3f;

        yield return new WaitForSecondsRealtime(5f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    IEnumerator StartGame()
    {
        yield return new WaitForSecondsRealtime(2f);
        Time.timeScale = 1;
    }
}
