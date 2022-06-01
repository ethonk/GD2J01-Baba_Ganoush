using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTextPop : MonoBehaviour
{
    public void TextPop(int _1, int _2)
    {
        Animator animator = GetComponent<Animator>();
        
        // play if not currently
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("CoinTextPop"))
            animator.SetTrigger("pop");
    }
}
