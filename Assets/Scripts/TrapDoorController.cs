using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDoorController : MonoBehaviour {
    
    public Animator trapDoorAnim;
    void Awake()
    {
        
        trapDoorAnim = GetComponent<Animator>();
        
        StartCoroutine(OpenCloseTrap());
    }


    private IEnumerator OpenCloseTrap()
    {
        trapDoorAnim.SetTrigger("open");
        yield return new WaitForSeconds(2);
        trapDoorAnim.SetTrigger("close");
        yield return new WaitForSeconds(2);
        StartCoroutine(OpenCloseTrap());
    }
}