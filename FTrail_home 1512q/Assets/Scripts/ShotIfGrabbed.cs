using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotIfGrabbed : MonoBehaviour
{
    // Start is called before the first frame update
    public OVRInput.Button shootingButton;
    private SimpleShoot simpleShoot;
    private OVRGrabbable ovrGrabbable;
    

    void Start()
    {
        simpleShoot = GetComponent<SimpleShoot>();
        ovrGrabbable = GetComponent<OVRGrabbable>();
    }

    // Update is called once per frame
    void Update()
    { 
        if(ovrGrabbable.isGrabbed && OVRInput.GetDown(shootingButton,ovrGrabbable.grabbedBy.GetController()))
        {
            simpleShoot.Shoot();
            vibrationManager.singleton.TriggerVibration(40, 2, 255, ovrGrabbable.grabbedBy.GetController());

        }
    }
}
