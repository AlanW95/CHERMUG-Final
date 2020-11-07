using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

//////////////////////////////////////////////////<summary>//////////////////////////////////////////////////// 
///                                   University of the West of Scotland                                    ///
///                                          SEX AND REWARD TOPIC                                           ///
///                               -------------------------------------------                               ///  
/// Script is attached to the Game Controller GameObject in the GR_TicTacToe scene.                         ///
///                                                                                                         ///
//////////////////////////////////////////////////</summary>///////////////////////////////////////////////////

public class GR_TicTacToe : MonoBehaviour
{
    [SerializeField] private GameObject instructions;
    [SerializeField] private GameObject ttt;
    [SerializeField] private GameObject question;
    [SerializeField] private GameObject feedback;

    public GameObject[] slots; //GridSpace1-GridSpace9
    public GameObject[] correctIncorrectSlots; //GridSpace1-Correct/Incorrect to 9
    public Button[] qButtons; //GridSpace1-9 Buttons
    public GameObject[] trueFalseButtons; //TrueButton_1, FalseButton_1 to 9

    [SerializeField] private Text questionText;
    [SerializeField] private Text feedbackText;
    
    [SerializeField] private GameObject contingency;

    public Text[] buttonList;
    public GameObject gameOverPanel;
    public Text gameOverText;
    public GameObject restartButton;

    private string playerSide;
    private int moveCount;

    public GameObject scenarioObj;
    public GameObject scenarioCloseButton;
    public GameObject scenarioViewButton;
    public GameObject scenarioButtonClickBlock;

    public GameObject scoreBar;
    public GameObject nameBar;

    //Typing Text
    public string[] sentences;
    private int index;
    public float typingSpeed;
    public GameObject continueButton;

    public float timer;
    public GameObject progressButton;

    public GameObject character;
    public GameObject fadeScreen;
    
    private bool[] truePressed;
    private bool[] falsePressed;
    private bool finished;
    [SerializeField] private GameObject finishButton;

    void Awake()
    {
        timer = 0;
        fadeScreen.gameObject.GetComponent<FadeOutTransition>().FadeImageOut();

        scenarioObj = GameObject.Find("ResearchScenario");
        scenarioCloseButton = GameObject.Find("ScenarioButton_Close");
        scenarioViewButton = GameObject.Find("ScenarioButton_View");
        scenarioButtonClickBlock = GameObject.Find("GR_ButtonClickBlock");

        nameBar = GameObject.Find("NameBar");
        scoreBar = GameObject.Find("ScoreBar");
        
        instructions = GameObject.Find("Instructions_UI");
        ttt = GameObject.Find("TicTacToe");
        question = GameObject.Find("Question");
        feedback = GameObject.Find("Feedback");
        
        questionText = GameObject.Find("Statement").GetComponent<Text>();
        feedbackText = GameObject.Find("FeedbackText").GetComponent<Text>();

        contingency = GameObject.Find("ContingencyTable");
        
        finishButton = GameObject.Find("Finish_Button");
        
        instructions.SetActive(true);
        ttt.SetActive(false);

        for (int i = 0; i < correctIncorrectSlots.Length; i++)
        {
            correctIncorrectSlots[i].SetActive(false);
        }

        gameOverPanel.SetActive(false); 
        moveCount = 0;
        restartButton.SetActive(false);
        question.SetActive(false);

        for (int i = 0; i < trueFalseButtons.Length; i++)
        {
            trueFalseButtons[i].SetActive(false);
        }

        contingency.SetActive(false);
        feedback.SetActive(false);

        scenarioViewButton.gameObject.SetActive(true);
        scenarioCloseButton.gameObject.SetActive(false);
        progressButton.SetActive(false);

        scenarioButtonClickBlock.SetActive(false);
        
        finished = false;
        finishButton.SetActive(false);
        truePressed = new bool[9];
        falsePressed = new bool[9];

        for (int t = 0; t < truePressed.Length; t++)
        {
            if (truePressed[t] == true)
            {
                truePressed[t] = false;
            }
        }
        for (int f = 0; f < falsePressed.Length; f++)
        {
            if (falsePressed[f] == true)
            {
                falsePressed[f] = false;
            }
        }
        SpeechBubbleText();
    }

    // Update is called once per frame
    void Update()
    {
        //When typing text is typing, when the length is equal to the text the buttons will appear
        for (int ft = 0; ft < sentences.Length; ft++)
        {
            if (feedbackText.text == sentences[ft])
            {
                continueButton.SetActive(true);
            }

            if (feedbackText.text == sentences[18])
            {
                continueButton.SetActive(false);
                finishButton.SetActive(true);
            }
        }
    }

