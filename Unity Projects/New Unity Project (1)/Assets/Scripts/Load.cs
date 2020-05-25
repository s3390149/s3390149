using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load : MonoBehaviour
{
    [SerializeField] float delay = .5f;
    // Start is called before the first frame update
    public void loadMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void loadGame()
    {
        SceneManager.LoadScene("BaseGame");
        FindObjectOfType<GameSession>().ResetGame();

    }

    public void loadGameOver()
    {
        StartCoroutine(gameOver());

    }

    IEnumerator gameOver()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("GameOver");

    }
  public void gameWon()
    {
        
        SceneManager.LoadScene("WonGame");
    }
    public void quitGame() {
        Application.Quit();
}
}
//Tristem, B. and Davidson, R., 2018. [online] Complete C# Unity Developer 2D: Learn to Code Making Games. 
//Available at: <https://www.udemy.com/course/unitycourse/learn/lecture/10360336?start=540#overview> [Accessed 20 May 2020].