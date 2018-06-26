using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    [SerializeField] GameObject vsScreen;
    [SerializeField] GameObject mainMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            StartGame();

        if (Input.GetKeyDown(KeyCode.Escape))
            ExitGame();
    }

    public void StartGame()
    {
        StartCoroutine(LoadLevel());
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    IEnumerator LoadLevel()
    {
        mainMenu.SetActive(false);
        vsScreen.SetActive(true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(1);
    }
}
