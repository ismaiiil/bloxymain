using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public GameObject player;
    Transform mTrans;
    Quaternion mStart;
    Vector2 mRot = Vector2.zero;

    void Start()
    {
        mTrans = transform;
        mStart = mTrans.localRotation;
    }

    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            Vector3 pos = player.transform.position;

            float halfWidth = Screen.width * 0.5f;
            float halfHeight = Screen.height * 0.5f;
            float x = Mathf.Clamp((pos.x - halfWidth) / halfWidth, -1f, 1f);
            float y = Mathf.Clamp((pos.y - halfHeight) / halfHeight, -1f, 1f);
            mRot = Vector2.Lerp(mRot, new Vector2(x, y), Time.deltaTime * 5f);

            mTrans.localRotation = mStart * Quaternion.Euler(-mRot.x * player.transform.position.x, -mRot.y * player.transform.position.z, 0f);
        }


        
    }
}
