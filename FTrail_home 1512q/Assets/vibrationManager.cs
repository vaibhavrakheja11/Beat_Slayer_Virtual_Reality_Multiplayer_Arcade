using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vibrationManager : MonoBehaviour
{
    public static vibrationManager singleton;
    void Start()
    {
        if (singleton && singleton != this)
        {
            Destroy(singleton);
        }
        else
            singleton = this;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void TriggerVibration(int iteration, int frequency, int strength, OVRInput.Controller controller)
    {
        OVRHapticsClip clip = new OVRHapticsClip();

        for (int i =0; i< iteration; i++)
        {
            clip.WriteSample(i % frequency == 0 ? (byte)strength : (byte)0);
        }

        if(controller == OVRInput.Controller.LTouch)
        {

            OVRHaptics.LeftChannel.Preempt(clip);

        }
        if (controller == OVRInput.Controller.RTouch)
        {

            OVRHaptics.RightChannel.Preempt(clip);

        }
    }
}
