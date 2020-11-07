using UnityEngine;

//////////////////////////////////////////////////<summary>//////////////////////////////////////////////////// 
///                                   University of the West of Scotland                                    ///               
///                               -------------------------------------------                               ///  
/// Script is attached to the PopupObj in the Instructions scene                                            ///                  
///                                                                                                         ///
//////////////////////////////////////////////////</summary>///////////////////////////////////////////////////

public class Instructions : MonoBehaviour
{
    public Popups popupScript;

    public Animator rightArrowAnim;
    public Animator leftArrowAnim;
    public Animator bottonRightArrowAnim;
    public Animator achievementAnim;
    public Animator certificateAnim;
    public Animator certificate_L_Anim;
    public Animator certificate_R_Anim;
    public Animator viewStudyAnim;
    public Animator viewStudy_arrow_L_Anim;
    public Animator viewStudy_arrow_R_Anim;
    public Animator pauseAnim;
    public Animator pauseTopArrowAnim;
    public Animator pauseBottomArrowAnim;

    public GameObject scoreBar;
    public GameObject nameBar;
    public GameObject popup;
    public GameObject arrow_L;
    public GameObject arrow_R;
    public GameObject arrow_BL;
    public GameObject arrowCertificate_L;
    public GameObject arrowCertificate_R;
    public GameObject certificate;
    public GameObject achievement;
    public GameObject particleSpawner;
    public GameObject viewStudyButton;
    public GameObject viewStudy_arrow_L;
    public GameObject viewStudy_arrow_R;
    public GameObject pausePopup;
    public GameObject pauseTopArrow;
    public GameObject pauseBottomArrow;

    public int textStateCase;
    public int arrowLAnimStates;
    public int arrowRAnimStates;
    public int arrowBRAnimStates;
    public int achievementAnimStates;
    public int CertificateAnimStates;
    public int arrowCertAnimStates;
    public int viewStudyButtonAnimStates;
    public int viewStudyArrowLAnimStates;
    public int viewStudyArrowRAnimStates;
    public int pauseAnimStates;
    public int pauseTopArrowAnimStates;
    public int pauseBottomArrowAnimStates;

    private float coroutineDelay = 1.2f;

    // Start is called before the first frame update
    void Start()
    {
        popupScript = popup.GetComponent<Popups>();

        particleSpawner = GameObject.Find("ParticleSpawner");
        scoreBar = GameObject.Find("ScoreBar");
        nameBar = GameObject.Find("NameBar");
        popup = GameObject.Find("PopupObj");
        arrow_L = GameObject.Find("ArrowParent_L");
        arrow_R = GameObject.Find("ArrowParent_R");
        arrow_BL = GameObject.Find("ArrowParent_BR");
        arrowCertificate_L = GameObject.Find("ArrowParent_Certificate_L");
        arrowCertificate_R = GameObject.Find("ArrowParent_Certificate_R");
        achievement = GameObject.Find("AchievementPopup");
        viewStudyButton = GameObject.Find("ScenarioButton_View");
        viewStudy_arrow_L = GameObject.Find("ArrowParent_ViewStudy_L");
        viewStudy_arrow_R = GameObject.Find("ArrowParent_ViewStudy_R");
        pausePopup = GameObject.Find("PausePopup");
        pauseTopArrow = GameObject.Find("ArrowParent_Pause_Top");
        pauseBottomArrow = GameObject.Find("ArrowParent_Pause_Bottom");

        arrowLAnimStates = 0;
        arrowRAnimStates = 0;
        arrowBRAnimStates = 0;
        achievementAnimStates = 0;
        CertificateAnimStates = 0;
        arrowCertAnimStates = 0;
        viewStudyButtonAnimStates = 0;
        viewStudyArrowLAnimStates = 0;
        viewStudyArrowRAnimStates = 0;
        pauseAnimStates = 0;
        pauseTopArrowAnimStates = 0;
        pauseBottomArrowAnimStates = 0;

        scoreBar.gameObject.GetComponent<ScoreTutBar>().scoreStates = 0;
        nameBar.gameObject.GetComponent<NameTutBar>().nameStates = 0;
    }

    // Update is called once per frame
    void Update()
    {
        textStateCase = popup.GetComponent<Popups>().textStates;
        CheckPopupTextState();
        ArrowLeftAnimationStates();
        ArrowRightAnimationStates();
        ArrowBottomRightAnimationStates();
        AchievementPopupAnimationStates();
        CertificateAnimationStates();
        CertificateArrows();
        ViewStudyButtonAnimationStates();
        ViewStudyArrowLeftAnimStates();
        ViewStudyArrowRightAnimStates();
        PauseAnimationStates();
        pauseTopArrowAnimationStates();
        pauseBottomArrowAnimationStates();
    }

