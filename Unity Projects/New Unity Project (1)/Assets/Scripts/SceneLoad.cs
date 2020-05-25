using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoad : MonoBehaviour
{
    public void loadNextScene()
    {
        //get the current scene build index and assign to currentScene
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        //get the next index and load current scene eg: current scene is 2 and load next
        //Scene which is done by adding one to the current index.

        SceneManager.LoadScene(currentScene + 1);
    }

    //Loads the starting scence, 0 is the start *initial* scene

    public void loadStartScene()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
//Tristem, B. and Davidson, R., 2018. [online] Complete C# Unity Developer 2D: Learn to Code Making Games. 
//Available at: <https://www.udemy.com/course/unitycourse/learn/lecture/10360336?start=540#overview> [Accessed 20 May 2020].