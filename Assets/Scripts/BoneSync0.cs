using System;
using UnityEngine;

public class BoneSync0 : MonoBehaviour
{
    [SerializeField] private GameObject modelTarget;

    [SerializeField] private GameObject modelRecver;

    private Animator animTarget;
    private Animator animRecver;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (animTarget != null && animRecver != null) 
        {
            SyncBones();
        }
        else
        {
            if(modelTarget != null)
            {
                animTarget = modelTarget.GetComponent<Animator>();
            }
            if (modelRecver != null)
            {
                animRecver = modelRecver.GetComponent<Animator>();
            }
        }
    }

    private void SyncBones()
    {
        foreach (HumanBodyBones bone in Enum.GetValues(typeof(HumanBodyBones)))
        {
            if (bone == HumanBodyBones.LastBone) { continue; }
            SyncBone(bone);
        }
    }

    private void SyncBone(HumanBodyBones bone)
    {
        Animator dst = animTarget;
        Animator src = animRecver;

        var dstBone = dst.GetBoneTransform(bone);
        var srcBone = src.GetBoneTransform(bone);

        if (dstBone == null) { return; }
        if (srcBone == null) { return; }

        {
            // パキッと回る
            // dstBone.localRotation = srcBone.localRotation;

            //　ゆっくり回る
            dstBone.localRotation = Quaternion.Slerp(dstBone.localRotation, srcBone.localRotation, 1f);
        }

    }
}
