using UnityEngine;
using Unity.Cinemachine; 

public class CameraSpeedEffect : MonoBehaviour
{
    public Rigidbody shipRb;
    public float baseFOV = 60f;
    public float maxFOV = 90f;
    public float speedMultiplier = 1.5f;

    
    private CinemachineCamera vcam;

    void Start()
    {
        vcam = GetComponent<CinemachineCamera>();
    }

    void Update()
    {
        if (shipRb == null) return;
        
        // Чем быстрее летит корабль, тем шире угол обзора
        float targetFOV = baseFOV + (shipRb.linearVelocity.magnitude * speedMultiplier); 
        
   
        vcam.Lens.FieldOfView = Mathf.Lerp(vcam.Lens.FieldOfView, Mathf.Clamp(targetFOV, baseFOV, maxFOV), Time.deltaTime * 3f);
    }
}