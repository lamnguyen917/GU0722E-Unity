using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
   [SerializeField] private Animator anim;
   public void Close()
   {
      anim.SetBool("Open", false);
      // gameObject.SetActive(false);
   }

   public void Open()
   {
      anim.SetBool("Open", true);
   }

   public void OnClosed()
   {
      gameObject.SetActive(false);
   }
}
