using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    public void Playgame ()
    {
		int index = SceneManager.GetActiveScene().buildIndex + 1;
		if(SceneManager.sceneCount <= index) {
			index = 0;
		}
		SceneManager.LoadScene(index);
    }

    public void QuitGame ()
    {
        Debug.Log("I DON'T WANNA PLAY!");
        Application.Quit();
    }
}
