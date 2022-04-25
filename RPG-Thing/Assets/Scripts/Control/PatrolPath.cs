using UnityEngine;

namespace RPG.Control
{
    public class PatrolPath : MonoBehaviour
    {
        private void OnDrawGizmos()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawSphere(GetWaypoint(i), 0.2f);
                Gizmos.DrawLine(GetWaypoint(i), GetWaypoint(GetNextIndex(i)));
            }
        }

        private int GetNextIndex(int i)
        {
            if (i == transform.childCount - 1)
            {
                return 0;
            }
            else
            {
                return i + 1;
            }
        }

        private Vector3 GetWaypoint(int i)
        {
            return transform.GetChild(i).position;
        }
    }

}