    public void SpeechBubbleText()
    {
        //question 1
        //q1a2
        sentences[0] = "Correct: There were 100 participants altogether in this study.";
        //q1a1
        sentences[1] = "Incorrect: There were 100 participants altogether in this study.";
        //question 2
        //q2a1
        sentences[2] = "Correct: Half the participants were male and half were female.";
        //q2a2
        sentences[3] = "Incorrect: Half the participants were male and half were female.";
        //question 3
        //q3a2
        sentences[4] = "Correct: Altogether 70 people chose chocolate and 30 chose crisps, so there were more people in the sample who chose chocolate than who chose crisps.";
        //q3a1
        sentences[5] = "Incorrect: Altogether 70 people chose chocolate and 30 chose crisps, so there were more people in the sample who chose chocolate than who chose crisps.";
        //question 4
        //q4a2
        sentences[6] = "Correct: There were more females in the sample who chose chocolate than who chose crisps.";
        //q4a1
        sentences[7] = "Incorrect: There were more females in the sample who chose chocolate than who chose crisps.";
        //question 5
        //q5a1
        sentences[8] = "Correct: 7 females and 23 males chose crisps, so more males than females chose crisps.";
        //q5a2
        sentences[9] = "Incorrect: 7 females and 23 males chose crisps, so more males than females chose crisps.";
        //question 6
        //q6a1
        sentences[10] = "Correct: There were more males in the sample who chose chocolate than who chose crisps.";
        //q6a2
        sentences[11] = "Incorrect: There were more males in the sample who chose chocolate than who chose crisps.";
        //question 7
        //q7a1
        sentences[12] = "Correct: Altogether there were more people in the sample who chose chocolate than who chose crisps.";
        //q7a2
        sentences[13] = "Incorrect: Altogether there were more people in the sample who chose chocolate than who chose crisps.";
        //question 8
        //q8a2
        sentences[14] = "Correct: The pattern of choices of reward was different for males and females.";
        //q8a1
        sentences[15] = "Incorrect: The pattern of choices of reward was different for males and females.";
        //question 9
        //q9a1
        sentences[16] = "Correct: 70 participants chose chocolate and 30 chose crisps.";
        //q9a2
        sentences[17] = "Incorrect: 70 participants chose chocolate and 30 chose crisps.";
        //final feedback for getting three in a row that are correct
        sentences[18] = "Congratulations! You got three in a row. Well done!";
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene("GR_QuestionsTTT");
    }

    //Start the game
    //This is called when the Ready button is pressed on the Instructions_UI
    public void ReadyUp()
    {
        nameBar.gameObject.GetComponent<BarAnimations>().states = 1;
        scoreBar.gameObject.GetComponent<BarAnimations>().states = 1;
        instructions.SetActive(false);
        feedback.SetActive(false);
        CloseStudy();

        question.SetActive(false);
        ttt.SetActive(true);
        gameOverPanel.SetActive(false);
        
        for (int t = 0; t < truePressed.Length; t++)
        {
            if (truePressed[t] == true)
            {
                truePressed[t] = false;
            }
        }
        for (int f = 0; f < falsePressed.Length; f++)
        {
            if (falsePressed[f] == true)
            {
                falsePressed[f] = false;
            }
        }
    }
    
    public void ViewStudy()
    {
        scenarioObj.gameObject.GetComponent<ScenarioAnimations>().states = 1;
        scenarioCloseButton.gameObject.SetActive(true);
        scenarioViewButton.gameObject.SetActive(false);
        scenarioButtonClickBlock.SetActive(true);
    }
    
    public void CloseStudy()
    {
        scenarioObj.gameObject.GetComponent<ScenarioAnimations>().states = 2;
        scenarioViewButton.gameObject.SetActive(true);
        scenarioCloseButton.gameObject.SetActive(false);
        scenarioButtonClickBlock.SetActive(false);
    }

    public void Help()
    {
        instructions.SetActive(true);
        ttt.SetActive(false);
    }

