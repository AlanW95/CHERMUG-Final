using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

//////////////////////////////////////////////////<summary>//////////////////////////////////////////////////// 
///                                   University of the West of Scotland                                    ///
///                               -------------------------------------------                               ///  
/// Script is attached to the TimerManager GameObject in the QuantitativeMenu.                              ///
/// This is used to start the timer count and increase it, the timer stops when the EndSummary scene loads. ///
///                                                                                                         ///
//////////////////////////////////////////////////</summary>///////////////////////////////////////////////////

public class TimerGame : MonoBehaviour
{
    //Text
    public Text timerText;

    //Nationality and Mediterranean Foods Timer
    public float medStartTime;   
    public float medTimer;
    public bool medTimerStatus;

    //Gender and Reward Timer
    public float grStartTime;
    public float grTimer;
    public bool grTimerStatus;

    //Skipping Meals and Obesity Timer
    public float smoStartTime;
    public float smoTimer;
    public bool smoTimerStatus;

    //Within Participants Meditation Stress Timer
    public float msStartTime;
    public float msTimer;
    public bool msTimerStatus;

    //MHS Timer
    public float mhsStartTime;
    public float mhsTimer;
    public bool mhsTimerStatus;

    //SH Timer
    public float shStartTime;
    public float shTimer;
    public bool shTimerStatus;

    //EDK Timer
    public float edkStartTime;
    public float edkTimer;
    public bool edkTimerStatus;

    //HADP Timer
    public float hadpStartTime;
    public float hadpTimer;
    public bool hadpTimerStatus;

    //ESQ Timer
    public float esqStartTime;
    public float esqTimer;
    public bool esqTimerStatus;

    //SMBI Timer
    public float smbiStartTime;
    public float smbiTimer;
    public bool smbiTimerStatus;

    //SE Timer
    public float seStartTime;
    public float seTimer;
    public bool seTimerStatus;

    //ITBP Timer
    public float itbpStartTime;
    public float itbpTimer;
    public bool itbpTimerStatus;

    //SESM Timer
    public float sesmStartTime;
    public float sesmTimer;
    public bool sesmTimerStatus;

    //BO Timer
    public float boStartTime;
    public float boTimer;
    public bool boTimerStatus;

    //SPC Timer
    public float spcStartTime;
    public float spcTimer;
    public bool spcTimerStatus;

    //AGSE Timer
    public float agseStartTime;
    public float agseTimer;
    public bool agseTimerStatus;

    //EPDO Timer
    public float epdoStartTime;
    public float epdoTimer;
    public bool epdoTimerStatus;

    //NBI Timer
    public float nbiStartTime;
    public float nbiTimer;
    public bool nbiTimerStatus;

    void Start()
    {
        timerText = GameObject.Find("Text").GetComponent<Text>();
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "NMF_EndSummary")
        {
            //stop the timer
            medTimerStatus = false;
        }

        if (scene.name == "SMO_EndSummary")
        {
            //stop the timer
            smoTimerStatus = false;
        }

        if (scene.name == "GR_EndSummary")
        {
            //stop the timer
            grTimerStatus = false;
        }

        if (scene.name == "MS_EndSummary")
        {
            //stop the timer
            msTimerStatus = false;
        }

        if (scene.name == "MHS_EndSummary")
        {
            //stop the timer
            mhsTimerStatus = false;
        }

        if (scene.name == "SH_EndSummary")
        {
            //stop the timer
            shTimerStatus = false;
        }

        if (scene.name == "EDK_EndSummary")
        {
            //stop the timer
            edkTimerStatus = false;
        }

        if (scene.name == "HADP_EndSummary")
        {
            //stop the timer
            hadpTimerStatus = false;
        }

        if (scene.name == "ESQ_EndSummary")
        {
            //stop the timer
            esqTimerStatus = false;
        }

        if (scene.name == "SMBI_EndSummary")
        {
            //stop the timer
            smbiTimerStatus = false;
        }

        if (scene.name == "SE_EndSummary")
        {
            //stop the timer
            seTimerStatus = false;
        }

        if (scene.name == "ITBP_EndSummary")
        {
            //stop the timer
            itbpTimerStatus = false;
        }

        if (scene.name == "SESM_EndSummary")
        {
            //stop the timer
            sesmTimerStatus = false;
        }

        if (scene.name == "BO_EndSummary")
        {
            //stop the timer
            boTimerStatus = false;
        }

        if (scene.name == "SPC_EndSummary")
        {
            //stop the timer
            spcTimerStatus = false;
        }

        if (scene.name == "AGSE_EndSummary")
        {
            //stop the timer
            agseTimerStatus = false;
        }

        if (scene.name == "EPDO_EndSummary")
        {
            //stop the timer
            epdoTimerStatus = false;
        }

        if (scene.name == "NBI_EndSummary")
        {
            //stop the timer
            nbiTimerStatus = false;
        }

        if (medTimerStatus)
        {
            //keep timer going
            medTimer = Time.time - medStartTime;
        }

