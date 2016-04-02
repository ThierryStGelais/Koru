using UnityEngine;
using System.Collections;

public class Gizmo_InterestPoint : MonoBehaviour {
#if UNITY_EDITOR
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position, new Vector3(1, 1, 1));
    }
#endif
}
