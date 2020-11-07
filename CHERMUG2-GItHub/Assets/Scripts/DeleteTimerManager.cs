using UnityEngine;

//////////////////////////////////////////////////<summary>//////////////////////////////////////////////////// 
///                                   University of the West of Scotland                                    ///
///                               -------------------------------------------                               ///  
/// Script is attached to the SceneManager in each EndSummary scene.                                        ///
/// It's called from the OnClick on the Return To Main Menu Button.                                         ///
/// This ensures that the TimerManager is deleted at the end of each topic as a new one is added            ///
/// each time the player navigates back to the QuanMenu. This ensures there aren't multiple timers.         ///
///                                                                                                         ///
//////////////////////////////////////////////////</summary>///////////////////////////////////////////////////

public class DeleteTimerManager : MonoBehaviour
{
    public GameObject timerManager;

    // Start is called before the first frame update
    void Awake()
    {
        timerManager = GameObject.Find("TimerManager");
    }
    public void DeleteTimerScript()
    {
        Destroy(timerManager);
    }
}
