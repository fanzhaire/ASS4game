using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Ïà»ú¸úËæ
/// </summary>
public class CamerFollowC : MonoBehaviour
{
    public Transform target;
    void LateUpdate()
    {
        transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);
    }
}


