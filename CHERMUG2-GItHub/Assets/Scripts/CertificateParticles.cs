using UnityEngine;

//////////////////////////////////////////////////<summary>//////////////////////////////////////////////////// 
///                                   University of the West of Scotland                                    ///
///                               -------------------------------------------                               ///  
/// Script is attached to the ParticleSpawner GameObjects in the EndSummary scenes.                         ///
///                                                                                                         ///
/// This is called from the ScreenshotReturn method in the Summary script.                                  ///
///                                                                                                         ///
//////////////////////////////////////////////////</summary>///////////////////////////////////////////////////

public class CertificateParticles : MonoBehaviour
{
    public GameObject confettiParticles;

    public void ActivateParticles()
    {
        GameObject clone = Instantiate(confettiParticles, transform.position, Quaternion.identity) as GameObject;//Spawns particle at spawner location
        clone.transform.parent = transform;//Adds the clone particle as a child of the spawner
        Destroy(clone, 5);//Destroys particle
    }
}
