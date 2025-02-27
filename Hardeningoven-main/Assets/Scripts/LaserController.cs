using UnityEngine;

public class LaserController : MonoBehaviour
{
    public GameObject laserBeam;  // Reference to the laser beam object
    public GameObject imageSurface;  // Reference to the image projection surface

    void Start()
    {
        // Ensure the laser and image are off at the start
        laserBeam.SetActive(false);
        imageSurface.SetActive(false);
    }

    public void TurnOnLaser()
    {
        // Activate the laser and the image
        laserBeam.SetActive(true);
        imageSurface.SetActive(true); // Show the image
    }

    public void TurnOffLaser()
    {
        // Deactivate the laser and the image
        laserBeam.SetActive(false);
        imageSurface.SetActive(false); // Hide the image
    }
}