        if (!medTimerStatus)
        {
            medStartTime += Time.deltaTime;
            string minutes = ((int)medTimer / 60).ToString();
            string seconds = (medTimer % 60).ToString("f1");

            PlayerPrefs.SetString("med_timer", minutes + ":" + seconds);
        }

        if (smoTimerStatus)
        {
            //keep timer going
            smoTimer = Time.time - smoStartTime;
        }

        if (!smoTimerStatus)
        {
            smoStartTime += Time.deltaTime;
            string minutes = ((int)smoTimer / 60).ToString();
            string seconds = (smoTimer % 60).ToString("f1");

            PlayerPrefs.SetString("smo_timer", minutes + ":" + seconds);
        }

        if (grTimerStatus)
        {
            //keep timer going
            grTimer = Time.time - grStartTime;
        }

        if (!grTimerStatus)
        {
            grStartTime += Time.deltaTime;
            string minutes = ((int)grTimer / 60).ToString();
            string seconds = (grTimer % 60).ToString("f1");

            PlayerPrefs.SetString("gr_timer", minutes + ":" + seconds);
        }

        if (msTimerStatus)
        {
            //keep timer going
            msTimer = Time.time - msStartTime;
        }

        if (!msTimerStatus)
        {
            msStartTime += Time.deltaTime;
            string minutes = ((int)msTimer / 60).ToString();
            string seconds = (msTimer % 60).ToString("f1");

            PlayerPrefs.SetString("ms_timer", minutes + ":" + seconds);
        }

        if (mhsTimerStatus)
        {
            //keep timer going
            mhsTimer = Time.time - mhsStartTime;
        }

        if (!mhsTimerStatus)
        {
            mhsStartTime += Time.deltaTime;
            string minutes = ((int)mhsTimer / 60).ToString();
            string seconds = (mhsTimer % 60).ToString("f1");

            PlayerPrefs.SetString("mhs_timer", minutes + ":" + seconds);
        }

        if (shTimerStatus)
        {
            //keep timer going
            shTimer = Time.time - shStartTime;
        }

        if (!shTimerStatus)
        {
            shStartTime += Time.deltaTime;
            string minutes = ((int)shTimer / 60).ToString();
            string seconds = (shTimer % 60).ToString("f1");

            PlayerPrefs.SetString("sh_timer", minutes + ":" + seconds);
        }

        if (edkTimerStatus)
        {
            //keep timer going
            edkTimer = Time.time - edkStartTime;
        }

        if (!edkTimerStatus)
        {
            edkStartTime += Time.deltaTime;
            string minutes = ((int)edkTimer / 60).ToString();
            string seconds = (edkTimer % 60).ToString("f1");

            PlayerPrefs.SetString("edk_timer", minutes + ":" + seconds);
        }

        if (hadpTimerStatus)
        {
            //keep timer going
            hadpTimer = Time.time - hadpStartTime;
        }

        if (!hadpTimerStatus)
        {
            hadpStartTime += Time.deltaTime;
            string minutes = ((int)hadpTimer / 60).ToString();
            string seconds = (hadpTimer % 60).ToString("f1");

            PlayerPrefs.SetString("hadp_timer", minutes + ":" + seconds);
        }

        if (esqTimerStatus)
        {
            //keep timer going
            esqTimer = Time.time - esqStartTime;
        }

        if (!esqTimerStatus)
        {
            esqStartTime += Time.deltaTime;
            string minutes = ((int)esqTimer / 60).ToString();
            string seconds = (esqTimer % 60).ToString("f1");

            PlayerPrefs.SetString("esq_timer", minutes + ":" + seconds);
        }

        if (smbiTimerStatus)
        {
            //keep timer going
            smbiTimer = Time.time - smbiStartTime;
        }

        if (!smbiTimerStatus)
        {
            smbiStartTime += Time.deltaTime;
            string minutes = ((int)smbiTimer / 60).ToString();
            string seconds = (smbiTimer % 60).ToString("f1");

            PlayerPrefs.SetString("smbi_timer", minutes + ":" + seconds);
        }

        if (seTimerStatus)
        {
            //keep timer going
            seTimer = Time.time - seStartTime;
        }

        if (!seTimerStatus)
        {
            seStartTime += Time.deltaTime;
            string minutes = ((int)seTimer / 60).ToString();
            string seconds = (seTimer % 60).ToString("f1");

            PlayerPrefs.SetString("se_timer", minutes + ":" + seconds);
        }

        if (itbpTimerStatus)
        {
            //keep timer going
            itbpTimer = Time.time - itbpStartTime;
        }

        if (!itbpTimerStatus)
        {
            itbpStartTime += Time.deltaTime;
            string minutes = ((int)itbpTimer / 60).ToString();
            string seconds = (itbpTimer % 60).ToString("f1");

            PlayerPrefs.SetString("itbp_timer", minutes + ":" + seconds);
        }

        if (sesmTimerStatus)
        {
            //keep timer going
            sesmTimer = Time.time - sesmStartTime;
        }

        if (!sesmTimerStatus)
        {
            sesmStartTime += Time.deltaTime;
            string minutes = ((int)sesmTimer / 60).ToString();
            string seconds = (sesmTimer % 60).ToString("f1");

            PlayerPrefs.SetString("sesm_timer", minutes + ":" + seconds);
        }

