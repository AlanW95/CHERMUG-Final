using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//////////////////////////////////////////////////<summary>///////////////////////////////////////////////////// 
///                                   University of the West of Scotland                                     ///
///                               -------------------------------------------                                ///  
/// Script is attached to the PauseCanvas in each topic scene.                                               ///
/// This allows the PauseCanvas UI to be enabled/disabled.                                                   ///
///                                                                                                          ///
//////////////////////////////////////////////////</summary>////////////////////////////////////////////////////

public class Pause : MonoBehaviour
{
    public Button resumeButton;
    public Button menuButton;
    public GameObject pausePopup;
    public GameObject exitWarning;

    // Start is called before the first frame update
    void Start()
    {
        pausePopup.SetActive(false);
        exitWarning.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        PauseGame();
    }

    public void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown("p"))
        {
            pausePopup.SetActive(true);
        }
    }
    public void ResumeGame()
    {
        pausePopup.SetActive(false);
        exitWarning.SetActive(false);
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void EnableExitWarning()
    {
        exitWarning.SetActive(true);
    }
}