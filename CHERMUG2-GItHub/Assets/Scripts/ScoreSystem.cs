using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//////////////////////////////////////////////////<summary>//////////////////////////////////////////////////// 
///                                   University of the West of Scotland                                    ///
///                               -------------------------------------------                               ///  
/// Script is attached to the ScoreBar GameObject - child of the Bars GameObject Prefab - in each game scene///
///                                                                                                         ///
//////////////////////////////////////////////////</summary>///////////////////////////////////////////////////

public class ScoreSystem : MonoBehaviour
{
    public GameObject particleSpawner;
    //Nationalty and Mediterranean Foods score
    private int score;
    private Text scoreText;//prefab of scorebar has text field added
    private Text nameText;//prefab of namebar has text field added

    //Skipping Meals and Obesity score
    private int smoScore;
    private Text smoScoreText;

    //Gender and Reward score
    private int grScore;
    private Text grScoreText;

    //Meditation and Stress score
    private int msScore;
    private Text msScoreText;

    //Mental Health Support score
    private int mhsScore;
    private Text mhsScoreText;

    //Health Behaviour and Spirituality score
    private int shScore;
    private Text shScoreText;

    //Effects of different kinds of diet on weight loss (EDK) score
    private int edkScore;
    private Text edkScoreText;

    //Health anxiety during a pandemic (HADP) score
    private int hadpScore;
    private Text hadpScoreText;

    //ESQ score
    private int esqScore;
    private Text esqScoreText;

    //SMBI score
    private int smbiScore;
    private Text smbiScoreText;

    //SE score
    private int seScore;
    private Text seScoreText;

    //ITBP score
    private int itbpScore;
    private Text itbpScoreText;

    //SESM score
    private int sesmScore;
    private Text sesmScoreText;

    //BO score
    private int boScore;
    private Text boScoreText;

    //SPC score
    private int spcScore;
    private Text spcScoreText;

    //AGSE score
    private int agseScore;
    private Text agseScoreText;

    //EPDO score
    private int epdoScore;
    private Text epdoScoreText;

    //NBI score
    private int nbiScore;
    private Text nbiScoreText;

    public AudioSource audioSource;
    public AudioClip scoreIncrease;
    public AudioClip errorSound;
    public AudioClip[] soundClip;

    [SerializeField] private GameObject medText, smoText, grText, msText, mhsText, shText, edkText, hadpText, esqText, smbiText, seText, itbpText, sesmText, boText, spcText, agseText, epdoText, nbiText;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        soundClip[0] = scoreIncrease;
        soundClip[1] = errorSound;

        //NMF score text
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        //SMO score text
        smoScoreText = GameObject.Find("SMOScoreText").GetComponent<Text>();
        //GR score text
        grScoreText = GameObject.Find("GRScoreText").GetComponent<Text>();
        //MS score text
        msScoreText = GameObject.Find("MSScoreText").GetComponent<Text>();
        //MHS score text
        mhsScoreText = GameObject.Find("MHSScoreText").GetComponent<Text>();
        //SH score text
        shScoreText = GameObject.Find("SHScoreText").GetComponent<Text>();
        //EDK score text
        edkScoreText = GameObject.Find("EDKScoreText").GetComponent<Text>();
        //HADP score text
        hadpScoreText = GameObject.Find("HADPScoreText").GetComponent<Text>();
        //ESQ score text
        esqScoreText = GameObject.Find("ESQScoreText").GetComponent<Text>();
        //SMBI score text
        smbiScoreText = GameObject.Find("SMBIScoreText").GetComponent<Text>();
        //SE score text
        seScoreText = GameObject.Find("SEScoreText").GetComponent<Text>();
        //ITBP score text
        itbpScoreText = GameObject.Find("ITBPScoreText").GetComponent<Text>();
        //SESM score text
        sesmScoreText = GameObject.Find("SESMScoreText").GetComponent<Text>();
        //BO score text
        boScoreText = GameObject.Find("BOScoreText").GetComponent<Text>();
        //SPC score text
        spcScoreText = GameObject.Find("SPCScoreText").GetComponent<Text>();
        //AGSE score text
        agseScoreText = GameObject.Find("AGSEScoreText").GetComponent<Text>();
        //EPDO score text
        epdoScoreText = GameObject.Find("EPDOScoreText").GetComponent<Text>();
        //NBI score text
        nbiScoreText = GameObject.Find("NBIScoreText").GetComponent<Text>();


        //name text
        nameText = GameObject.Find("NameText").GetComponent<Text>();

        medText = GameObject.Find("ScoreText");
        smoText = GameObject.Find("SMOScoreText");
        grText = GameObject.Find("GRScoreText");
        msText = GameObject.Find("MSScoreText");
        mhsText = GameObject.Find("MHSScoreText");
        shText = GameObject.Find("SHScoreText");
        edkText = GameObject.Find("EDKScoreText");
        hadpText = GameObject.Find("HADPScoreText");
        esqText = GameObject.Find("ESQScoreText");
        smbiText = GameObject.Find("SMBIScoreText");
        seText = GameObject.Find("SEScoreText");
        itbpText = GameObject.Find("ITBPScoreText");
        sesmText = GameObject.Find("SESMScoreText");
        boText = GameObject.Find("BOScoreText");
        spcText = GameObject.Find("SPCScoreText");
        agseText = GameObject.Find("AGSEScoreText");
        epdoText = GameObject.Find("EPDOScoreText");
        nbiText = GameObject.Find("NBIScoreText");

        particleSpawner = GameObject.Find("ParticleSpawner");

        //NMF score
        score = PlayerPrefs.GetInt("score");
        scoreText.text = PlayerPrefs.GetString("scoreString");

        //SMO score
        smoScore = PlayerPrefs.GetInt("smo_score");
        smoScoreText.text = PlayerPrefs.GetString("smo_scoreString");

        //GR score
        grScore = PlayerPrefs.GetInt("gr_score");
        grScoreText.text = PlayerPrefs.GetString("gr_scoreString");

        //MS score
        msScore = PlayerPrefs.GetInt("ms_score");
        msScoreText.text = PlayerPrefs.GetString("ms_scoreString");

        //MHS score
        mhsScore = PlayerPrefs.GetInt("mhs_score");
        mhsScoreText.text = PlayerPrefs.GetString("mhs_scoreString");

        //SH score
        shScore = PlayerPrefs.GetInt("sh_score");
        shScoreText.text = PlayerPrefs.GetString("sh_scoreString");

        //EDK score
        edkScore = PlayerPrefs.GetInt("edk_score");
        edkScoreText.text = PlayerPrefs.GetString("edk_scoreString");

        //HADP score
        hadpScore = PlayerPrefs.GetInt("hadp_score");
        hadpScoreText.text = PlayerPrefs.GetString("hadp_scoreString");

        //ESQ score
        esqScore = PlayerPrefs.GetInt("esq_score");
        esqScoreText.text = PlayerPrefs.GetString("esq_scoreString");

        //SMBI score
        smbiScore = PlayerPrefs.GetInt("smbi_score");
        smbiScoreText.text = PlayerPrefs.GetString("smbi_scoreString");

        //SE score
        seScore = PlayerPrefs.GetInt("se_score");
        seScoreText.text = PlayerPrefs.GetString("se_scoreString");

        //ITBP score
        itbpScore = PlayerPrefs.GetInt("itbp_score");
        itbpScoreText.text = PlayerPrefs.GetString("itbp_scoreString");

        //SESM score
        sesmScore = PlayerPrefs.GetInt("sesm_score");
        sesmScoreText.text = PlayerPrefs.GetString("sesm_scoreString");

        //BO score
        boScore = PlayerPrefs.GetInt("bo_score");
        boScoreText.text = PlayerPrefs.GetString("bo_scoreString");

        //SPC score
        spcScore = PlayerPrefs.GetInt("spc_score");
        spcScoreText.text = PlayerPrefs.GetString("spc_scoreString");

        //AGSE score
        agseScore = PlayerPrefs.GetInt("agse_score");
        agseScoreText.text = PlayerPrefs.GetString("agse_scoreString");

        //EPDO score
        epdoScore = PlayerPrefs.GetInt("epdo_score");
        epdoScoreText.text = PlayerPrefs.GetString("epdo_scoreString");

        //NBI score
        nbiScore = PlayerPrefs.GetInt("nbi_score");
        nbiScoreText.text = PlayerPrefs.GetString("nbi_scoreString");

        nameText.text = PlayerPrefs.GetString("name");

