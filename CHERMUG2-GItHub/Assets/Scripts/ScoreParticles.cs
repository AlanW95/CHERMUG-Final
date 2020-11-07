using UnityEngine;

//////////////////////////////////////////////////<summary>//////////////////////////////////////////////////// 
///                                   University of the West of Scotland                                    ///
///                               -------------------------------------------                               ///  
/// Script is attached to the ParticleSpawner GameObject on the ScoreBar child of the Bars Prefab.          ///
///                                                                                                         ///
/// This is called from the AddScore method in the ScoreSystem script.                                      ///
///                                                                                                         ///
//////////////////////////////////////////////////</summary>///////////////////////////////////////////////////

public class ScoreParticles : MonoBehaviour
{
    public GameObject scoreParticles;

    public void ActivateParticles()
    {
        GameObject clone = Instantiate(scoreParticles, transform.position, Quaternion.identity) as GameObject;//Spawns particle at spawner location
        clone.transform.parent = transform;//Adds the clone particle as a child of the spawner
        Destroy(clone, 5);//Destroys particle
    }
}
