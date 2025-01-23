using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointInSpace : MonoBehaviour
{
    public float range;
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }



    //private void OnDrawGizmosSelected()
    //{
        
    //}
}
