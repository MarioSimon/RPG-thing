using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

namespace RPG.SceneManagement
{
    public class Portal : MonoBehaviour
    {
        enum DestinationIdentifier
        {
            A, B, D, C, E
        }

        [SerializeField] int sceneToLoad = -1;
        [SerializeField] Transform spawnPoint;
        [SerializeField] DestinationIdentifier destination;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                StartCoroutine(Transition());
            }
        }

        private IEnumerator Transition()
        {
            if (sceneToLoad < 0)
            {
                Debug.LogError("Missing scene to load reference");
                yield break;
            }

            DontDestroyOnLoad(this.gameObject);
            yield return SceneManager.LoadSceneAsync(sceneToLoad);

            Portal otherPortal = GetOtherPortal();
            UpdatePlayer(otherPortal);

            Destroy(this.gameObject);
        }

        private void UpdatePlayer(Portal otherPortal)
        {
            GameObject player = GameObject.FindWithTag("Player");
            player.transform.rotation = otherPortal.spawnPoint.transform.rotation;
            //player.transform.position = otherPortal.spawnPoint.transform.position;
            player.GetComponent<NavMeshAgent>().Warp(otherPortal.spawnPoint.transform.position);
        }

        private Portal GetOtherPortal()
        {

            foreach (Portal portal in GameObject.FindObjectsOfType<Portal>())
            {
                if (this == portal) continue;
                if (destination != portal.destination) continue;

                return portal;
            }

            return null;
        }
    }
}
