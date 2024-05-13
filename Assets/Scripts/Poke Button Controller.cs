using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PokeButtonController : MonoBehaviour
{
    public GameObject SmallFireEffect;
    public GameObject BigFireEffect;

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
        StartCoroutine(StartFireEffect());
    }

    public void onSelectExited(SelectExitEventArgs e)
    {
        Debug.Log("Poke Button SelectedExited: " + e.ToString());
    }

    IEnumerator StartFireEffect()
    {
        SmallFireEffect.SetActive(true);
        yield return new WaitForSeconds(3);
        BigFireEffect.SetActive(true);
    }
}
