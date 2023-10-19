using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* Notes to future Caleb:
 * 
 *
 *
 * 
 */
public class MenuController : MonoBehaviour
{
    // Simple scene changing function
    public void SceneSwap(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Debug.Log("Moving to new scene");
    }
    
    // Because we need a quit button
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit the application.");
    }

    public void OpenTitleCard(string titleCard)
    {
        
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