        medText.SetActive(false);
        smoText.SetActive(false);
        grText.SetActive(false);
        msText.SetActive(false);
        mhsText.SetActive(false);
        shText.SetActive(false);
        edkText.SetActive(false);
        hadpText.SetActive(false);
        esqText.SetActive(false);
        smbiText.SetActive(false);
        seText.SetActive(false);
        itbpText.SetActive(false);
        sesmText.SetActive(false);
        boText.SetActive(false);
        spcText.SetActive(false);
        agseText.SetActive(false);
        epdoText.SetActive(false);
        nbiText.SetActive(false);
    }

    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "NMF_MultipleChoice" || scene.name == "NMF_MultipleChoice2" || scene.name == "NMF_Hangman" || scene.name == "NMF_NullHypothesis" ||
            scene.name == "NMF_QuestionsData" || scene.name == "NMF_QuestionsHM" || scene.name == "NMF_QuestionsHM2" || scene.name == "NMF_QuestionsTTT" ||
            scene.name == "NMF_QuestionsTTT2" || scene.name == "NMF_TicTacToe")
        {
            medText.SetActive(true);
            smoText.SetActive(false);
            grText.SetActive(false);
            msText.SetActive(false);
            mhsText.SetActive(false);
            shText.SetActive(false);
            edkText.SetActive(false);
            hadpText.SetActive(false);
            esqText.SetActive(false);
            smbiText.SetActive(false);
            seText.SetActive(false);
            itbpText.SetActive(false);
            sesmText.SetActive(false);
            boText.SetActive(false);
            spcText.SetActive(false);
            agseText.SetActive(false);
            epdoText.SetActive(false);
            nbiText.SetActive(false);
        }

        if (scene.name == "SMO_MultipleChoice" || scene.name == "SMO_MultipleChoice2" || scene.name == "SMO_Hangman" || scene.name == "SMO_NullHypothesis" ||
            scene.name == "SMO_QuestionsData" || scene.name == "SMO_QuestionsHM" || scene.name == "SMO_QuestionsHM2" || scene.name == "SMO_QuestionsTTT" ||
            scene.name == "SMO_TicTacToe" || scene.name == "SMO_AorB" || scene.name == "SMO_AorB2")
        {
            medText.SetActive(false);
            smoText.SetActive(true);
            grText.SetActive(false);
            msText.SetActive(false);
            mhsText.SetActive(false);
            shText.SetActive(false);
            edkText.SetActive(false);
            hadpText.SetActive(false);
            esqText.SetActive(false);
            smbiText.SetActive(false);
            seText.SetActive(false);
            itbpText.SetActive(false);
            sesmText.SetActive(false);
            boText.SetActive(false);
            spcText.SetActive(false);
            agseText.SetActive(false);
            epdoText.SetActive(false);
            nbiText.SetActive(false);
        }

        if (scene.name == "GR_MultipleChoice" || scene.name == "GR_MultipleChoice2" || scene.name == "GR_Hangman" || scene.name == "GR_NullHypothesis" ||
            scene.name == "GR_QuestionsData" || scene.name == "GR_QuestionsHM" || scene.name == "GR_QuestionsHM2" || scene.name == "GR_QuestionsTTT" ||
            scene.name == "GR_QuestionsTTT2" || scene.name == "GR_TicTacToe")
        {
            medText.SetActive(false);
            smoText.SetActive(false);
            grText.SetActive(true);
            msText.SetActive(false);
            mhsText.SetActive(false);
            shText.SetActive(false);
            edkText.SetActive(false);
            hadpText.SetActive(false);
            esqText.SetActive(false);
            smbiText.SetActive(false);
            seText.SetActive(false);
            itbpText.SetActive(false);
            sesmText.SetActive(false);
            boText.SetActive(false);
            spcText.SetActive(false);
            agseText.SetActive(false);
            epdoText.SetActive(false);
            nbiText.SetActive(false);
        }

        if (scene.name == "MS_MultipleChoice" || scene.name == "MS_MultipleChoice2" || scene.name == "MS_Hangman" || scene.name == "MS_NullHypothesis" ||
            scene.name == "MS_QuestionsData" || scene.name == "MS_QuestionsHM" || scene.name == "MS_QuestionsHM2" || scene.name == "MS_TicTacToe" ||
            scene.name == "MS_QuestionsTTT")
        {
            medText.SetActive(false);
            smoText.SetActive(false);
            grText.SetActive(false);
            msText.SetActive(true);
            mhsText.SetActive(false);
            shText.SetActive(false);
            edkText.SetActive(false);
            hadpText.SetActive(false);
            esqText.SetActive(false);
            smbiText.SetActive(false);
            seText.SetActive(false);
            itbpText.SetActive(false);
            sesmText.SetActive(false);
            boText.SetActive(false);
            spcText.SetActive(false);
            agseText.SetActive(false);
            epdoText.SetActive(false);
            nbiText.SetActive(false);
        }

        if (scene.name == "MHS_MultipleChoice" || scene.name == "MHS_Hangman" || scene.name == "MHS_NullHypothesis" ||
            scene.name == "MHS_QuestionsData" || scene.name == "MHS_QuestionsHM" || scene.name == "MHS_QuestionsHM2" || scene.name == "MHS_TicTacToe" ||
            scene.name == "MHS_QuestionsTTT")
        {
            medText.SetActive(false);
            smoText.SetActive(false);
            grText.SetActive(false);
            msText.SetActive(false);
            mhsText.SetActive(true);
            shText.SetActive(false);
            edkText.SetActive(false);
            hadpText.SetActive(false);
            esqText.SetActive(false);
            smbiText.SetActive(false);
            seText.SetActive(false);
            itbpText.SetActive(false);
            sesmText.SetActive(false);
            boText.SetActive(false);
            spcText.SetActive(false);
            agseText.SetActive(false);
            epdoText.SetActive(false);
            nbiText.SetActive(false);
        }

        if (scene.name == "SH_MultipleChoice" || scene.name == "SH_Hangman" || scene.name == "SH_NullHypothesis" || scene.name == "SH_NullHypothesis2" ||
            scene.name == "SH_QuestionsData" || scene.name == "SH_QuestionsData2" || scene.name == "SH_QuestionsHM" || scene.name == "SH_QuestionsHM2" || 
            scene.name == "SH_TicTacToe" || scene.name == "SH_QuestionsTTT")
        {
            medText.SetActive(false);
            smoText.SetActive(false);
            grText.SetActive(false);
            msText.SetActive(false);
            mhsText.SetActive(false);
            shText.SetActive(true);
            edkText.SetActive(false);
            hadpText.SetActive(false);
            esqText.SetActive(false);
            smbiText.SetActive(false);
            seText.SetActive(false);
            itbpText.SetActive(false);
            sesmText.SetActive(false);
            boText.SetActive(false);
            spcText.SetActive(false);
            agseText.SetActive(false);
            epdoText.SetActive(false);
            nbiText.SetActive(false);
        }

        if (scene.name == "EDK_MultipleChoice" || scene.name == "EDK_Hangman" || scene.name == "EDK_QuestionsHM" || scene.name == "EDK_MultipleChoice2" ||
            scene.name == "EDK_QuestionsHM2" || scene.name == "EDK_NullHypothesis" || scene.name == "EDK_NullHypothesis2" || scene.name == "EDK_QuestionsData" ||
            scene.name == "EDK_TicTacToe" || scene.name == "EDK_QuestionsTTT")
        {
            medText.SetActive(false);
            smoText.SetActive(false);
            grText.SetActive(false);
            msText.SetActive(false);
            mhsText.SetActive(false);
            shText.SetActive(false);
            edkText.SetActive(true);
            hadpText.SetActive(false);
            esqText.SetActive(false);
            smbiText.SetActive(false);
            seText.SetActive(false);
            itbpText.SetActive(false);
            sesmText.SetActive(false);
            boText.SetActive(false);
            spcText.SetActive(false);
            agseText.SetActive(false);
            epdoText.SetActive(false);
            nbiText.SetActive(false);
        }

        if (scene.name == "HADP_MultipleChoice" || scene.name == "HADP_Hangman" || scene.name == "HADP_QuestionsHM" || scene.name == "HADP_MultipleChoice2" ||
            scene.name == "HADP_QuestionsHM2" || scene.name == "HADP_NullHypothesis" || scene.name == "HADP_QuestionsData" || scene.name == "HADP_TicTacToe" || 
            scene.name == "HADP_QuestionsTTT")
        {
            medText.SetActive(false);
            smoText.SetActive(false);
            grText.SetActive(false);
            msText.SetActive(false);
            mhsText.SetActive(false);
            shText.SetActive(false);
            edkText.SetActive(false);
            hadpText.SetActive(true);
            esqText.SetActive(false);
            smbiText.SetActive(false);
            seText.SetActive(false);
            itbpText.SetActive(false);
            sesmText.SetActive(false);
            boText.SetActive(false);
            spcText.SetActive(false);
            agseText.SetActive(false);
            epdoText.SetActive(false);
            nbiText.SetActive(false);
        }

        if (scene.name == "ESQ_MultipleChoice" || scene.name == "ESQ_Hangman" || scene.name == "ESQ_QuestionsHM" || scene.name == "ESQ_MultipleChoice2" ||
            scene.name == "ESQ_QuestionsHM2" || scene.name == "ESQ_NullHypothesis" || scene.name == "ESQ_QuestionsData" || scene.name == "ESQ_TicTacToe" ||
            scene.name == "ESQ_QuestionsTTT")
        {
            medText.SetActive(false);
            smoText.SetActive(false);
            grText.SetActive(false);
            msText.SetActive(false);
            mhsText.SetActive(false);
            shText.SetActive(false);
            edkText.SetActive(false);
            hadpText.SetActive(false);
            esqText.SetActive(true);
            smbiText.SetActive(false);
            seText.SetActive(false);
            itbpText.SetActive(false);
            sesmText.SetActive(false);
            boText.SetActive(false);
            spcText.SetActive(false);
            agseText.SetActive(false);
            epdoText.SetActive(false);
            nbiText.SetActive(false);
        }

        if (scene.name == "SMBI_MultipleChoice" || scene.name == "SMBI_Hangman" || scene.name == "SMBI_QuestionsHM" || scene.name == "SMBI_MultipleChoice2" ||
            scene.name == "SMBI_QuestionsHM2" || scene.name == "SMBI_NullHypothesis" || scene.name == "SMBI_QuestionsData" || scene.name == "SMBI_TicTacToe" ||
            scene.name == "SMBI_QuestionsTTT")
        {
            medText.SetActive(false);
            smoText.SetActive(false);
            grText.SetActive(false);
            msText.SetActive(false);
            mhsText.SetActive(false);
            shText.SetActive(false);
            edkText.SetActive(false);
            hadpText.SetActive(false);
            esqText.SetActive(false);
            smbiText.SetActive(true);
            seText.SetActive(false);
            itbpText.SetActive(false);
            sesmText.SetActive(false);
            boText.SetActive(false);
            spcText.SetActive(false);
            agseText.SetActive(false);
            epdoText.SetActive(false);
            nbiText.SetActive(false);
        }

        if (scene.name == "SE_MultipleChoice" || scene.name == "SE_Hangman" || scene.name == "SE_QuestionsHM" ||
            scene.name == "SE_NullHypothesis" || scene.name == "SE_NullHypothesis2" || scene.name == "SE_QuestionsData" || scene.name == "SE_TicTacToe" ||
            scene.name == "SE_QuestionsTTT")
        {
            medText.SetActive(false);
            smoText.SetActive(false);
            grText.SetActive(false);
            msText.SetActive(false);
            mhsText.SetActive(false);
            shText.SetActive(false);
            edkText.SetActive(false);
            hadpText.SetActive(false);
            esqText.SetActive(false);
            smbiText.SetActive(false);
            seText.SetActive(true);
            itbpText.SetActive(false);
            sesmText.SetActive(false);
            boText.SetActive(false);
            spcText.SetActive(false);
            agseText.SetActive(false);
            epdoText.SetActive(false);
            nbiText.SetActive(false);
        }

        if (scene.name == "ITBP_MultipleChoice" || scene.name == "ITBP_Hangman" || scene.name == "ITBP_QuestionsHM" || scene.name == "ITBP_QuestionsHM2" ||
            scene.name == "ITBP_MultipleChoice2" || scene.name == "ITBP_QuestionsHM3" || scene.name == "ITBP_NullHypothesis" || scene.name == "ITBP_NullHypothesis2" || 
            scene.name == "ITBP_NullHypothesis3" || scene.name == "ITBP_QuestionsData" || scene.name == "ITBP_TicTacToe" || scene.name == "ITBP_QuestionsTTT")
        {
            medText.SetActive(false);
            smoText.SetActive(false);
            grText.SetActive(false);
            msText.SetActive(false);
            mhsText.SetActive(false);
            shText.SetActive(false);
            edkText.SetActive(false);
            hadpText.SetActive(false);
            esqText.SetActive(false);
            smbiText.SetActive(false);
            seText.SetActive(false);
            itbpText.SetActive(true);
            sesmText.SetActive(false);
            boText.SetActive(false);
            spcText.SetActive(false);
            agseText.SetActive(false);
            epdoText.SetActive(false);
            nbiText.SetActive(false);
        }

        if (scene.name == "SESM_MultipleChoice" || scene.name == "SESM_Hangman" || scene.name == "SESM_QuestionsHM" ||
            scene.name == "SESM_NullHypothesis" || scene.name == "SESM_QuestionsData" || scene.name == "SESM_TicTacToe" || scene.name == "SESM_QuestionsTTT")
        {
            medText.SetActive(false);
            smoText.SetActive(false);
            grText.SetActive(false);
            msText.SetActive(false);
            mhsText.SetActive(false);
            shText.SetActive(false);
            edkText.SetActive(false);
            hadpText.SetActive(false);
            esqText.SetActive(false);
            smbiText.SetActive(false);
            seText.SetActive(false);
            itbpText.SetActive(false);
            sesmText.SetActive(true);
            boText.SetActive(false);
            spcText.SetActive(false);
            agseText.SetActive(false);
            epdoText.SetActive(false);
            nbiText.SetActive(false);
        }

        if (scene.name == "BO_MultipleChoice" || scene.name == "BO_Hangman" || scene.name == "BO_QuestionsHM" || scene.name == "BO_QuestionsHM2" ||
            scene.name == "BO_NullHypothesis" || scene.name == "BO_QuestionsData" || scene.name == "BO_TicTacToe" || scene.name == "BO_QuestionsTTT")
        {
            medText.SetActive(false);
            smoText.SetActive(false);
            grText.SetActive(false);
            msText.SetActive(false);
            mhsText.SetActive(false);
            shText.SetActive(false);
            edkText.SetActive(false);
            hadpText.SetActive(false);
            esqText.SetActive(false);
            smbiText.SetActive(false);
            seText.SetActive(false);
            itbpText.SetActive(false);
            sesmText.SetActive(false);
            boText.SetActive(true);
            spcText.SetActive(false);
            agseText.SetActive(false);
            epdoText.SetActive(false);
            nbiText.SetActive(false);
        }

        if (scene.name == "SPC_MultipleChoice" || scene.name == "SPC_Hangman" || scene.name == "SPC_QuestionsHM" || scene.name == "SPC_MultipleChoice2" || scene.name == "SPC_QuestionsHM2" ||
            scene.name == "SPC_NullHypothesis" || scene.name == "SPC_QuestionsData" || scene.name == "SPC_TicTacToe" || scene.name == "SPC_QuestionsTTT")
        {
            medText.SetActive(false);
            smoText.SetActive(false);
            grText.SetActive(false);
            msText.SetActive(false);
            mhsText.SetActive(false);
            shText.SetActive(false);
            edkText.SetActive(false);
            hadpText.SetActive(false);
            esqText.SetActive(false);
            smbiText.SetActive(false);
            seText.SetActive(false);
            itbpText.SetActive(false);
            sesmText.SetActive(false);
            boText.SetActive(false);
            spcText.SetActive(true);
            agseText.SetActive(false);
            epdoText.SetActive(false);
            nbiText.SetActive(false);
        }

        if (scene.name == "AGSE_MultipleChoice" || scene.name == "AGSE_Hangman" || scene.name == "AGSE_QuestionsHM" || scene.name == "AGSE_MultipleChoice2" || scene.name == "AGSE_QuestionsHM2" ||
            scene.name == "AGSE_QuestionsHM3" || scene.name == "AGSE_NullHypothesis" || scene.name == "AGSE_NullHypothesis2" || scene.name == "AGSE_NullHypothesis3" ||
            scene.name == "AGSE_QuestionsData" || scene.name == "AGSE_TicTacToe" || scene.name == "AGSE_QuestionsTTT")
        {
            medText.SetActive(false);
            smoText.SetActive(false);
            grText.SetActive(false);
            msText.SetActive(false);
            mhsText.SetActive(false);
            shText.SetActive(false);
            edkText.SetActive(false);
            hadpText.SetActive(false);
            esqText.SetActive(false);
            smbiText.SetActive(false);
            seText.SetActive(false);
            itbpText.SetActive(false);
            sesmText.SetActive(false);
            boText.SetActive(false);
            spcText.SetActive(false);
            agseText.SetActive(true);
            epdoText.SetActive(false);
            nbiText.SetActive(false);
        }

        if (scene.name == "EPDO_MultipleChoice" || scene.name == "EPDO_Hangman" || scene.name == "EPDO_QuestionsHM" ||
            scene.name == "EPDO_NullHypothesis" || scene.name == "EPDO_QuestionsData" || scene.name == "EPDO_TicTacToe" || scene.name == "EPDO_QuestionsTTT")
        {
            medText.SetActive(false);
            smoText.SetActive(false);
            grText.SetActive(false);
            msText.SetActive(false);
            mhsText.SetActive(false);
            shText.SetActive(false);
            edkText.SetActive(false);
            hadpText.SetActive(false);
            esqText.SetActive(false);
            smbiText.SetActive(false);
            seText.SetActive(false);
            itbpText.SetActive(false);
            sesmText.SetActive(false);
            boText.SetActive(false);
            spcText.SetActive(false);
            agseText.SetActive(false);
            epdoText.SetActive(true);
            nbiText.SetActive(false);
        }

        if (scene.name == "NBI_MultipleChoice" || scene.name == "NBI_Hangman" || scene.name == "NBI_QuestionsHM" || scene.name == "NBI_NullHypothesis" ||
            scene.name == "NBI_NullHypothesis2" || scene.name == "NBI_QuestionsData" || scene.name == "NBI_TicTacToe" || scene.name == "NBI_QuestionsTTT")
        {
            medText.SetActive(false);
            smoText.SetActive(false);
            grText.SetActive(false);
            msText.SetActive(false);
            mhsText.SetActive(false);
            shText.SetActive(false);
            edkText.SetActive(false);
            hadpText.SetActive(false);
            esqText.SetActive(false);
            smbiText.SetActive(false);
            seText.SetActive(false);
            itbpText.SetActive(false);
            sesmText.SetActive(false);
            boText.SetActive(false);
            spcText.SetActive(false);
            agseText.SetActive(false);
            epdoText.SetActive(false);
            nbiText.SetActive(true);
        }

        //NMF score
        if (score < 0)
        {
            score = PlayerPrefs.GetInt("score");
            score = 0;
            PlayerPrefs.SetInt("score", score);
            scoreText.text = score.ToString();
            PlayerPrefs.SetString("scoreString", scoreText.text);
            PlayerPrefs.Save();
        }
        //SMO score
        if (smoScore < 0)
        {
            smoScore = PlayerPrefs.GetInt("smo_score");
            smoScore = 0;
            PlayerPrefs.SetInt("smo_score", smoScore);
            smoScoreText.text = smoScore.ToString();
            PlayerPrefs.SetString("smo_scoreString", smoScoreText.text);
            PlayerPrefs.Save();
        }
        //GR score
        if (grScore < 0)
        {
            grScore = PlayerPrefs.GetInt("gr_score");
            grScore = 0;
            PlayerPrefs.SetInt("gr_score", grScore);
            grScoreText.text = grScore.ToString();
            PlayerPrefs.SetString("gr_scoreString", grScoreText.text);
            PlayerPrefs.Save();
        }
        //MS score
        if (msScore < 0)
        {
            msScore = PlayerPrefs.GetInt("ms_score");
            msScore = 0;
            PlayerPrefs.SetInt("ms_score", msScore);
            msScoreText.text = msScore.ToString();
            PlayerPrefs.SetString("ms_scoreString", msScoreText.text);
            PlayerPrefs.Save();
        }
        //MHS score
        if (mhsScore < 0)
        {
            mhsScore = PlayerPrefs.GetInt("mhs_score");
            mhsScore = 0;
            PlayerPrefs.SetInt("mhs_score", mhsScore);
            mhsScoreText.text = mhsScore.ToString();
            PlayerPrefs.SetString("mhs_scoreString", mhsScoreText.text);
            PlayerPrefs.Save();
        }
        //SH score
        if (shScore < 0)
        {
            shScore = PlayerPrefs.GetInt("sh_score");
            shScore = 0;
            PlayerPrefs.SetInt("sh_score", shScore);
            shScoreText.text = shScore.ToString();
            PlayerPrefs.SetString("sh_scoreString", shScoreText.text);
            PlayerPrefs.Save();
        }
        //EDK score
        if (edkScore < 0)
        {
            edkScore = PlayerPrefs.GetInt("edk_score");
            edkScore = 0;
            PlayerPrefs.SetInt("edk_score", edkScore);
            edkScoreText.text = edkScore.ToString();
            PlayerPrefs.SetString("edk_scoreString", edkScoreText.text);
            PlayerPrefs.Save();
        }
        //HADP score
        if (hadpScore < 0)
        {
            hadpScore = PlayerPrefs.GetInt("hadp_score");
            hadpScore = 0;
            PlayerPrefs.SetInt("hadp_score", hadpScore);
            hadpScoreText.text = hadpScore.ToString();
            PlayerPrefs.SetString("hadp_scoreString", hadpScoreText.text);
            PlayerPrefs.Save();
        }
        //ESQ score
        if (esqScore < 0)
        {
            esqScore = PlayerPrefs.GetInt("esq_score");
            esqScore = 0;
            PlayerPrefs.SetInt("esq_score", esqScore);
            esqScoreText.text = esqScore.ToString();
            PlayerPrefs.SetString("esq_scoreString", esqScoreText.text);
            PlayerPrefs.Save();
        }
        //SMBI score
        if (smbiScore < 0)
        {
            smbiScore = PlayerPrefs.GetInt("smbi_score");
            smbiScore = 0;
            PlayerPrefs.SetInt("smbi_score", smbiScore);
            smbiScoreText.text = smbiScore.ToString();
            PlayerPrefs.SetString("smbi_scoreString", smbiScoreText.text);
            PlayerPrefs.Save();
        }
        //SE score
        if (seScore < 0)
        {
            seScore = PlayerPrefs.GetInt("se_score");
            seScore = 0;
            PlayerPrefs.SetInt("se_score", seScore);
            seScoreText.text = seScore.ToString();
            PlayerPrefs.SetString("se_scoreString", seScoreText.text);
            PlayerPrefs.Save();
        }
        //ITBP score
        if (itbpScore < 0)
        {
            itbpScore = PlayerPrefs.GetInt("itbp_score");
            itbpScore = 0;
            PlayerPrefs.SetInt("itbp_score", itbpScore);
            itbpScoreText.text = itbpScore.ToString();
            PlayerPrefs.SetString("itbp_scoreString", itbpScoreText.text);
            PlayerPrefs.Save();
        }
        //SESM score
        if (sesmScore < 0)
        {
            sesmScore = PlayerPrefs.GetInt("sesm_score");
            sesmScore = 0;
            PlayerPrefs.SetInt("sesm_score", sesmScore);
            sesmScoreText.text = sesmScore.ToString();
            PlayerPrefs.SetString("sesm_scoreString", sesmScoreText.text);
            PlayerPrefs.Save();
        }
        //BO score
        if (boScore < 0)
        {
            boScore = PlayerPrefs.GetInt("bo_score");
            boScore = 0;
            PlayerPrefs.SetInt("bo_score", boScore);
            boScoreText.text = boScore.ToString();
            PlayerPrefs.SetString("bo_scoreString", boScoreText.text);
            PlayerPrefs.Save();
        }
        //SPC score
        if (spcScore < 0)
        {
            spcScore = PlayerPrefs.GetInt("spc_score");
            spcScore = 0;
            PlayerPrefs.SetInt("spc_score", spcScore);
            spcScoreText.text = spcScore.ToString();
            PlayerPrefs.SetString("spc_scoreString", spcScoreText.text);
            PlayerPrefs.Save();
        }
        //AGSE score
        if (agseScore < 0)
        {
            agseScore = PlayerPrefs.GetInt("agse_score");
            agseScore = 0;
            PlayerPrefs.SetInt("agse_score", agseScore);
            agseScoreText.text = agseScore.ToString();
            PlayerPrefs.SetString("agse_scoreString", agseScoreText.text);
            PlayerPrefs.Save();
        }
        //EPDO score
        if (epdoScore < 0)
        {
            epdoScore = PlayerPrefs.GetInt("epdo_score");
            epdoScore = 0;
            PlayerPrefs.SetInt("epdo_score", epdoScore);
            epdoScoreText.text = epdoScore.ToString();
            PlayerPrefs.SetString("epdo_scoreString", epdoScoreText.text);
            PlayerPrefs.Save();
        }
        //NBI score
        if (nbiScore < 0)
        {
            nbiScore = PlayerPrefs.GetInt("nbi_score");
            nbiScore = 0;
            PlayerPrefs.SetInt("nbi_score", nbiScore);
            nbiScoreText.text = nbiScore.ToString();
            PlayerPrefs.SetString("nbi_scoreString", nbiScoreText.text);
            PlayerPrefs.Save();
        }
    }

    //------------- NMF Score Functions -------------------------
    public void SetScore()
    {
        score = PlayerPrefs.GetInt("score");
        score = 0;
        PlayerPrefs.SetInt("score", score);
        scoreText.text = score.ToString();
        PlayerPrefs.SetString("scoreString", scoreText.text);
        PlayerPrefs.Save();
    }

    public void AddScore()
    {
        score = PlayerPrefs.GetInt("score");
        score += 100;

        audioSource.clip = soundClip[0];
        audioSource.Play();

        PlayerPrefs.SetInt("score", score);
        scoreText.text = score.ToString();
        PlayerPrefs.SetString("scoreString", scoreText.text);
        PlayerPrefs.Save();
        particleSpawner.GetComponent<ScoreParticles>().ActivateParticles();
    }

    public void AddTicTacToeScore()
    {
        score = PlayerPrefs.GetInt("score");
        score += 300;

        audioSource.clip = soundClip[0];
        audioSource.Play();

        PlayerPrefs.SetInt("score", score);
        scoreText.text = score.ToString();
        PlayerPrefs.SetString("scoreString", scoreText.text);
        PlayerPrefs.Save();
        particleSpawner.GetComponent<ScoreParticles>().ActivateParticles();
    }

    public void RemoveScore()
    {
        score = PlayerPrefs.GetInt("score");
        score -= 50;

        audioSource.clip = soundClip[1];
        audioSource.Play();

        PlayerPrefs.SetInt("score", score);
        scoreText.text = score.ToString();
        PlayerPrefs.SetString("scoreString", scoreText.text);
        PlayerPrefs.Save();
    }
    //--------------------------------------------------------------------

    //SMO functions
    public void SetSMOScore()
    {
        smoScore = PlayerPrefs.GetInt("smo_score");
        smoScore = 0;
        PlayerPrefs.SetInt("smo_score", smoScore);
        smoScoreText.text = smoScore.ToString();
        PlayerPrefs.SetString("smo_scoreString", smoScoreText.text);
        PlayerPrefs.Save();
    }

    public void AddSMOScore()
    {
        smoScore = PlayerPrefs.GetInt("smo_score");
        smoScore += 100;

        audioSource.clip = soundClip[0];
        audioSource.Play();

        PlayerPrefs.SetInt("smo_score", smoScore);
        smoScoreText.text = smoScore.ToString();
        PlayerPrefs.SetString("smo_scoreString", smoScoreText.text);
        PlayerPrefs.Save();
        particleSpawner.GetComponent<ScoreParticles>().ActivateParticles();
    }

    public void AddSMOTicTacToeScore()
    {
        smoScore = PlayerPrefs.GetInt("smo_score");
        smoScore += 300;

        audioSource.clip = soundClip[0];
        audioSource.Play();

        PlayerPrefs.SetInt("smo_score", smoScore);
        smoScoreText.text = smoScore.ToString();
        PlayerPrefs.SetString("smo_scoreString", smoScoreText.text);
        PlayerPrefs.Save();
        particleSpawner.GetComponent<ScoreParticles>().ActivateParticles();
    }

    public void RemoveSMOScore()
    {
        smoScore = PlayerPrefs.GetInt("smo_score");
        smoScore -= 50;

        audioSource.clip = soundClip[1];
        audioSource.Play();

        PlayerPrefs.SetInt("smo_score", smoScore);
        smoScoreText.text = smoScore.ToString();
        PlayerPrefs.SetString("smo_scoreString", smoScoreText.text);
        PlayerPrefs.Save();
    }
    //-----------------------------------------------------------------------

    //GR functions
    public void SetGRScore()
    {
        grScore = PlayerPrefs.GetInt("gr_score");
        grScore = 0;
        PlayerPrefs.SetInt("gr_score", grScore);
        grScoreText.text = grScore.ToString();
        PlayerPrefs.SetString("gr_scoreString", grScoreText.text);
        PlayerPrefs.Save();
    }

    public void AddGRScore()
    {
        grScore = PlayerPrefs.GetInt("gr_score");
        grScore += 100;

        audioSource.clip = soundClip[0];
        audioSource.Play();

        PlayerPrefs.SetInt("gr_score", grScore);
        grScoreText.text = grScore.ToString();
        PlayerPrefs.SetString("gr_scoreString", grScoreText.text);
        PlayerPrefs.Save();
        particleSpawner.GetComponent<ScoreParticles>().ActivateParticles();
    }

    public void AddGRTicTacToeScore()
    {
        grScore = PlayerPrefs.GetInt("gr_score");
        grScore += 300;

        audioSource.clip = soundClip[0];
        audioSource.Play();

        PlayerPrefs.SetInt("gr_score", grScore);
        grScoreText.text = grScore.ToString();
        PlayerPrefs.SetString("gr_scoreString", grScoreText.text);
        PlayerPrefs.Save();
        particleSpawner.GetComponent<ScoreParticles>().ActivateParticles();
    }

    public void RemoveGRScore()
    {
        grScore = PlayerPrefs.GetInt("gr_score");
        grScore -= 50;

        audioSource.clip = soundClip[1];
        audioSource.Play();

        PlayerPrefs.SetInt("gr_score", grScore);
        grScoreText.text = grScore.ToString();
        PlayerPrefs.SetString("gr_scoreString", grScoreText.text);
        PlayerPrefs.Save();
    }
    //-----------------------------------------------------------------------

    //MS functions
    public void SetMSScore()
    {
        msScore = PlayerPrefs.GetInt("ms_score");
        msScore = 0;
        PlayerPrefs.SetInt("ms_score", msScore);
        msScoreText.text = msScore.ToString();
        PlayerPrefs.SetString("ms_scoreString", msScoreText.text);
        PlayerPrefs.Save();
    }

    public void AddMSScore()
    {
        msScore = PlayerPrefs.GetInt("ms_score");
        msScore += 100;

        audioSource.clip = soundClip[0];
        audioSource.Play();

        PlayerPrefs.SetInt("ms_score", msScore);
        msScoreText.text = msScore.ToString();
        PlayerPrefs.SetString("ms_scoreString", msScoreText.text);
        PlayerPrefs.Save();
        particleSpawner.GetComponent<ScoreParticles>().ActivateParticles();
    }

    public void AddMSTicTacToeScore()
    {
        msScore = PlayerPrefs.GetInt("ms_score");
        msScore += 300;

        audioSource.clip = soundClip[0];
        audioSource.Play();

        PlayerPrefs.SetInt("ms_score", msScore);
        msScoreText.text = msScore.ToString();
        PlayerPrefs.SetString("ms_scoreString", msScoreText.text);
        PlayerPrefs.Save();
        particleSpawner.GetComponent<ScoreParticles>().ActivateParticles();
    }

    public void RemoveMSScore()
    {
        msScore = PlayerPrefs.GetInt("ms_score");
        msScore -= 50;

        audioSource.clip = soundClip[1];
        audioSource.Play();

        PlayerPrefs.SetInt("ms_score", msScore);
        msScoreText.text = msScore.ToString();
        PlayerPrefs.SetString("ms_scoreString", msScoreText.text);
        PlayerPrefs.Save();
    }
    //-----------------------------------------------------------------------

    //MHS functions
    public void SetMHSScore()
    {
        mhsScore = PlayerPrefs.GetInt("mhs_score");
        mhsScore = 0;
        PlayerPrefs.SetInt("mhs_score", mhsScore);
        mhsScoreText.text = mhsScore.ToString();
        PlayerPrefs.SetString("mhs_scoreString", mhsScoreText.text);
        PlayerPrefs.Save();
    }

    public void AddMHSScore()
    {
        mhsScore = PlayerPrefs.GetInt("mhs_score");
        mhsScore += 100;

        audioSource.clip = soundClip[0];
        audioSource.Play();

        PlayerPrefs.SetInt("mhs_score", mhsScore);
        mhsScoreText.text = mhsScore.ToString();
        PlayerPrefs.SetString("mhs_scoreString", mhsScoreText.text);
        PlayerPrefs.Save();
        particleSpawner.GetComponent<ScoreParticles>().ActivateParticles();
    }

    public void AddMHSTicTacToeScore()
    {
        mhsScore = PlayerPrefs.GetInt("mhs_score");
        mhsScore += 300;

        audioSource.clip = soundClip[0];
        audioSource.Play();

        PlayerPrefs.SetInt("mhs_score", mhsScore);
        mhsScoreText.text = mhsScore.ToString();
        PlayerPrefs.SetString("mhs_scoreString", mhsScoreText.text);
        PlayerPrefs.Save();
        particleSpawner.GetComponent<ScoreParticles>().ActivateParticles();
    }

    public void RemoveMHSScore()
    {
        mhsScore = PlayerPrefs.GetInt("mhs_score");
        mhsScore -= 50;

        audioSource.clip = soundClip[1];
        audioSource.Play();

        PlayerPrefs.SetInt("mhs_score", mhsScore);
        mhsScoreText.text = mhsScore.ToString();
        PlayerPrefs.SetString("mhs_scoreString", mhsScoreText.text);
        PlayerPrefs.Save();
    }
    //-----------------------------------------------------------------------

    //SH functions
    public void SetSHScore()
    {
        shScore = PlayerPrefs.GetInt("sh_score");
        shScore = 0;
        PlayerPrefs.SetInt("sh_score", shScore);
        shScoreText.text = shScore.ToString();
        PlayerPrefs.SetString("sh_scoreString", shScoreText.text);
        PlayerPrefs.Save();
    }

    public void AddSHScore()
    {
        shScore = PlayerPrefs.GetInt("sh_score");
        shScore += 100;

        audioSource.clip = soundClip[0];
        audioSource.Play();

        PlayerPrefs.SetInt("sh_score", shScore);
        shScoreText.text = shScore.ToString();
        PlayerPrefs.SetString("sh_scoreString", shScoreText.text);
        PlayerPrefs.Save();
        particleSpawner.GetComponent<ScoreParticles>().ActivateParticles();
    }

    public void AddSHTicTacToeScore()
    {
        shScore = PlayerPrefs.GetInt("sh_score");
        shScore += 300;

        audioSource.clip = soundClip[0];
        audioSource.Play();

        PlayerPrefs.SetInt("sh_score", shScore);
        shScoreText.text = shScore.ToString();
        PlayerPrefs.SetString("sh_scoreString", shScoreText.text);
        PlayerPrefs.Save();
        particleSpawner.GetComponent<ScoreParticles>().ActivateParticles();
    }

    public void RemoveSHScore()
    {
        shScore = PlayerPrefs.GetInt("sh_score");
        shScore -= 50;

        audioSource.clip = soundClip[1];
        audioSource.Play();

        PlayerPrefs.SetInt("sh_score", shScore);
        shScoreText.text = shScore.ToString();
        PlayerPrefs.SetString("sh_scoreString", shScoreText.text);
        PlayerPrefs.Save();
    }
    //-----------------------------------------------------------------------

    //EDK functions
    public void SetEDKScore()
    {
        edkScore = PlayerPrefs.GetInt("edk_score");
        edkScore = 0;
        PlayerPrefs.SetInt("edk_score", edkScore);
        edkScoreText.text = edkScore.ToString();
        PlayerPrefs.SetString("edk_scoreString", edkScoreText.text);
        PlayerPrefs.Save();
    }

    public void AddEDKScore()
    {
        edkScore = PlayerPrefs.GetInt("edk_score");
        edkScore += 100;

        audioSource.clip = soundClip[0];
        audioSource.Play();

        PlayerPrefs.SetInt("edk_score", edkScore);
        edkScoreText.text = edkScore.ToString();
        PlayerPrefs.SetString("edk_scoreString", edkScoreText.text);
        PlayerPrefs.Save();
        particleSpawner.GetComponent<ScoreParticles>().ActivateParticles();
    }

    public void AddEDKTicTacToeScore()
    {
        edkScore = PlayerPrefs.GetInt("edk_score");
        edkScore += 300;

        audioSource.clip = soundClip[0];
        audioSource.Play();

        PlayerPrefs.SetInt("edk_score", edkScore);
        edkScoreText.text = edkScore.ToString();
        PlayerPrefs.SetString("edk_scoreString", edkScoreText.text);
        PlayerPrefs.Save();
        particleSpawner.GetComponent<ScoreParticles>().ActivateParticles();
    }

    public void RemoveEDKScore()
    {
        edkScore = PlayerPrefs.GetInt("edk_score");
        edkScore -= 50;

        audioSource.clip = soundClip[1];
        audioSource.Play();

        PlayerPrefs.SetInt("edk_score", edkScore);
        edkScoreText.text = edkScore.ToString();
        PlayerPrefs.SetString("edk_scoreString", edkScoreText.text);
        PlayerPrefs.Save();
    }
    //-----------------------------------------------------------------------

    //HADP functions
    public void SetHADPScore()
    {
        hadpScore = PlayerPrefs.GetInt("hadp_score");
        hadpScore = 0;
        PlayerPrefs.SetInt("hadp_score", hadpScore);
        hadpScoreText.text = hadpScore.ToString();
        PlayerPrefs.SetString("hadp_scoreString", hadpScoreText.text);
        PlayerPrefs.Save();
    }

    public void AddHADPScore()
    {
        hadpScore = PlayerPrefs.GetInt("hadp_score");
        hadpScore += 100;

        audioSource.clip = soundClip[0];
        audioSource.Play();

        PlayerPrefs.SetInt("hadp_score", hadpScore);
        hadpScoreText.text = hadpScore.ToString();
        PlayerPrefs.SetString("hadp_scoreString", hadpScoreText.text);
        PlayerPrefs.Save();
        particleSpawner.GetComponent<ScoreParticles>().ActivateParticles();
    }

    public void AddHADPTicTacToeScore()
    {
        hadpScore = PlayerPrefs.GetInt("hadp_score");
        hadpScore += 300;

        audioSource.clip = soundClip[0];
        audioSource.Play();

        PlayerPrefs.SetInt("hadp_score", hadpScore);
        hadpScoreText.text = hadpScore.ToString();
        PlayerPrefs.SetString("hadp_scoreString", hadpScoreText.text);
        PlayerPrefs.Save();
        particleSpawner.GetComponent<ScoreParticles>().ActivateParticles();
    }

    public void RemoveHADPScore()
    {
        hadpScore = PlayerPrefs.GetInt("hadp_score");
        hadpScore -= 50;

        audioSource.clip = soundClip[1];
        audioSource.Play();

        PlayerPrefs.SetInt("hadp_score", hadpScore);
        hadpScoreText.text = hadpScore.ToString();
        PlayerPrefs.SetString("hadp_scoreString", hadpScoreText.text);
        PlayerPrefs.Save();
    }
    //-----------------------------------------------------------------------

    //ESQ functions
    public void SetESQScore()
    {
        esqScore = PlayerPrefs.GetInt("esq_score");
        esqScore = 0;
        PlayerPrefs.SetInt("esq_score", esqScore);
        esqScoreText.text = esqScore.ToString();
        PlayerPrefs.SetString("esq_scoreString", esqScoreText.text);
        PlayerPrefs.Save();
    }

    public void AddESQScore()
    {
        esqScore = PlayerPrefs.GetInt("esq_score");
        esqScore += 100;

        audioSource.clip = soundClip[0];
        audioSource.Play();

        PlayerPrefs.SetInt("esq_score", esqScore);
        esqScoreText.text = esqScore.ToString();
        PlayerPrefs.SetString("esq_scoreString", esqScoreText.text);
        PlayerPrefs.Save();
        particleSpawner.GetComponent<ScoreParticles>().ActivateParticles();
    }

    public void AddESQTicTacToeScore()
    {
        esqScore = PlayerPrefs.GetInt("esq_score");
        esqScore += 300;

        audioSource.clip = soundClip[0];
        audioSource.Play();

        PlayerPrefs.SetInt("esq_score", esqScore);
        esqScoreText.text = esqScore.ToString();
        PlayerPrefs.SetString("esq_scoreString", esqScoreText.text);
        PlayerPrefs.Save();
        particleSpawner.GetComponent<ScoreParticles>().ActivateParticles();
    }

    public void RemoveESQScore()
    {
        esqScore = PlayerPrefs.GetInt("esq_score");
        esqScore -= 50;

        audioSource.clip = soundClip[1];
        audioSource.Play();

        PlayerPrefs.SetInt("esq_score", esqScore);
        esqScoreText.text = esqScore.ToString();
        PlayerPrefs.SetString("esq_scoreString", esqScoreText.text);
        PlayerPrefs.Save();
    }
    //-----------------------------------------------------------------------

    //SMBI functions
    public void SetSMBIScore()
    {
        smbiScore = PlayerPrefs.GetInt("smbi_score");
        smbiScore = 0;
        PlayerPrefs.SetInt("smbi_score", smbiScore);
        smbiScoreText.text = smbiScore.ToString();
        PlayerPrefs.SetString("smbi_scoreString", smbiScoreText.text);
        PlayerPrefs.Save();
    }

    public void AddSMBIScore()
    {
        smbiScore = PlayerPrefs.GetInt("smbi_score");
        smbiScore += 100;

        audioSource.clip = soundClip[0];
        audioSource.Play();

        PlayerPrefs.SetInt("smbi_score", smbiScore);
        smbiScoreText.text = smbiScore.ToString();
        PlayerPrefs.SetString("smbi_scoreString", smbiScoreText.text);
        PlayerPrefs.Save();
        particleSpawner.GetComponent<ScoreParticles>().ActivateParticles();
    }

    public void AddSMBITicTacToeScore()
    {
        smbiScore = PlayerPrefs.GetInt("smbi_score");
        smbiScore += 300;

        audioSource.clip = soundClip[0];
        audioSource.Play();

        PlayerPrefs.SetInt("smbi_score", smbiScore);
        smbiScoreText.text = smbiScore.ToString();
        PlayerPrefs.SetString("smbi_scoreString", smbiScoreText.text);
        PlayerPrefs.Save();
        particleSpawner.GetComponent<ScoreParticles>().ActivateParticles();
    }

    public void RemoveSMBIScore()
    {
        smbiScore = PlayerPrefs.GetInt("smbi_score");
        smbiScore -= 50;

        audioSource.clip = soundClip[1];
        audioSource.Play();

        PlayerPrefs.SetInt("smbi_score", smbiScore);
        smbiScoreText.text = smbiScore.ToString();
        PlayerPrefs.SetString("smbi_scoreString", smbiScoreText.text);
        PlayerPrefs.Save();
    }
    //-----------------------------------------------------------------------
    //-----------------------------------------------------------------------

    //SE functions
    public void SetSEScore()
    {
        seScore = PlayerPrefs.GetInt("se_score");
        seScore = 0;
        PlayerPrefs.SetInt("se_score", seScore);
        seScoreText.text = seScore.ToString();
        PlayerPrefs.SetString("se_scoreString", seScoreText.text);
        PlayerPrefs.Save();
    }

    public void AddSEScore()
    {
        seScore = PlayerPrefs.GetInt("se_score");
        seScore += 100;

        audioSource.clip = soundClip[0];
        audioSource.Play();

        PlayerPrefs.SetInt("se_score", seScore);
        seScoreText.text = seScore.ToString();
        PlayerPrefs.SetString("se_scoreString", seScoreText.text);
        PlayerPrefs.Save();
        particleSpawner.GetComponent<ScoreParticles>().ActivateParticles();
    }

    public void AddSETicTacToeScore()
    {
        seScore = PlayerPrefs.GetInt("se_score");
        seScore += 300;

        audioSource.clip = soundClip[0];
        audioSource.Play();

        PlayerPrefs.SetInt("se_score", seScore);
        seScoreText.text = seScore.ToString();
        PlayerPrefs.SetString("se_scoreString", seScoreText.text);
        PlayerPrefs.Save();
        particleSpawner.GetComponent<ScoreParticles>().ActivateParticles();
    }

    public void RemoveSEScore()
    {
        seScore = PlayerPrefs.GetInt("se_score");
        seScore -= 50;

        audioSource.clip = soundClip[1];
        audioSource.Play();

        PlayerPrefs.SetInt("se_score", seScore);
        seScoreText.text = seScore.ToString();
        PlayerPrefs.SetString("se_scoreString", seScoreText.text);
        PlayerPrefs.Save();
    }
    //-----------------------------------------------------------------------

    //ITBP functions
    public void SetITBPScore()
    {
        itbpScore = PlayerPrefs.GetInt("itbp_score");
        itbpScore = 0;
        PlayerPrefs.SetInt("itbp_score", itbpScore);
        itbpScoreText.text = itbpScore.ToString();
        PlayerPrefs.SetString("itbp_scoreString", itbpScoreText.text);
        PlayerPrefs.Save();
    }

    public void AddITBPScore()
    {
        itbpScore = PlayerPrefs.GetInt("itbp_score");
        itbpScore += 100;

        audioSource.clip = soundClip[0];
        audioSource.Play();

        PlayerPrefs.SetInt("itbp_score", itbpScore);
        itbpScoreText.text = itbpScore.ToString();
        PlayerPrefs.SetString("itbp_scoreString", itbpScoreText.text);
        PlayerPrefs.Save();
        particleSpawner.GetComponent<ScoreParticles>().ActivateParticles();
    }

    public void AddITBPTicTacToeScore()
    {
        itbpScore = PlayerPrefs.GetInt("itbp_score");
        itbpScore += 300;

        audioSource.clip = soundClip[0];
        audioSource.Play();

        PlayerPrefs.SetInt("itbp_score", itbpScore);
        itbpScoreText.text = itbpScore.ToString();
        PlayerPrefs.SetString("itbp_scoreString", itbpScoreText.text);
        PlayerPrefs.Save();
        particleSpawner.GetComponent<ScoreParticles>().ActivateParticles();
    }

    public void RemoveITBPScore()
    {
        itbpScore = PlayerPrefs.GetInt("itbp_score");
        itbpScore -= 50;

        audioSource.clip = soundClip[1];
        audioSource.Play();

        PlayerPrefs.SetInt("itbp_score", itbpScore);
        itbpScoreText.text = itbpScore.ToString();
        PlayerPrefs.SetString("itbp_scoreString", itbpScoreText.text);
        PlayerPrefs.Save();
    }
    //-----------------------------------------------------------------------

    //SESM functions
    public void SetSESMScore()
    {
        sesmScore = PlayerPrefs.GetInt("sesm_score");
        sesmScore = 0;
        PlayerPrefs.SetInt("sesm_score", sesmScore);
        sesmScoreText.text = sesmScore.ToString();
        PlayerPrefs.SetString("sesm_scoreString", sesmScoreText.text);
        PlayerPrefs.Save();
    }

    public void AddSESMScore()
    {
        sesmScore = PlayerPrefs.GetInt("sesm_score");
        sesmScore += 100;

        audioSource.clip = soundClip[0];
        audioSource.Play();

        PlayerPrefs.SetInt("sesm_score", sesmScore);
        sesmScoreText.text = sesmScore.ToString();
        PlayerPrefs.SetString("sesm_scoreString", sesmScoreText.text);
        PlayerPrefs.Save();
        particleSpawner.GetComponent<ScoreParticles>().ActivateParticles();
    }

    public void AddSESMTicTacToeScore()
    {
        sesmScore = PlayerPrefs.GetInt("sesm_score");
        sesmScore += 300;

        audioSource.clip = soundClip[0];
        audioSource.Play();

        PlayerPrefs.SetInt("sesm_score", sesmScore);
        sesmScoreText.text = sesmScore.ToString();
        PlayerPrefs.SetString("sesm_scoreString", sesmScoreText.text);
        PlayerPrefs.Save();
        particleSpawner.GetComponent<ScoreParticles>().ActivateParticles();
    }

    public void RemoveSESMScore()
    {
        sesmScore = PlayerPrefs.GetInt("sesm_score");
        sesmScore -= 50;

        audioSource.clip = soundClip[1];
        audioSource.Play();

        PlayerPrefs.SetInt("sesm_score", sesmScore);
        sesmScoreText.text = sesmScore.ToString();
        PlayerPrefs.SetString("sesm_scoreString", sesmScoreText.text);
        PlayerPrefs.Save();
    }
    //-----------------------------------------------------------------------

    //BO functions
    public void SetBOScore()
    {
        boScore = PlayerPrefs.GetInt("bo_score");
        boScore = 0;
        PlayerPrefs.SetInt("bo_score", boScore);
        boScoreText.text = boScore.ToString();
        PlayerPrefs.SetString("bo_scoreString", boScoreText.text);
        PlayerPrefs.Save();
    }

    public void AddBOScore()
    {
        boScore = PlayerPrefs.GetInt("bo_score");
        boScore += 100;

        audioSource.clip = soundClip[0];
        audioSource.Play();

        PlayerPrefs.SetInt("bo_score", boScore);
        boScoreText.text = boScore.ToString();
        PlayerPrefs.SetString("bo_scoreString", boScoreText.text);
        PlayerPrefs.Save();
        particleSpawner.GetComponent<ScoreParticles>().ActivateParticles();
    }

    public void AddBOTicTacToeScore()
    {
        boScore = PlayerPrefs.GetInt("bo_score");
        boScore += 300;

        audioSource.clip = soundClip[0];
        audioSource.Play();

        PlayerPrefs.SetInt("bo_score", boScore);
        boScoreText.text = boScore.ToString();
        PlayerPrefs.SetString("bo_scoreString", boScoreText.text);
        PlayerPrefs.Save();
        particleSpawner.GetComponent<ScoreParticles>().ActivateParticles();
    }

    public void RemoveBOScore()
    {
        boScore = PlayerPrefs.GetInt("bo_score");
        boScore -= 50;

        audioSource.clip = soundClip[1];
        audioSource.Play();

        PlayerPrefs.SetInt("bo_score", boScore);
        boScoreText.text = boScore.ToString();
        PlayerPrefs.SetString("bo_scoreString", boScoreText.text);
        PlayerPrefs.Save();
    }
    //-----------------------------------------------------------------------

    //SPC functions
    public void SetSPCScore()
    {
        spcScore = PlayerPrefs.GetInt("spc_score");
        spcScore = 0;
        PlayerPrefs.SetInt("spc_score", spcScore);
        spcScoreText.text = spcScore.ToString();
        PlayerPrefs.SetString("spc_scoreString", spcScoreText.text);
        PlayerPrefs.Save();
    }

    public void AddSPCScore()
    {
        spcScore = PlayerPrefs.GetInt("spc_score");
        spcScore += 100;

        audioSource.clip = soundClip[0];
        audioSource.Play();

        PlayerPrefs.SetInt("spc_score", spcScore);
        spcScoreText.text = spcScore.ToString();
        PlayerPrefs.SetString("spc_scoreString", spcScoreText.text);
        PlayerPrefs.Save();
        particleSpawner.GetComponent<ScoreParticles>().ActivateParticles();
    }

    public void AddSPCTicTacToeScore()
    {
        spcScore = PlayerPrefs.GetInt("spc_score");
        spcScore += 300;

        audioSource.clip = soundClip[0];
        audioSource.Play();

        PlayerPrefs.SetInt("spc_score", spcScore);
        spcScoreText.text = spcScore.ToString();
        PlayerPrefs.SetString("spc_scoreString", spcScoreText.text);
        PlayerPrefs.Save();
        particleSpawner.GetComponent<ScoreParticles>().ActivateParticles();
    }

    public void RemoveSPCScore()
    {
        spcScore = PlayerPrefs.GetInt("spc_score");
        spcScore -= 50;

        audioSource.clip = soundClip[1];
        audioSource.Play();

        PlayerPrefs.SetInt("spc_score", spcScore);
        spcScoreText.text = spcScore.ToString();
        PlayerPrefs.SetString("spc_scoreString", spcScoreText.text);
        PlayerPrefs.Save();
    }
    //-----------------------------------------------------------------------

    //AGSE functions
    public void SetAGSEScore()
    {
        agseScore = PlayerPrefs.GetInt("agse_score");
        agseScore = 0;
        PlayerPrefs.SetInt("agse_score", agseScore);
        agseScoreText.text = agseScore.ToString();
        PlayerPrefs.SetString("agse_scoreString", agseScoreText.text);
        PlayerPrefs.Save();
    }

    public void AddAGSEScore()
    {
        agseScore = PlayerPrefs.GetInt("agse_score");
        agseScore += 100;

        audioSource.clip = soundClip[0];
        audioSource.Play();

        PlayerPrefs.SetInt("agse_score", agseScore);
        agseScoreText.text = agseScore.ToString();
        PlayerPrefs.SetString("agse_scoreString", agseScoreText.text);
        PlayerPrefs.Save();
        particleSpawner.GetComponent<ScoreParticles>().ActivateParticles();
    }

    public void AddAGSETicTacToeScore()
    {
        agseScore = PlayerPrefs.GetInt("agse_score");
        agseScore += 300;

        audioSource.clip = soundClip[0];
        audioSource.Play();

        PlayerPrefs.SetInt("agse_score", agseScore);
        agseScoreText.text = agseScore.ToString();
        PlayerPrefs.SetString("agse_scoreString", agseScoreText.text);
        PlayerPrefs.Save();
        particleSpawner.GetComponent<ScoreParticles>().ActivateParticles();
    }

    public void RemoveAGSEScore()
    {
        agseScore = PlayerPrefs.GetInt("agse_score");
        agseScore -= 50;

        audioSource.clip = soundClip[1];
        audioSource.Play();

        PlayerPrefs.SetInt("agse_score", agseScore);
        agseScoreText.text = agseScore.ToString();
        PlayerPrefs.SetString("agse_scoreString", agseScoreText.text);
        PlayerPrefs.Save();
    }
    //-----------------------------------------------------------------------

    //EPDO functions
    public void SetEPDOScore()
    {
        epdoScore = PlayerPrefs.GetInt("epdo_score");
        epdoScore = 0;
        PlayerPrefs.SetInt("epdo_score", epdoScore);
        epdoScoreText.text = epdoScore.ToString();
        PlayerPrefs.SetString("epdo_scoreString", epdoScoreText.text);
        PlayerPrefs.Save();
    }

    public void AddEPDOScore()
    {
        epdoScore = PlayerPrefs.GetInt("epdo_score");
        epdoScore += 100;

        audioSource.clip = soundClip[0];
        audioSource.Play();

        PlayerPrefs.SetInt("epdo_score", epdoScore);
        epdoScoreText.text = epdoScore.ToString();
        PlayerPrefs.SetString("epdo_scoreString", epdoScoreText.text);
        PlayerPrefs.Save();
        particleSpawner.GetComponent<ScoreParticles>().ActivateParticles();
    }

    public void AddEPDOTicTacToeScore()
    {
        epdoScore = PlayerPrefs.GetInt("epdo_score");
        epdoScore += 300;

        audioSource.clip = soundClip[0];
        audioSource.Play();

        PlayerPrefs.SetInt("epdo_score", epdoScore);
        epdoScoreText.text = epdoScore.ToString();
        PlayerPrefs.SetString("epdo_scoreString", epdoScoreText.text);
        PlayerPrefs.Save();
        particleSpawner.GetComponent<ScoreParticles>().ActivateParticles();
    }

    public void RemoveEPDOScore()
    {
        epdoScore = PlayerPrefs.GetInt("epdo_score");
        epdoScore -= 50;

        audioSource.clip = soundClip[1];
        audioSource.Play();

        PlayerPrefs.SetInt("epdo_score", epdoScore);
        epdoScoreText.text = epdoScore.ToString();
        PlayerPrefs.SetString("epdo_scoreString", epdoScoreText.text);
        PlayerPrefs.Save();
    }
    //-----------------------------------------------------------------------

    //NBI functions
    public void SetNBIScore()
    {
        nbiScore = PlayerPrefs.GetInt("nbi_score");
        nbiScore = 0;
        PlayerPrefs.SetInt("nbi_score", nbiScore);
        nbiScoreText.text = nbiScore.ToString();
        PlayerPrefs.SetString("nbi_scoreString", nbiScoreText.text);
        PlayerPrefs.Save();
    }

    public void AddNBIScore()
    {
        nbiScore = PlayerPrefs.GetInt("nbi_score");
        nbiScore += 100;

        audioSource.clip = soundClip[0];
        audioSource.Play();

        PlayerPrefs.SetInt("nbi_score", nbiScore);
        nbiScoreText.text = nbiScore.ToString();
        PlayerPrefs.SetString("nbi_scoreString", nbiScoreText.text);
        PlayerPrefs.Save();
        particleSpawner.GetComponent<ScoreParticles>().ActivateParticles();
    }

    public void AddNBITicTacToeScore()
    {
        nbiScore = PlayerPrefs.GetInt("nbi_score");
        nbiScore += 300;

        audioSource.clip = soundClip[0];
        audioSource.Play();

        PlayerPrefs.SetInt("nbi_score", nbiScore);
        nbiScoreText.text = nbiScore.ToString();
        PlayerPrefs.SetString("nbi_scoreString", nbiScoreText.text);
        PlayerPrefs.Save();
        particleSpawner.GetComponent<ScoreParticles>().ActivateParticles();
    }

    public void RemoveNBIScore()
    {
        nbiScore = PlayerPrefs.GetInt("nbi_score");
        nbiScore -= 50;

        audioSource.clip = soundClip[1];
        audioSource.Play();

        PlayerPrefs.SetInt("nbi_score", nbiScore);
        nbiScoreText.text = nbiScore.ToString();
        PlayerPrefs.SetString("nbi_scoreString", nbiScoreText.text);
        PlayerPrefs.Save();
    }
    //-----------------------------------------------------------------------
}