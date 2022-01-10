using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 通过可见性来控制物件的显隐
/// </summary>
public class EnableByVisible : MonoBehaviour
{
    public GameObject mTarget;
    private void OnBecameVisible()
    {
        Debug.Log(mTarget.name + ":可见");
        mTarget.SetActive(true);
    }

    private void OnBecameInvisible()
    {
        Debug.Log(mTarget.name + ":不可见");
        mTarget.SetActive(false);
    }
}
