using UnityEngine;
using Cinemachine;

public class CinemachineShake : MonoBehaviour
{
    private CinemachineVirtualCamera cinemachineVirtualCamrea;
    private float shakeTimer;

    private void Awake()
    {
        cinemachineVirtualCamrea = GetComponent<CinemachineVirtualCamera>();
    }

    private void Update()
    {
        if (shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
            if (shakeTimer <= 0f)
                cinemachineVirtualCamrea
                    .GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>()
                    .m_AmplitudeGain = 0f;
        }

    }

    public void ShakeCamera(float intensity, float time)
    {
        var perlin = cinemachineVirtualCamrea.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        perlin.m_AmplitudeGain = intensity;
        perlin.m_FrequencyGain = 2f;
        shakeTimer = time;
    }
}
