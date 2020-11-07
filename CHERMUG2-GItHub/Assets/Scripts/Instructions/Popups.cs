using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//////////////////////////////////////////////////<summary>//////////////////////////////////////////////////// 
///                                   University of the West of Scotland                                    ///               
///                               -------------------------------------------                               ///  
/// Script is attached to the PopupObj in the Instructions scene                                            ///
///                                                                                                         ///        
//////////////////////////////////////////////////</summary>///////////////////////////////////////////////////

public class Popups : MonoBehaviour
{
    private Text popupText;
    public int textStates;
    private int animStates;
    private bool changeText_Next;
    private bool changeText_Prev;

    [Tooltip("The anim is the Animator attached to the popup parent object. Drag the parent obj here.")]
    [SerializeField]
    private Animator anim;

    [Tooltip("The popup game object is the popup parent object.")]
    [SerializeField]
    private GameObject popup;

    [Tooltip("The coroutine delay is the delay between the animation popping out and popping in. Increase the number for a longer delay.")]
    [SerializeField] [Range(0f, 1f)]
    private float coroutineDelay = 0.3f;

    // Start is called before the first frame update
    void Start()
    {       
        popup = GameObject.Find("Popup");
        popupText = GameObject.Find("PopupText").GetComponent<Text>(); 
        changeText_Next = false;
        changeText_Prev = false; 
    }

    // Update is called once per frame
    void Update()
    {
        SwitchText();
        AnimationStates();
    }

    public void SwitchText()
    {   //Every time a new case is added, increase the number in the if statement within the CheckTextStates_Next method
        switch (textStates)
        {
            default:
                break;
            //POPUP 1 (the first popup when the scene starts)
            case 0:
                popupText.text = "Welcome to CHERMUG! \n\nCHERMUG stands for Continuing/ Higher Education in Research Methods using Games.";
                break;
            //POPUP 2
            case 1:
                popupText.text = "This game is designed to provide activities to support students taking modules on research methods and statistics.";
                break;
            //POPUP 3
            case 2:
                popupText.text = "The game covers both quantitative and qualitative approaches to research and characterises the research process as a cyclical problem-solving process with different activities and tasks which are carried out at different stages in the research cycle.";
                break;
            //POPUP 4
            case 3:
                popupText.text = "There are various topics that can be accessed from the main menu. \n\nEach topic has multiple mini-games including multiple choice questions, hangman, and tic tac toe.";
                break;
            //POPUP 5
            case 4:
                popupText.text = "Each time you get an answer correct, your score will increase by 100 points. If you get an answer incorrect, your score will decrease by 50 points.";
                break;
            //POPUP 5
            case 5:
                popupText.text = "Your name will be displayed on the name bar on the top right corner of the screen.";
                break;
            //POPUP 6
            case 6:
                popupText.text = "You will unlock achievements for completing certain tasks, such as getting 3 in a row in the tic tac toe mini-game.";
                break;
            //POPUP 7
            case 7:
                popupText.text = "At the end of each topic you will be awarded with a certificate with your name, score, time it took you to complete it, and the date it was completed on.\n\nThe certificate will automatically save to your computer and the folder it is saved to will open automatically so that you can view it.\n\nIt is recommended that you then save it to another easily accessible location.";
                break;
            //POPUP 8
            case 8:
                popupText.text = "In each topic, you can view the research scenario that the questions relate to at any time by pressing the 'view study' button at the top of the screen. While the scenario is being viewed, you can press the 'close' button to close it again.";
                break;
            //POPUP 9
            case 9:
                popupText.text = "In each topic, you can pause the game by pressing the 'esc' or 'p' keys on your keyboard. From the pause screen you can choose to either resume the topic, or to exit to the main menu. If you exit to the main menu, you will lose progress for this topic, however you can access it again at any time from the menu to restart it from the beginning.";
                break;
        }
    }

    public void CheckTextStates_Next()
    {
        if (changeText_Next)
        {
            //Increase it every time new text is added to the textStates switch statement
            if (textStates == 9)
            {
                textStates = 0;//Goes back to the first popup
                DisableText();
            }
            else
            {
                textStates++;
                DisableText();
            }
        }
        StartCoroutine(PopIn());
    }

    public void CheckTextStates_Prev()
    {
        if (changeText_Prev)
        {
            if (textStates == 0)
            {
                textStates = 9;//Always make this equal the same number of the highest case number so that it goes back to the last popup if the user presses prev while on the first popup
                DisableText();
            }
            else
            {
                textStates--;
                DisableText();
            }
        }
        StartCoroutine(PopIn());
    }

    public void DisableText()
    {
        changeText_Prev = false;
        changeText_Next = false;
    }

    public void CheckButtonPress()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;

        if (name == "NextButton")
        {
            changeText_Next = true;
            StartCoroutine(PopOut());
        }
        if (name == "PrevButton")
        {
            changeText_Prev = true;
            StartCoroutine(PopOut());
        }
    }

    public void AnimationStates()
    {
        switch(animStates)
        {
            default:
                break;
            //IDLE ANIM
            case 0:
                anim.SetInteger("States", 0);
                break;
            //POP IN ANIM
            case 1:
                anim.SetInteger("States", 1);
                break;
            //POP OUT ANIM
            case 2:
                anim.SetInteger("States", 2);
                break;
        }
    }

    IEnumerator PopIn()
    {
        animStates = 0;
        yield return null;
    }

    IEnumerator PopOut()
    {
        animStates = 2;
        yield return new WaitForSeconds(coroutineDelay);

        if (changeText_Next)
        {
            StartCoroutine(ChangeText_Next());
        }

        if (changeText_Prev)
        {
            StartCoroutine(ChangeText_Prev());
        }
    }

    IEnumerator ChangeText_Next()
    {
        CheckTextStates_Next();
        yield return null;
    }

    IEnumerator ChangeText_Prev()
    {
        CheckTextStates_Prev();
        yield return null;
    }
}