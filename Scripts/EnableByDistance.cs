using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 通过距离控制显隐
/// </summary>
public class EnableByDistance : MonoBehaviour
{
    /// <summary>
    /// 目标：一般是摄像机
    /// </summary>
    [SerializeField] GameObject mTarget;
    /// <summary>
    /// 判断显隐的直线举例
    /// </summary>
    [SerializeField] float mMaxDistance;
    /// <summary>
    /// 检测间隔
    /// </summary>
    [SerializeField] int mWaitFrameDelay;
    /// <summary>
    /// 想要控制的组件
    /// </summary>
    [SerializeField] MeshRenderer mMeshRender;

    float mMaxDistanceSqrd;
    void Start()
    {
        mMaxDistanceSqrd = mMaxDistance * mMaxDistance;
        StartCoroutine(HandleByDistance());
    }

    IEnumerator HandleByDistance() {
        while (true)
        {
            float distSqrd = (transform.position - mTarget.transform.position).sqrMagnitude;
            Debug.LogFormat("{0} > {1}", distSqrd, mMaxDistanceSqrd);
            enabled = distSqrd < mMaxDistanceSqrd;
            mMeshRender.enabled = enabled;
            for (int i = 0; i < mWaitFrameDelay; i++)
            {
                yield return new WaitForEndOfFrame();
            }
        }
    }
}
