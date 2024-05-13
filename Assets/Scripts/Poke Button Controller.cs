using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PokeButtonController : MonoBehaviour
{
    public GameObject SmallFireEffect;
    public GameObject BigFireEffect;
    public GameObject ExplosionEffect;
    public float explosionWaitForSeconds = 3;

    private bool isOnFire = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onSelectEntered(SelectEnterEventArgs e)
    {
        Debug.Log("Poke Button SelectedEntered: " + e.ToString());
        if (!isOnFire)
        {
            isOnFire = true;
            StartCoroutine(StartFireEffect());
        }
        else
        {
            isOnFire = false;
            StartCoroutine(StopFireEffect());
        }
        
    }

    public void onSelectExited(SelectExitEventArgs e)
    {
        Debug.Log("Poke Button SelectedExited: " + e.ToString());
    }

    IEnumerator StartFireEffect()
    {
        SmallFireEffect.SetActive(true);
        yield return new WaitForSeconds(explosionWaitForSeconds);
        ExplosionEffect.SetActive(true);
        BigFireEffect.SetActive(true);
    }

    IEnumerator StopFireEffect()
    {
        yield return new WaitForSeconds(0);
        SmallFireEffect.SetActive(false);
        BigFireEffect.SetActive(false);
        ExplosionEffect.SetActive(false);
    }
}
