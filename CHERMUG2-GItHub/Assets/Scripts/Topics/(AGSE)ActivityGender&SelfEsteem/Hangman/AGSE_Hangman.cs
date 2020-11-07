using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//////////////////////////////////////////////////<summary>//////////////////////////////////////////////////// 
///                                   University of the West of Scotland                                    ///
///                                 ACTIVITY, GENDER AND SELF ESTEEM TOPIC                                  ///
///                               -------------------------------------------                               ///  
/// Script is attached to the GameManager in the AGSE_Hangman scene.                                        ///
///                                                                                                         ///                         
//////////////////////////////////////////////////</summary>///////////////////////////////////////////////////

public class AGSE_Hangman : MonoBehaviour
{
    [SerializeField] private List<Text> AnswerList;
    [SerializeField] private List<int> correctLetter;
    [SerializeField] private Button[] buttons;//Array of the letter buttons (A - !)

    private GameObject gameUI;
    private GameObject instructionUI;
    private GameObject readyButton;
    private GameObject continueButton;
    public GameObject scoreBar;
    public GameObject nameBar;
    public GameObject character;
    public GameObject fadeScreen;

    public GameObject scenarioCloseButton;
    public GameObject scenarioViewButton;
    public GameObject scenarioObj;
    public GameObject scenarioButtonClickBlock;

    private GameObject speechBubble;
    private Text correctText;
    private Text wrongText;

    private Text triesAmountText;
    private int triesAmount;

    private Text letter1;
    private Text letter2;
    private Text letter3;
    private Text letter4;
    private Text letter5;
    private Text letter6;
    private Text letter7;

    private string nominal;//Correct answer 

    private bool attempt1 = true;

    //Typing Text
    public GameObject positiveFeedback;
    public GameObject negativeFeedback;
    public string[] sentences;
    private int index;
    public float typingSpeed;

    // Start is called before the first frame update
    void Start()
    {
        character.gameObject.GetComponent<CharacterAnims>().states = 0;

        gameUI = GameObject.Find("GameUI");
        instructionUI = GameObject.Find("InstructionsUI");
        readyButton = GameObject.Find("ReadyButton");
        continueButton = GameObject.Find("ContinueButton");
        triesAmountText = GameObject.Find("TriesAmountText").GetComponent<Text>();
        correctText = GameObject.Find("CorrectText").GetComponent<Text>();
        wrongText = GameObject.Find("WrongText").GetComponent<Text>();
        speechBubble = GameObject.Find("SpeechBubble");
        nameBar = GameObject.Find("NameBar");
        scoreBar = GameObject.Find("ScoreBar");

        scenarioCloseButton = GameObject.Find("ScenarioButton_Close");
        scenarioViewButton = GameObject.Find("ScenarioButton_View");
        scenarioObj = GameObject.Find("ResearchScenario");
        scenarioButtonClickBlock = GameObject.Find("ScenarioButtonClickBlock");
        
        scenarioButtonClickBlock.SetActive(false);
        speechBubble.gameObject.SetActive(false);
        correctText.gameObject.SetActive(false);
        wrongText.gameObject.SetActive(false);
        instructionUI.gameObject.SetActive(true);
        gameUI.gameObject.SetActive(true);
        readyButton.gameObject.SetActive(true);
        continueButton.gameObject.SetActive(false);
        scenarioCloseButton.gameObject.SetActive(false);
        scenarioViewButton.gameObject.SetActive(true);

        triesAmount = 9;
        triesAmountText.text = "" + triesAmount;

        GameObject Answer = GameObject.Find("Word");

        for (int i = 0; i < Answer.transform.childCount; i++)
        {   //Gets the child object of the Word obj in the Hierarchy (Letter_01, Letter_02 etc, and then the text component child of that obj (Letter_01_Text etc)
            AnswerList.Add(Answer.transform.GetChild(i).GetChild(0).GetComponent<Text>());
        }

        //The correct letters with corresponding number in the List (also same num in the buttons array)
        //Adds them to the correctLetter List (displayed in the Inspector)
        correctLetter.Add(13);//N
        correctLetter.Add(14);//O
        correctLetter.Add(12);//M
        correctLetter.Add(8);//I
        correctLetter.Add(13);//N
        correctLetter.Add(0);//A
        correctLetter.Add(11);//L

        foreach (int i in correctLetter)
        {
            nominal = nominal + buttons[i];
        }
        SpeechBubbleText();
    }

    public void LoadNextScene()
    {   
        SceneManager.LoadScene("AGSE_QuestionsHM");
    }

    public void SpeechBubbleText()
    {
        sentences[0] = "Nominal: Correct, because there are different categories of the variable activity level.";
        sentences[1] = "Oh no! You ran out of tries. Would you like to try again?";
    }