        if (boTimerStatus)
        {
            //keep timer going
            boTimer = Time.time - boStartTime;
        }

        if (!boTimerStatus)
        {
            boStartTime += Time.deltaTime;
            string minutes = ((int)boTimer / 60).ToString();
            string seconds = (boTimer % 60).ToString("f1");

            PlayerPrefs.SetString("bo_timer", minutes + ":" + seconds);
        }

        if (spcTimerStatus)
        {
            //keep timer going
            spcTimer = Time.time - spcStartTime;
        }

        if (!spcTimerStatus)
        {
            spcStartTime += Time.deltaTime;
            string minutes = ((int)spcTimer / 60).ToString();
            string seconds = (spcTimer % 60).ToString("f1");

            PlayerPrefs.SetString("spc_timer", minutes + ":" + seconds);
        }

        if (agseTimerStatus)
        {
            //keep timer going
            agseTimer = Time.time - agseStartTime;
        }

        if (!agseTimerStatus)
        {
            agseStartTime += Time.deltaTime;
            string minutes = ((int)agseTimer / 60).ToString();
            string seconds = (agseTimer % 60).ToString("f1");

            PlayerPrefs.SetString("agse_timer", minutes + ":" + seconds);
        }

        if (epdoTimerStatus)
        {
            //keep timer going
            epdoTimer = Time.time - epdoStartTime;
        }

        if (!epdoTimerStatus)
        {
            epdoStartTime += Time.deltaTime;
            string minutes = ((int)epdoTimer / 60).ToString();
            string seconds = (epdoTimer % 60).ToString("f1");

            PlayerPrefs.SetString("epdo_timer", minutes + ":" + seconds);
        }

        if (nbiTimerStatus)
        {
            //keep timer going
            nbiTimer = Time.time - nbiStartTime;
        }

        if (!nbiTimerStatus)
        {
            nbiStartTime += Time.deltaTime;
            string minutes = ((int)nbiTimer / 60).ToString();
            string seconds = (nbiTimer % 60).ToString("f1");

            PlayerPrefs.SetString("nbi_timer", minutes + ":" + seconds);
        }
    }

    public void StartTimer()
    {
        //start the timer and set bool to true
        medTimerStatus = true;
        medStartTime = Time.time;
    }

    public void StartSMOTimer()
    {
        //start the timer for Skipping Meals and Obesity timer and set bool to true
        smoTimerStatus = true;
        smoStartTime = Time.time;
    }

    public void StartGRTimer()
    {
        //start the timer for Gender and Reward timer and set bool to true
        grTimerStatus = true;
        grStartTime = Time.time;
    }

    public void StartMSTimer()
    {
        //start the timer for Within Participants Meditation Stress timer and set bool to true
        msTimerStatus = true;
        msStartTime = Time.time;
    }

    public void StartMHSTimer()
    {
        //start the timer for MHS timer and set bool to true
        mhsTimerStatus = true;
        mhsStartTime = Time.time;
    }

    public void StartSHTimer()
    {
        //start the timer for SH timer and set bool to true
        shTimerStatus = true;
        shStartTime = Time.time;
    }

    public void StartEDKTimer()
    {
        //start the timer for EDK timer and set bool to true
        edkTimerStatus = true;
        edkStartTime = Time.time;
    }

    public void StartHADPTimer()
    {
        //start the timer for HADP timer and set bool to true
        hadpTimerStatus = true;
        hadpStartTime = Time.time;
    }

    public void StartESQTimer()
    {
        //start the timer for ESQ timer and set bool to true
        esqTimerStatus = true;
        esqStartTime = Time.time;
    }

    public void StartSMBITimer()
    {
        //start the timer for SMBI timer and set bool to true
        smbiTimerStatus = true;
        smbiStartTime = Time.time;
    }

    public void StartSETimer()
    {
        //start the timer for SE timer and set bool to true
        seTimerStatus = true;
        seStartTime = Time.time;
    }

    public void StartITBPTimer()
    {
        //start the timer for ITBP timer and set bool to true
        itbpTimerStatus = true;
        itbpStartTime = Time.time;
    }

    public void StartSESMTimer()
    {
        //start the timer for SESM timer and set bool to true
        sesmTimerStatus = true;
        sesmStartTime = Time.time;
    }

    public void StartBOTimer()
    {
        //start the timer for BO timer and set bool to true
        boTimerStatus = true;
        boStartTime = Time.time;
    }

    public void StartSPCTimer()
    {
        //start the timer for SPC timer and set bool to true
        spcTimerStatus = true;
        spcStartTime = Time.time;
    }

    public void StartAGSETimer()
    {
        //start the timer for AGSE timer and set bool to true
        agseTimerStatus = true;
        agseStartTime = Time.time;
    }

    public void StartEPDOTimer()
    {
        //start the timer for EPDO timer and set bool to true
        epdoTimerStatus = true;
        epdoStartTime = Time.time;
    }

    public void StartNBITimer()
    {
        //start the timer for NBI timer and set bool to true
        nbiTimerStatus = true;
        nbiStartTime = Time.time;
    }
}
