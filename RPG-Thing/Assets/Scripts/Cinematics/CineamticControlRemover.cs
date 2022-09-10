﻿using UnityEngine;
using UnityEngine.Playables;
using RPG.Core;
using RPG.Control;

namespace Assets.Scripts.Cinematics
{
    class CineamticControlRemover : MonoBehaviour
    {
        GameObject player;
        private void Start()
        {
            GetComponent<PlayableDirector>().played += DisableControl;
            GetComponent<PlayableDirector>().stopped += EnableControl;

            player = GameObject.FindWithTag("Player");
        }
        void DisableControl(PlayableDirector pd)
        {        
            player.GetComponent<ActionScheduler>().CancelCurrentAction();
            player.GetComponent<PlayerController>().enabled = false;
            print("Disable control");
        }

        void EnableControl(PlayableDirector pd)
        {
            player.GetComponent<PlayerController>().enabled = true;
            print("Enable control");
        }
    }
}