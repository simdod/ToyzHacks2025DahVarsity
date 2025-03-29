 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    public GameObject Effect1;
    public GameObject Effect2;

    void Start()
    {
        animator = GetComponent<Animator>();
        Debug.Log(animator);
    }

    // Update is called once per frame
    void Update()
    {
        bool isdancing = animator.GetBool("isdancing");
        if (Input.GetKeyDown(KeyCode.Space)) // Check if space key is pressed down
        {
            if(!isdancing) // Start  dancing only if not already dancing
            {
                animator.SetBool("isdancing", true);
                //Effect.SetActive(true);
            }
        }
        
        if (Input.anyKeyDown) // Check if any key is pressed down
        {
            if(isdancing) // Stop dancing only if currently dancing
            {
            animator.SetBool("isdancing", false);
            if (Effect2.activeSelf){
                 Effect2.SetActive(false);
            }
            if (Effect1.activeSelf){
                 Effect1.SetActive(false);
            }
            }     
        }
        if (isdancing && Input.GetKey("c")){
            if (Effect2.activeSelf){
                 Effect2.SetActive(false);
            }
              Effect1.SetActive(true);
        }
        if (isdancing && Input.GetKey("b")){
            Debug.Log(Effect1);
            if (Effect1.activeSelf){
                Debug.Log("effect 1 turned off");
                Effect1.SetActive(false);
            }
              Effect2.SetActive(true);
        }

    
    
}}
