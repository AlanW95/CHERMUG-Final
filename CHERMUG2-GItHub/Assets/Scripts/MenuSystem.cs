using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//////////////////////////////////////////////////<summary>//////////////////////////////////////////////////// 
///                                   University of the West of Scotland                                    ///
///                               -------------------------------------------                               ///  
/// Script is attached to the SceneManager GameObject in the MainMenu scene.                                ///
///                                                                                                         ///
//////////////////////////////////////////////////</summary>///////////////////////////////////////////////////

public class MenuSystem : MonoBehaviour
{
    private GameObject achievementsList;
    private Button achievementButton;

    private bool toggle;
    private GameObject audioOn, audioOff;

    // Start is called before the first frame update
    void Start()
    {
        audioOn = GameObject.Find("SpeakerOn");
        audioOff = GameObject.Find("SpeakerOff");
        audioOff.SetActive(false);

        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "Instructions")
        {
            return;
        }
        else
        {
            achievementsList = GameObject.Find("AchievementsList");
            achievementButton = GameObject.Find("Button_Achievements").GetComponent<Button>();
        }
    }

    void Update()
    {
        if (AudioListener.volume == 0f)
        {
            audioOff.SetActive(true);
            audioOn.SetActive(false);
        } else
        {
            toggle = true;
        }
    }

    public void QuanMenuButton()
    {
        SceneManager.LoadScene("QuantitativeMenu");
    }

    public void QualMenuButton()
    {
        SceneManager.LoadScene("QualitativeMenu");
    }

    public void MainMenuButton() 
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuanVSQualButton()
    {
        SceneManager.LoadScene("DragDrop");
    }

    public void QuitToDesktopButton()
    {
        Application.Quit();
    }

    public void InstructionsButton()
    {
        SceneManager.LoadScene("Instructions");
    }

    //QUANTITATIVE MENU TOPIC BUTTONS
    //CHI SQUARE TOPICS
    public void SexAndRewardTopic()
    {
        SceneManager.LoadScene("GR_MultipleChoice");
    }
    public void SkippingMealsAndObesityTopic()
    {
        SceneManager.LoadScene("SMO_MultipleChoice");
    }
    public void ExerciseProgramAndDropoutTopic()
    {
        SceneManager.LoadScene("EPDO_MultipleChoice");
    }
    public void NationalityAndBodyImageTopic()
    {
        SceneManager.LoadScene("NBI_MultipleChoice");
    }

    //T-TEST TOPICS
    public void NationalityAndMedFoodsTopic()
    {
        SceneManager.LoadScene("NMF_MultipleChoice");
    }
    public void MeditationAndStressTopic()
    {
        SceneManager.LoadScene("MS_MultipleChoice");
    }
    public void EffectsDietWeightLossTopic()
    {
        SceneManager.LoadScene("EDK_MultipleChoice");
    }
    public void HealthAnxietyDuringPandemicTopic()
    {
        SceneManager.LoadScene("HADP_MultipleChoice");
    }
    public void BreakfastAndObesityTopic()
    {
        SceneManager.LoadScene("BO_MultipleChoice");
    }
    public void SexAndProteinConsumptionTopic()
    {
        SceneManager.LoadScene("SPC_MultipleChoice");
    }

    //ANOVA TOPICS
    public void ExerciseOnSleepQualityTopic()
    {
        SceneManager.LoadScene("ESQ_MultipleChoice");
    }
    public void SocialMediaAndBodyImageTopic()
    {
        SceneManager.LoadScene("SMBI_MultipleChoice");
    }
    public void InterventionTimeBodyPositivityTopic()
    {
        SceneManager.LoadScene("ITBP_MultipleChoice");
    }
    public void ActivityGenderAndSelfEsteemTopic()
    {
        SceneManager.LoadScene("AGSE_MultipleChoice");
    }

    //CORRELATION TOPICS
    public void MentalHealthSocialSupportTopic()
    {
        SceneManager.LoadScene("MHS_MultipleChoice");
    }
    public void SpiritualityHealthTopic()
    {
        SceneManager.LoadScene("SH_MultipleChoice");
    }
    public void SmokingAndExerciseTopic()
    {
        SceneManager.LoadScene("SE_MultipleChoice");
    }
    public void SelfEsteemAndSocialMediaTopic()
    {
        SceneManager.LoadScene("SESM_MultipleChoice");
    }

    public void ToggleSound()
    {
        toggle = !toggle;

        if (toggle)
        {
            AudioListener.volume = 1f;
            audioOn.SetActive(true);
            audioOff.SetActive(false);
        }
        if (!toggle)
        {
            AudioListener.volume = 0f;
            audioOff.SetActive(true);
            audioOn.SetActive(false);
        }
    }
}
