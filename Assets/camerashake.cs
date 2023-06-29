using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class camerashake : MonoBehaviour
{
    public static camerashake Instance { get; private set; }

    private CinemachineVirtualCamera camera2d;
    private float shakeTimer;
    
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        camera2d = GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (shakeTimer > 0f)
        {
         shakeTimer -= Time.deltaTime;  
            if(shakeTimer <= 0f) 
            {
                CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = camera2d.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0f;
            }
        }
        
    }
    public void ShakeCamera(float intensity, float time) 
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = camera2d.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
        shakeTimer = time;
    }
    
}
