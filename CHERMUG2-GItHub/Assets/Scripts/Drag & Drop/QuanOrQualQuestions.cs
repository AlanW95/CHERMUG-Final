using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

//////////////////////////////////////////////////<summary>//////////////////////////////////////////////////// 
///                                   University of the West of Scotland                                    ///
///                                 -------------------------------------------                             ///  
/// Script is attached to the Part2Manager in the DragDrop scene.                                           ///
/// This script is for the Part 2 QuanOrQualQuestions.                                                      ///  
//////////////////////////////////////////////////</summary>///////////////////////////////////////////////////

public class QuanOrQualQuestions : MonoBehaviour
{
    public GameObject Part1;
    public GameObject Part2;

    public GameObject correctPopupUI;
    public GameObject incorrectPopupUI;

    public GameObject question1;
    public GameObject question2;
    public GameObject question3;
    public GameObject question4;

    public GameObject quanButton_Q1;
    public GameObject qualButton_Q1;
    public GameObject quanButton_Q2;
    public GameObject qualButton_Q2;
    public GameObject quanButton_Q3;
    public GameObject qualButton_Q3;
    public GameObject quanButton_Q4;
    public GameObject qualButton_Q4;

    public GameObject continueButtonQ1;
    public GameObject continueButtonQ2;
    public GameObject continueButtonQ3;
    public GameObject continueButtonQ4;

    public Button quanButtonQ1;
    public Button qualButtonQ1;
    public Button quanButtonQ2;
    public Button qualButtonQ2;
    public Button quanButtonQ3;
    public Button qualButtonQ3;
    public Button quanButtonQ4;
    public Button qualButtonQ4;

    private int index;

    // Start is called before the first frame update
    void Start()
    {
        continueButtonQ1.SetActive(false);
        continueButtonQ2.SetActive(false);
        continueButtonQ3.SetActive(false);
        continueButtonQ4.SetActive(false);
    }

    //Call this method when the player completes the Drag and Drop Part 1
    public void EnablePart2()
    {
        Part1.SetActive(false);
        Part2.SetActive(true);
        Q1();
    }
    public void Q1()
    {
        question1.SetActive(true);
    }
    public void Q2()
    {
        question1.SetActive(false);
        question2.SetActive(true);
    }
    public void Q3()
    {
        question2.SetActive(false);
        question3.SetActive(true);
    }
    public void Q4()
    {
        question3.SetActive(false);
        question4.SetActive(true);
    }

    public void ButtonPress()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;
        
        //QUESTION 1 BUTTONS
        if (name == "QuanButtonQ1")
        {
            //Incorrect
            index = 0;
            quanButton_Q1.SetActive(false);
            qualButton_Q1.SetActive(false);
            continueButtonQ1.SetActive(true);
            incorrectPopupUI.gameObject.GetComponent<FeedbackPopup>().incorrect_states = 1;
        }
        if (name == "QualButtonQ1")
        {
            //Correct
            index = 1;
            quanButton_Q1.SetActive(false);
            qualButton_Q1.SetActive(false);
            continueButtonQ1.SetActive(true);
            correctPopupUI.gameObject.GetComponent<FeedbackPopup>().correct_states = 1;
        }

        //QUESTION 2 BUTTONS
        if (name == "QuanButtonQ2")
        {
            //Incorrect
            index = 0;
            quanButton_Q2.SetActive(false);
            qualButton_Q2.SetActive(false);
            continueButtonQ2.SetActive(true);
            incorrectPopupUI.gameObject.GetComponent<FeedbackPopup>().incorrect_states = 1;
        }
        if (name == "QualButtonQ2")
        {
            //Correct
            index = 1;
            quanButton_Q2.SetActive(false);
            qualButton_Q2.SetActive(false);
            continueButtonQ2.SetActive(true);
            correctPopupUI.gameObject.GetComponent<FeedbackPopup>().correct_states = 1;
        }

        //QUESTION 3 BUTTONS
        if (name == "QuanButtonQ3")
        {
            //Correct
            index = 1;
            quanButton_Q3.SetActive(false);
            qualButton_Q3.SetActive(false);
            continueButtonQ3.SetActive(true);
            correctPopupUI.gameObject.GetComponent<FeedbackPopup>().correct_states = 1;
            //PlayCorrectSound();
        }
        if (name == "QualButtonQ3")
        {
            //Incorrect
            index = 0;
            quanButton_Q3.SetActive(false);
            qualButton_Q3.SetActive(false);
            continueButtonQ3.SetActive(true);
            incorrectPopupUI.gameObject.GetComponent<FeedbackPopup>().incorrect_states = 1;
        }

        //QUESTION 4 BUTTONS
        if (name == "QuanButtonQ4")
        {
            //Correct
            index = 1;
            quanButton_Q4.SetActive(false);
            qualButton_Q4.SetActive(false);
            continueButtonQ4.SetActive(true);
            correctPopupUI.gameObject.GetComponent<FeedbackPopup>().correct_states = 1;
        }
        if (name == "QualButtonQ4")
        {
            //Incorrect
            index = 0;
            quanButton_Q4.SetActive(false);
            qualButton_Q4.SetActive(false);
            continueButtonQ4.SetActive(true);
            incorrectPopupUI.gameObject.GetComponent<FeedbackPopup>().incorrect_states = 1;
        }

        //CONTINUE BUTTONS
        if (name == "ContinueButtonQ1")
        {
            if(index == 0)
            {
                incorrectPopupUI.gameObject.GetComponent<FeedbackPopup>().incorrect_states = 2;
            }
            if (index == 1)
            {
                correctPopupUI.gameObject.GetComponent<FeedbackPopup>().correct_states = 2;
            }
            Q2();
        }
        if (name == "ContinueButtonQ2")
        {
            if (index == 0)
            {
                incorrectPopupUI.gameObject.GetComponent<FeedbackPopup>().incorrect_states = 2;
            }
            if (index == 1)
            {
                correctPopupUI.gameObject.GetComponent<FeedbackPopup>().correct_states = 2;
            }
            Q3();
        }
        if (name == "ContinueButtonQ3")
        {
            if (index == 0)
            {
                incorrectPopupUI.gameObject.GetComponent<FeedbackPopup>().incorrect_states = 2;
            }
            if (index == 1)
            {
                correctPopupUI.gameObject.GetComponent<FeedbackPopup>().correct_states = 2;
            }
            Q4();
        }
        if (name == "ContinueButtonQ4")
        {
            if (index == 0)
            {
                incorrectPopupUI.gameObject.GetComponent<FeedbackPopup>().incorrect_states = 2;
            }
            if (index == 1)
            {
                correctPopupUI.gameObject.GetComponent<FeedbackPopup>().correct_states = 2;
            }
            SceneManager.LoadScene("MainMenu");
        }
    }
}
