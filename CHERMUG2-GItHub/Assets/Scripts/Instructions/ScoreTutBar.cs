using UnityEngine;

//////////////////////////////////////////////////<summary>//////////////////////////////////////////////////// 
///                                   University of the West of Scotland                                    ///               
///                               -------------------------------------------                               ///  
/// Script is attached to the ScoreBar GameObject in the Instructions scene.                                ///                  
///                                                                                                         ///
//////////////////////////////////////////////////</summary>///////////////////////////////////////////////////

public class ScoreTutBar : MonoBehaviour
{
    public Animator scoreAnim;
    public int scoreStates;
    public GameObject particleSpawner;

    // Start is called before the first frame update
    void Start()
    {
        scoreStates = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ScoreAnimationStates();
    }

    public void PlayStarParticle()
    {
        particleSpawner.GetComponent<ScoreParticles>().ActivateParticles();
    }

    public void ScoreAnimationStates()
    {
        switch (scoreStates)
        {
            default:
                break;
            case 0:
                //Idle
                scoreAnim.SetInteger("UI_States", 0);
                break;
            case 1:
                //Slides UI bars into view
                scoreAnim.SetInteger("UI_States", 1);
                break;
        }
    }
}
