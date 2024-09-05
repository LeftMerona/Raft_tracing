using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hooktest : MonoBehaviour
{
    [SerializeField] private GameObject hook;
    [SerializeField] private GameObject pivot;

    private void Awake()
    {
        hook.transform.SetParent(pivot.transform);
        hook.transform.localPosition = Vector3.zero;
        //Debug.Log(pivot.transform.rotation);
        Debug.Log(pivot.transform.localRotation);
        hook.transform.localRotation = pivot.transform.localRotation;
        Debug.Log(hook.transform.localRotation);

    }
    


}
