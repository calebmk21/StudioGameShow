using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject panel;
    public GameObject qPanel;
    public GameObject bg;
    public TMP_Text questionText;

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

    public void OpenTitleCard()
    { 
        QuizTracker.Question q = QuizTracker.GetRandomQuestion();
        panel = GameObject.Find(q.category);
        panel.transform.GetChild(0).gameObject.SetActive(true);
        bg.SetActive(false);
        // Note: if category is MusicalMatchup or UnskippableCutscene, check ID to load correct sound player
        Debug.Log(q.category);
        //panel.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
        questionText = transform.gameObject.GetComponent<TMP_Text>();
        questionText.text = q.description;
        //StoreInPanel(q.description);
    }

    // private void StoreInPanel(string qt)
    // {
    //     questionText.text = qt;
    // }

    public void ShowQuestion()
    {
        qPanel.SetActive(true);
    }

    public void HideQuestion()
    {
        qPanel.SetActive(false);
    }

    public void ChallengeSuccess()
    {
        panel.SetActive(false);
        Destroy(panel);
        bg.SetActive(true);
    }

    public void ChallengeFail()
    {
        // if time, add a "FAILURE" card
        SceneManager.LoadScene("TitleScreen");
    }
    
    // Start is called before the first frame update
    void Start()
    {
        bg = GameObject.Find("Background");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
