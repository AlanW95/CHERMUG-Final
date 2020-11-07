using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//////////////////////////////////////////////////<summary>///////////////////////////////////////////////////// 
///                                   University of the West of Scotland                                     ///
///                               -------------------------------------------                                ///  
/// Script is attached to the FadeScreen GameObject (child of the TransitionCanvas)                          ///
///                                                                                                          ///
/// This fades the transition image from 0f to 1f alpha (making it go fully visible)                         ///
///                                                                                                          ///
//////////////////////////////////////////////////</summary>////////////////////////////////////////////////////

public class FadeInTransition : MonoBehaviour
{
    public Image fadeScreen;

    public void FadeImageIn()
    {
        StartCoroutine(FadeIn());
    }

    //Fades the image in before loading the next scene
    IEnumerator FadeIn()
    {
        for (float alpha = -1f; alpha < 1f; alpha += Time.deltaTime)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.b, fadeScreen.color.g, alpha);
            yield return null;
        }
        if (Mathf.RoundToInt(fadeScreen.color.a) == 1)
        {
            Scene scene = SceneManager.GetActiveScene();

            //NATIONALITY & MED FOOD TOPIC SCENES
            if (scene.name == "NMF_QuestionsHM2")
            {
                SceneManager.LoadScene("NMF_NullHypothesis");
            }
            if (scene.name == "NMF_QuestionsTTT")
            {
                SceneManager.LoadScene("NMF_TicTacToe");
            }

            //SKIPPING MEALS & OBESITY TOPID
            if (scene.name == "SMO_QuestionsHM2")
            {
                SceneManager.LoadScene("SMO_NullHypothesis");
            }
            if (scene.name == "SMO_AorB")
            {
                SceneManager.LoadScene("SMO_TicTacToe");
            }

            //GENDER & REWARD TOPIC
            if (scene.name == "GR_QuestionsHM2")
            {
                SceneManager.LoadScene("GR_NullHypothesis");
            }
            if (scene.name == "GR_QuestionsData")
            {
                SceneManager.LoadScene("GR_TicTacToe");
            }

            //WITHIN PARTICIPANTS MEDITATION STRESS TOPIC
            if (scene.name == "MS_QuestionsHM2")
            {
                SceneManager.LoadScene("MS_NullHypothesis");
            }
            if (scene.name == "MS_QuestionsData")
            {
                SceneManager.LoadScene("MS_TicTacToe");
            }

            //MENTAL HEALTH SUPPORT TOPIC
            if (scene.name == "MHS_QuestionsHM")
            {
                SceneManager.LoadScene("MHS_NullHypothesis");
            }
            if (scene.name == "MHS_QuestionsData")
            {
                SceneManager.LoadScene("MHS_TicTacToe");
            }

            //HEALTH BEHAVIOUR AND SPIRITUALITY TOPIC
            if (scene.name == "SH_QuestionsHM2")
            {
                SceneManager.LoadScene("SH_NullHypothesis");
            }
            if (scene.name == "SH_QuestionsData2")
            {
                SceneManager.LoadScene("SH_TicTacToe");
            }

            //EFFECTS OF DIFFERENT KINDS OF DIET ON WEIGHT LOSS TOPIC 
            if (scene.name == "EDK_QuestionsHM2")
            {
                SceneManager.LoadScene("EDK_NullHypothesis");
            }
            if (scene.name == "EDK_QuestionsData")
            {
                SceneManager.LoadScene("EDK_TicTacToe");
            }

            //HEALTH ANXIETY DURING A PANDEMIC TOPIC  
            if (scene.name == "HADP_QuestionsHM2")
            {
                SceneManager.LoadScene("HADP_NullHypothesis");
            }
            if (scene.name == "HADP_QuestionsData")
            {
                SceneManager.LoadScene("HADP_TicTacToe");
            }

            //EFFECTS OF AMOUNT OF EXERCISE ON SLEEP QUALITY
            if (scene.name == "ESQ_QuestionsHM2")
            {
                SceneManager.LoadScene("ESQ_NullHypothesis");
            }
            if (scene.name == "ESQ_QuestionsData")
            {
                SceneManager.LoadScene("ESQ_TicTacToe");
            }

            //SOCIAL MEDIA AND BODY IMAGE TOPIC
            if (scene.name == "SMBI_QuestionsHM2")
            {
                SceneManager.LoadScene("SMBI_NullHypothesis");
            }
            if (scene.name == "SMBI_QuestionsData")
            {
                SceneManager.LoadScene("SMBI_TicTacToe");
            }

            //INTERVENTION, TIME AND BODY POSITIVITY
            if (scene.name == "ITBP_QuestionsHM3")
            {
                SceneManager.LoadScene("ITBP_NullHypothesis");
            }
            if (scene.name == "ITBP_QuestionsData")
            {
                SceneManager.LoadScene("ITBP_TicTacToe");
            }
            
            //SMOKING AND EXERCISE
            if (scene.name == "SE_QuestionsHM")
            {
                SceneManager.LoadScene("SE_NullHypothesis");
            }
            if (scene.name == "SE_QuestionsData")
            {
                SceneManager.LoadScene("SE_TicTacToe");
            }

            //SELF ESTEEM AND SOCIAL MEDIA
            if (scene.name == "SESM_QuestionsHM")
            {
                SceneManager.LoadScene("SESM_NullHypothesis");
            }
            if (scene.name == "SESM_QuestionsData")
            {
                SceneManager.LoadScene("SESM_TicTacToe");
            }

            //BREAKFAST AND OBESITY
            if (scene.name == "BO_QuestionsHM2")
            {
                SceneManager.LoadScene("BO_NullHypothesis");
            }
            if (scene.name == "BO_QuestionsData")
            {
                SceneManager.LoadScene("BO_TicTacToe");
            }

            //SEX AND PROTEIN CONSUMPTION
            if (scene.name == "SPC_QuestionsHM2")
            {
                SceneManager.LoadScene("SPC_NullHypothesis");
            }
            if (scene.name == "SPC_QuestionsData")
            {
                SceneManager.LoadScene("SPC_TicTacToe");
            }

            //ACTIVITY, GENDER AND SELF ESTEEM
            if (scene.name == "AGSE_QuestionsHM3")
            {
                SceneManager.LoadScene("AGSE_NullHypothesis");
            }
            if (scene.name == "AGSE_QuestionsData")
            {
                SceneManager.LoadScene("AGSE_TicTacToe");
            }

            //EXERCISE PROGRAM AND DROPOUT
            if (scene.name == "EPDO_QuestionsHM")
            {
                SceneManager.LoadScene("EPDO_NullHypothesis");
            }
            if (scene.name == "EPDO_QuestionsData")
            {
                SceneManager.LoadScene("EPDO_TicTacToe");
            }

            //NATIONALITY AND BODY IMAGE
            if (scene.name == "NBI_QuestionsHM")
            {
                SceneManager.LoadScene("NBI_NullHypothesis");
            }
            if (scene.name == "NBI_QuestionsData")
            {
                SceneManager.LoadScene("NBI_TicTacToe");
            }
        }
        yield return null;
    }
}
