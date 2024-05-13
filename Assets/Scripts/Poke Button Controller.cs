using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PokeButtonController : MonoBehaviour
{
    public GameObject SmallFireEffect;
    public GameObject BigFireEffect;
    public GameObject ExplosionEffect;
    public float fireWaitForSeconds = 3;
    public float explosionWaitForSeconds = 3;
    public GameObject PressAnimatorGameObject;

    private bool isOnFire = false;
    private Animator pressAnimator;

    // Start is called before the first frame update
    void Start()
    {
        pressAnimator = PressAnimatorGameObject.GetComponent<Animator>();
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
        pressAnimator.Play("Press");
        yield return new WaitForSeconds(fireWaitForSeconds);
        SmallFireEffect.SetActive(true);
        yield return new WaitForSeconds(explosionWaitForSeconds);
        ExplosionEffect.SetActive(true);
        BigFireEffect.SetActive(true);
    }

    IEnumerator StopFireEffect()
    {
        pressAnimator.Rebind();
        pressAnimator.Update(0f);
        yield return new WaitForSeconds(0);
        SmallFireEffect.SetActive(false);
        BigFireEffect.SetActive(false);
        ExplosionEffect.SetActive(false);
    }
}
