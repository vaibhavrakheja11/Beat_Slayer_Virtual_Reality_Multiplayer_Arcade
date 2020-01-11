using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EPlayerManager : MonoBehaviour
{
    // Start is called before the first frame update
    #region Singleton

    public static EPlayerManager instance;

    void awake()
    {
        Debug.Log("Vaibhav");
        //instance = this;

    }



    #endregion

    
    public GameObject player;

}
