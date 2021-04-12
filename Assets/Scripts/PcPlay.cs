using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Management;

public class PcPlay : MonoBehaviour
{
    private void Start()
    {
        XRGeneralSettings.Instance.Manager.InitializeLoader();
    }
    public void PlayPcGame() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
