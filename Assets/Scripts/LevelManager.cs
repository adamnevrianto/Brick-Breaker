using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	// Use this for initialization
	public void LoadLevel(string name){
		Debug.Log ("Level load requested for: " + name);
        Brick.breakableCount = 0;
        SceneManager.LoadScene(name);
	}

	public void QuitRequest(){
		Debug.Log("I Wanna Quit!");
		Application.Quit ();
	}

    public void LoadNextLevel()
    {
        Brick.breakableCount = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void BrickDestroyed()
    {
        if(Brick.breakableCount <= 0)
        {
            LoadNextLevel();
        }
    }
}