    public void RestartGame()
    {
        moveCount = 0;
    
        for (int i = 0; i < correctIncorrectSlots.Length; i++)
        {
            correctIncorrectSlots[i].SetActive(false);
        }

        SetBoardInteractable(true);

        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].text = "";
        }
    }

    void SetBoardInteractable (bool toggle)
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = toggle;
        }
    }

    public void EndTurn()
    {
        //each possible combination to be able to win
        if (buttonList[0].text == "X" && buttonList[1].text == "X" && buttonList[2].text == "X" ||
            buttonList[3].text == "X" && buttonList[4].text == "X" && buttonList[5].text == "X" ||
            buttonList[6].text == "X" && buttonList[7].text == "X" && buttonList[8].text == "X" ||
            buttonList[0].text == "X" && buttonList[3].text == "X" && buttonList[6].text == "X" ||
            buttonList[1].text == "X" && buttonList[4].text == "X" && buttonList[7].text == "X" ||
            buttonList[2].text == "X" && buttonList[5].text == "X" && buttonList[8].text == "X" ||
            buttonList[0].text == "X" && buttonList[4].text == "X" && buttonList[8].text == "X" ||
            buttonList[2].text == "X" && buttonList[4].text == "X" && buttonList[6].text == "X")
        {
            continueButton.SetActive(false);

            feedback.SetActive(true);
            feedbackText.text = "";
            question.SetActive(false);
            ttt.SetActive(false);
            finished = true;
            scoreBar.gameObject.GetComponent<ScoreSystem>().AddGRTicTacToeScore();
            AchievementManager.instance.Unlock("SR_achievement_03");
            StartCoroutine(Type());
        }
        if (moveCount >= 7)
        {
            restartButton.SetActive(true);
            progressButton.SetActive(true);
        }
    }

    public void ButtonPress()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;
        
        if (name == "GridSpace1")
        {
            questionText.text = "There were 200 participants altogether in this study.";
            question.SetActive(true);
            trueFalseButtons[0].SetActive(true);
            trueFalseButtons[1].SetActive(true);
            ttt.SetActive(false);
            qButtons[0].interactable = false;
        }
        if (name == "GridSpace2")
        {
            questionText.text = "Half the participants were male and half were female.";
            question.SetActive(true);
            trueFalseButtons[2].SetActive(true);
            trueFalseButtons[3].SetActive(true);
            ttt.SetActive(false);
            qButtons[1].interactable = false;
        }
        if (name == "GridSpace3")
        {
            questionText.text = "Altogether there were more people in the sample who chose crisps than who chose chocolate.";
            question.SetActive(true);
            trueFalseButtons[4].SetActive(true);
            trueFalseButtons[5].SetActive(true);
            ttt.SetActive(false);
            qButtons[2].interactable = false;
        }
        if (name == "GridSpace4")
        {
            questionText.text = "There were more females in the sample who chose chocolate than who chose crisps.";
            question.SetActive(true);
            trueFalseButtons[6].SetActive(true);
            trueFalseButtons[7].SetActive(true);
            ttt.SetActive(false);
            qButtons[3].interactable = false;
        }
        if (name == "GridSpace5")
        {
            questionText.text = "There were more females than males in the sample who chose crisps.";
            question.SetActive(true);
            trueFalseButtons[8].SetActive(true);
            trueFalseButtons[9].SetActive(true);
            ttt.SetActive(false);
            qButtons[4].interactable = false;
        }
        if (name == "GridSpace6")
        {
            questionText.text = "There were more males in the sample who chose chocolate than who chose crisps.";
            question.SetActive(true);
            trueFalseButtons[10].SetActive(true);
            trueFalseButtons[11].SetActive(true);
            ttt.SetActive(false);
            qButtons[5].interactable = false;
        }
        if (name == "GridSpace7")
        {
            questionText.text = "Altogether there were more people in the sample who chose chocolate than who chose crisps.";
            question.SetActive(true);
            trueFalseButtons[12].SetActive(true);
            trueFalseButtons[13].SetActive(true);
            ttt.SetActive(false);
            qButtons[6].interactable = false;
        }
        if (name == "GridSpace8")
        {
            questionText.text = "The pattern of choices was different for males and females.";
            question.SetActive(true);
            trueFalseButtons[14].SetActive(true);
            trueFalseButtons[15].SetActive(true);
            ttt.SetActive(false);
            qButtons[7].interactable = false;
        }
        if (name == "GridSpace9")
        {
            questionText.text = "Half the participants chose chocolate and half chose crisps.";
            question.SetActive(true);
            trueFalseButtons[16].SetActive(true);
            trueFalseButtons[17].SetActive(true);
            ttt.SetActive(false);
            qButtons[8].interactable = false;
        }
        //----------------------------------------------------------------------------------

        if (name == "ContingencyTableButton")
        {
            contingency.SetActive(true);
        }

        if (name == "XButton")
        {   
            contingency.SetActive(false);
        }

        //Q1
        if (name == "TrueButton_1")
        {
            //Incorrect
            character.gameObject.GetComponent<CharacterAnims>().states = 3;//Shake head anim
            truePressed[0] = true;
            trueFalseButtons[0].SetActive(false);
            trueFalseButtons[1].SetActive(false);
            buttonList[0].text = "O";
            correctIncorrectSlots[1].SetActive(true);
            index = 1;
            ActivateFeedback();
        }
        if (name == "FalseButton_1")
        {
            //Correct
            character.gameObject.GetComponent<CharacterAnims>().states = 2;//Thumbs up anim
            falsePressed[0] = true;
            trueFalseButtons[0].SetActive(false);
            trueFalseButtons[1].SetActive(false);
            buttonList[0].text = "X";
            correctIncorrectSlots[0].SetActive(true);
            index = 0;
            ActivateFeedback();
        }
        //---------------------------
        //Q2
        if (name == "TrueButton_2")
        {
            //Correct
            character.gameObject.GetComponent<CharacterAnims>().states = 2;//Thumbs up anim
            truePressed[1] = true;
            trueFalseButtons[2].SetActive(false);
            trueFalseButtons[3].SetActive(false);
            buttonList[1].text = "X";
            correctIncorrectSlots[2].SetActive(true);
            index = 2;
            ActivateFeedback();
        }
        if (name == "FalseButton_2")
        {
            //Incorrect
            character.gameObject.GetComponent<CharacterAnims>().states = 3;//Shake head anim
            falsePressed[1] = true;
            trueFalseButtons[2].SetActive(false);
            trueFalseButtons[3].SetActive(false);
            buttonList[1].text = "O";
            correctIncorrectSlots[3].SetActive(true);
            index = 3;
            ActivateFeedback();
        }
        //---------------------------
        //Q3
        if (name == "TrueButton_3")
        {
            //Incorrect
            character.gameObject.GetComponent<CharacterAnims>().states = 3;//Shake head anim
            truePressed[2] = true;
            trueFalseButtons[4].SetActive(false);
            trueFalseButtons[5].SetActive(false);
            buttonList[2].text = "O";
            correctIncorrectSlots[5].SetActive(true);
            index = 5;
            ActivateFeedback();
        }
        if (name == "FalseButton_3")
        {
            //Correct
            character.gameObject.GetComponent<CharacterAnims>().states = 2;//Thumbs up anim
            falsePressed[2] = true;
            trueFalseButtons[4].SetActive(false);
            trueFalseButtons[5].SetActive(false);
            buttonList[2].text = "X";
            correctIncorrectSlots[4].SetActive(true);
            index = 4;
            ActivateFeedback();
        }
        //---------------------------
        //Q4
        if (name == "TrueButton_4")
        {
            //Correct
            character.gameObject.GetComponent<CharacterAnims>().states = 2;//Thumbs up anim
            truePressed[3] = true;
            trueFalseButtons[6].SetActive(false);
            trueFalseButtons[7].SetActive(false);
            buttonList[3].text = "X";
            correctIncorrectSlots[6].SetActive(true);
            index = 6;
            ActivateFeedback();
        }
        if (name == "FalseButton_4")
        {
            //Incorrect
            character.gameObject.GetComponent<CharacterAnims>().states = 3;//Shake head anim
            falsePressed[3] = true;
            trueFalseButtons[6].SetActive(false);
            trueFalseButtons[7].SetActive(false);
            buttonList[3].text = "O";
            correctIncorrectSlots[7].SetActive(true);
            index = 7;
            ActivateFeedback();
        }
        //---------------------------
        //Q5
        if (name == "TrueButton_5")
        {
            //Incorrect
            character.gameObject.GetComponent<CharacterAnims>().states = 3;//Shake head anim
            truePressed[4] = true;
            trueFalseButtons[8].SetActive(false);
            trueFalseButtons[9].SetActive(false);
            buttonList[4].text = "O";
            correctIncorrectSlots[9].SetActive(true);
            index = 9;
            ActivateFeedback();
        }
        if (name == "FalseButton_5")
        {
            //Correct
            character.gameObject.GetComponent<CharacterAnims>().states = 2;//Thumbs up anim
            falsePressed[4] = true;
            trueFalseButtons[8].SetActive(false);
            trueFalseButtons[9].SetActive(false);
            buttonList[4].text = "X";
            correctIncorrectSlots[8].SetActive(true);
            index = 8;
            ActivateFeedback();
        }
        //---------------------------
        //Q6
        if (name == "TrueButton_6")
        {
            //Correct
            character.gameObject.GetComponent<CharacterAnims>().states = 2;//Thumbs up anim
            truePressed[5] = true;
            trueFalseButtons[10].SetActive(false);
            trueFalseButtons[11].SetActive(false);
            buttonList[5].text = "X";
            correctIncorrectSlots[10].SetActive(true);
            index = 10;
            ActivateFeedback();
        }
        if (name == "FalseButton_6")
        {
            //Incorrect
            character.gameObject.GetComponent<CharacterAnims>().states = 3;//Shake head anim
            falsePressed[5] = true;
            trueFalseButtons[10].SetActive(false);
            trueFalseButtons[11].SetActive(false);
            buttonList[5].text = "O";
            correctIncorrectSlots[11].SetActive(true);
            index = 11;
            ActivateFeedback();
        }
        //---------------------------
        //Q7
        if (name == "TrueButton_7")
        {
            //Correct
            character.gameObject.GetComponent<CharacterAnims>().states = 2;//Thumbs up anim
            truePressed[6] = true;
            trueFalseButtons[12].SetActive(false);
            trueFalseButtons[13].SetActive(false);
            buttonList[6].text = "X";
            correctIncorrectSlots[12].SetActive(true);
            index = 12;
            ActivateFeedback();
        }
        if (name == "FalseButton_7")
        {
            //Incorrect
            character.gameObject.GetComponent<CharacterAnims>().states = 3;//Shake head anim
            falsePressed[6] = true;
            trueFalseButtons[12].SetActive(false);
            trueFalseButtons[13].SetActive(false);
            buttonList[6].text = "O";
            correctIncorrectSlots[13].SetActive(true);
            index = 13;
            ActivateFeedback();
        }
        //---------------------------
        //Q8
        if (name == "TrueButton_8")
        {
            //Correct
            character.gameObject.GetComponent<CharacterAnims>().states = 2;//Thumbs up anim
            truePressed[7] = true;
            trueFalseButtons[14].SetActive(false);
            trueFalseButtons[15].SetActive(false);
            buttonList[7].text = "X";
            correctIncorrectSlots[14].SetActive(true);
            index = 14;
            ActivateFeedback();
        }
        if (name == "FalseButton_8")
        {
            //Incorrect
            character.gameObject.GetComponent<CharacterAnims>().states = 3;//Shake head anim
            falsePressed[7] = true;
            trueFalseButtons[14].SetActive(false);
            trueFalseButtons[15].SetActive(false);
            buttonList[7].text = "O";
            correctIncorrectSlots[15].SetActive(true);
            index = 15;
            ActivateFeedback();
        }
        //---------------------------
        //Q9
        if (name == "TrueButton_9")
        {
            //Incorrect
            character.gameObject.GetComponent<CharacterAnims>().states = 3;//Shake head anim
            truePressed[8] = true;
            trueFalseButtons[16].SetActive(false);
            trueFalseButtons[17].SetActive(false);
            buttonList[8].text = "O";
            correctIncorrectSlots[17].SetActive(true);
            index = 17;
            ActivateFeedback();
        }
        if (name == "FalseButton_9")
        {
            //Correct
            character.gameObject.GetComponent<CharacterAnims>().states = 2;//Thumbs up anim
            falsePressed[8] = true;
            trueFalseButtons[16].SetActive(false);
            trueFalseButtons[17].SetActive(false);
            buttonList[8].text = "X";
            correctIncorrectSlots[16].SetActive(true);
            index = 16;
            ActivateFeedback();
        }
        //---------------------------
    }
    public void ActivateFeedback()
    {
        feedback.SetActive(true);
        continueButton.SetActive(false);
        feedbackText.text = "";
        moveCount++;
        StartCoroutine(Type());
    }
    IEnumerator Type()
    {
        //Correct Answers
        if (falsePressed[0] || truePressed[1] || falsePressed[2] || truePressed[3] || falsePressed[4] || truePressed[5] || truePressed[6] || truePressed[7] || falsePressed[8])
        {
            foreach (char letter in sentences[index].ToCharArray())
            {
                feedbackText.text += letter;
                yield return new WaitForSeconds(typingSpeed);
            }
        }
        //Incorrect Answers
        if (truePressed[0] || falsePressed[1] || truePressed[2] || falsePressed[3] || truePressed[4] || falsePressed[5] || falsePressed[6] || falsePressed[7] || truePressed[8])
        {
            foreach (char letter in sentences[index].ToCharArray())
            {
                feedbackText.text += letter;
                yield return new WaitForSeconds(typingSpeed);
            }
        }
        //Finished
        if (finished == true)
        {
            foreach (char letter in sentences[18].ToCharArray())
            {
                feedbackText.text += letter;
                yield return new WaitForSeconds(typingSpeed);
            }
        }
    }
}