    public void CheckPopupTextState()
    {      
        if(textStateCase == 4)
        {
            scoreBar.gameObject.GetComponent<ScoreTutBar>().scoreStates = 1;
            arrowLAnimStates = 1;
        }
        else
        {
            scoreBar.gameObject.GetComponent<ScoreTutBar>().scoreStates = 0;
            arrowLAnimStates = 0;
        }
        if(textStateCase == 5)
        {
            nameBar.gameObject.GetComponent<NameTutBar>().nameStates = 1;
            arrowRAnimStates = 1;
        }
        else
        {
            nameBar.gameObject.GetComponent<NameTutBar>().nameStates = 0;
            arrowRAnimStates = 0;
        }
        if (textStateCase == 6)
        {
            achievementAnimStates = 1;
            arrowBRAnimStates = 1;
        }
        else
        {
            achievementAnimStates = 2;
            arrowBRAnimStates = 0;
        }
        if (textStateCase == 7)
        {
            CertificateAnimStates = 1;
            arrowCertAnimStates = 1;
        }
        else
        {
            CertificateAnimStates = 2;
            arrowCertAnimStates = 0;
        }
        if (textStateCase == 8)
        {
            viewStudyButtonAnimStates = 1;
            viewStudyArrowLAnimStates = 1;
            viewStudyArrowRAnimStates = 1;
        }
        else
        {
            viewStudyButtonAnimStates = 2;
            viewStudyArrowLAnimStates = 0;
            viewStudyArrowRAnimStates = 0;
        }
        if (textStateCase == 9)
        {
            pauseAnimStates = 1;
            pauseTopArrowAnimStates = 1;
            pauseBottomArrowAnimStates = 1;
        }
        else
        {
            pauseAnimStates = 2;
            pauseTopArrowAnimStates = 0;
            pauseBottomArrowAnimStates = 0;
        }
    }
    public void PauseAnimationStates()
    {
        switch (pauseAnimStates)
        {
            default:
                break;
            case 0:
                //Idle          
                pauseAnim.SetInteger("States", 0);
                break;
            case 1:
                //Animate popup in  
                pauseAnim.SetInteger("States", 1);
                break;
            case 2:
                //Animate popup out             
                pauseAnim.SetInteger("States", 2);
                break;
        }
    }
    public void pauseTopArrowAnimationStates()
    {
        switch (pauseTopArrowAnimStates)
        {
            default:
                break;
            case 0:
                //Idle        
                pauseTopArrowAnim.SetInteger("States", 0);
                break;
            case 1:
                //Animate arrow              
                pauseTopArrowAnim.SetInteger("States", 1);
                break;
        }
    }
    public void pauseBottomArrowAnimationStates()
    {
        switch (pauseBottomArrowAnimStates)
        {
            default:
                break;
            case 0:
                //Idle        
                pauseBottomArrowAnim.SetInteger("States", 0);
                break;
            case 1:
                //Animate arrow              
                pauseBottomArrowAnim.SetInteger("States", 1);
                break;
        }
    }
    public void ViewStudyButtonAnimationStates()
    {
        switch (viewStudyButtonAnimStates)
        {
            default:
                break;
            case 0:
                //Idle          
                viewStudyAnim.SetInteger("States", 0);
                break;
            case 1:
                //Animate popup in  
                viewStudyAnim.SetInteger("States", 1);
                break;
            case 2:
                //Animate popup out             
                viewStudyAnim.SetInteger("States", 2);
                break;
        }
    }
    public void ViewStudyArrowLeftAnimStates()
    {
        switch (viewStudyArrowLAnimStates)
        {
            default:
                break;
            case 0:
                //Idle        
                viewStudy_arrow_L_Anim.SetInteger("States", 0);
                break;
            case 1:
                //Animate arrow              
                viewStudy_arrow_L_Anim.SetInteger("States", 1);
                break;
        }
    }
    public void ViewStudyArrowRightAnimStates()
    {
        switch (viewStudyArrowRAnimStates)
        {
            default:
                break;
            case 0:
                //Idle        
                viewStudy_arrow_R_Anim.SetInteger("States", 0);
                break;
            case 1:
                //Animate arrow              
                viewStudy_arrow_R_Anim.SetInteger("States", 1);
                break;
        }
    }
    public void CertificateAnimationStates()
    {
        switch (CertificateAnimStates)
        {
            default:
                break;
            case 0:
                //Idle        
                certificateAnim.SetInteger("States", 0);
                break;
            case 1:
                //Animate popup in            
                certificateAnim.SetInteger("States", 1);
                break;
            case 2:
                //Animate popup out             
                certificateAnim.SetInteger("States", 2);
                break;
        }
    }
    public void CertificateArrows()
    {
        switch (arrowCertAnimStates)
        {
            default:
                break;
            case 0:
                //Idle        
                certificate_L_Anim.SetInteger("States", 0);
                certificate_R_Anim.SetInteger("States", 0);
                break;
            case 1:
                //Animate arrow              
                certificate_L_Anim.SetInteger("States", 1);
                certificate_R_Anim.SetInteger("States", 1);
                break;
        }
    }

    public void ArrowLeftAnimationStates()
    {
        switch (arrowLAnimStates)
        {
            default:   
                break;
            case 0:
                //Idle        
                leftArrowAnim.SetInteger("States", 0);
                break;
            case 1:
                //Animate arrow              
                leftArrowAnim.SetInteger("States", 1);
                break;
        }
    }
    public void ArrowRightAnimationStates()
    {
        switch (arrowRAnimStates)
        {
            default:
                break;
            case 0:
                //Idle        
                rightArrowAnim.SetInteger("States", 0);
                break;
            case 1:
                //Animate arrow              
                rightArrowAnim.SetInteger("States", 1);
                break;
        }
    }
    public void ArrowBottomRightAnimationStates()
    {
        switch (arrowBRAnimStates)
        {
            default:
                break;
            case 0:
                //Idle        
                bottonRightArrowAnim.SetInteger("States", 0);
                break;
            case 1:
                //Animate arrow              
                bottonRightArrowAnim.SetInteger("States", 1);
                break;
        }
    }
    public void AchievementPopupAnimationStates()
    {
        switch (achievementAnimStates)
        {
            default:
                break;
            case 0:
                //Idle        
                achievementAnim.SetInteger("States", 0);
                break;
            case 1:
                //Animate popup in            
                achievementAnim.SetInteger("States", 1);
                break;
            case 2:
                //Animate popup out             
                achievementAnim.SetInteger("States", 2);
                break;
        }
    }
}