    //Called from the OnClick function in the Inspector
    public void ButtonCheck(int buttonID)
    {
        for (int i = 0; i < correctLetter.Count; i++)
        {   //Checks if the buttonID matches the num of the correctLetter in the List (buttonID(1) = correctLetter(1) etc)
            //The buttonID is manually typed into the OnClick function (ensure the number matches the number of the button)
            if (buttonID == correctLetter[i])
            {
                AnswerList[i].text = buttons[correctLetter[i]].transform.GetChild(0).GetComponent<Text>().text;

                if (buttonID == correctLetter[0] || buttonID == correctLetter[4])
                {
                    AnswerList[0].text = buttons[correctLetter[0]].transform.GetChild(0).GetComponent<Text>().text;
                    AnswerList[4].text = buttons[correctLetter[4]].transform.GetChild(0).GetComponent<Text>().text;
                }
                buttons[buttonID].interactable = false;
                return;
            }
        }
        triesAmount--;
        buttons[buttonID].interactable = false;
    }

    //Called from the OnClick function in the Inspector
    public void CheckWinOrLose()
    {
        triesAmountText.text = "" + triesAmount;

        if (triesAmount <= 0)
        {
            triesAmountText.text = "0";
            character.gameObject.GetComponent<CharacterAnims>().states = 3;//Shake head anim
            speechBubble.gameObject.SetActive(true);
            correctText.gameObject.SetActive(false);
            wrongText.gameObject.SetActive(true);
            wrongText.text = "";
            scoreBar.gameObject.GetComponent<ScoreSystem>().RemoveAGSEScore();

            attempt1 = false;

            StartCoroutine(Type());

            foreach (Button b in buttons)
            {
                b.GetComponent<Button>().enabled = false;
            }
        }

        int AnswersRight = 0;

        foreach (int v in correctLetter)
        {
            if (buttons[v].interactable == false)
            {
                AnswersRight++;
                if (AnswersRight == correctLetter.Count)
                {
                    AchievementManager.instance.Unlock("AGSE_achievement_01");

                    character.gameObject.GetComponent<CharacterAnims>().states = 2;//Thumbs up anim
                    speechBubble.gameObject.SetActive(true);
                    correctText.gameObject.SetActive(true);
                    wrongText.gameObject.SetActive(false);
                    correctText.text = "";
                    scoreBar.gameObject.GetComponent<ScoreSystem>().AddAGSEScore();
                    StartCoroutine(Type());

                    foreach (Button b in buttons)
                    {
                        b.GetComponent<Button>().enabled = false;
                    }
                    continueButton.gameObject.SetActive(true);
                }
            }
        }
    }

    public void ResetButton()
    {   
        foreach (Button b in buttons)
        {
            b.GetComponent<Button>().enabled = true;
            b.interactable = true;
        }
        foreach (Text t in AnswerList)
        {
            t.text = "?";
        }

        triesAmount = 9;
        triesAmountText.text = "" + triesAmount;
        instructionUI.gameObject.SetActive(false);
        gameUI.gameObject.SetActive(true);
        speechBubble.gameObject.SetActive(false);
        correctText.gameObject.SetActive(false);
        wrongText.gameObject.SetActive(false);
    }
    //Called from the OnClick function when the player presses the Ready button
    public void StartGame()
    {
        instructionUI.gameObject.SetActive(false);
        readyButton.gameObject.SetActive(false);

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].gameObject.SetActive(true);
        }
        nameBar.gameObject.GetComponent<BarAnimations>().states = 1;
        scoreBar.gameObject.GetComponent<BarAnimations>().states = 1;
        CloseStudy();
    }

    public void ViewStudy()
    {
        scenarioObj.gameObject.GetComponent<ScenarioAnimations>().states = 1;
        scenarioCloseButton.gameObject.SetActive(true);
        scenarioViewButton.gameObject.SetActive(false);
        scenarioButtonClickBlock.gameObject.SetActive(true);
    }

    public void CloseStudy()
    {
        scenarioObj.gameObject.GetComponent<ScenarioAnimations>().states = 2;
        scenarioCloseButton.gameObject.SetActive(false);
        scenarioViewButton.gameObject.SetActive(true);
        scenarioButtonClickBlock.gameObject.SetActive(false);
    }

    IEnumerator Type()
    {
        if (positiveFeedback.gameObject.activeInHierarchy == true)
        {
            foreach (char letter in sentences[0].ToCharArray())
            {
                correctText.text += letter;
                yield return new WaitForSeconds(typingSpeed);
            }
        }

        if (negativeFeedback.gameObject.activeInHierarchy == true)
        {
            foreach (char letter in sentences[1].ToCharArray())
            {
                wrongText.text += letter;
                yield return new WaitForSeconds(typingSpeed);
            }
        }
    }
}
