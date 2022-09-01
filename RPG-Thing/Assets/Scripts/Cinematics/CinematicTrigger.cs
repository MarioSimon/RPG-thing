using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace RPG.Cinematics
{
    public class CinematicTrigger : MonoBehaviour
    {
        private bool played = false;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player") && !played) { 
                GetComponent<PlayableDirector>().Play();
                played = true;
                //GetComponent<PlayableDirector>().gameObject.SetActive(false);
            }
        }
    }
}
