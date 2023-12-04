using UnityEngine;
using UnityEngine.UI;

public class coordinates : MonoBehaviour
{
    public Text infoText;

    private Vector3 angularVelocityDegrees = new();
    
    // Start is called before the first frame update
    void Start()
    {
        if(SystemInfo.supportsGyroscope) {
            Input.gyro.enabled = true;
        }
        Input.location.Start();
    }

    // Update is called once per frame
    void Update()
    {
        var angularVelocity = Input.gyro.rotationRate;
        angularVelocityDegrees = angularVelocity * Mathf.Rad2Deg;
        infoText.text = "Angular Velocity: " + angularVelocityDegrees.ToString() + '\n';
        infoText.text += "Acceleration: " + Input.acceleration.ToString() + '\n'; 
        infoText.text += "Latitude: " + Input.location.lastData.latitude + '\n';
        infoText.text += "Gravedad: " + Input.gyro.gravity.ToString() + '\n';
        infoText.text += "Longitude: " + Input.location.lastData.longitude + '\n';
        infoText.text += "Altitude: " + Input.location.lastData.altitude + '\n';    
    }
}
