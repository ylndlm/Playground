﻿namespace VRTK.Examples
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using DG.Tweening;

    public class ArcadeModeTarget : MonoBehaviour
    {
        // Vector3 startScale;
        // Use this for initialization
        void Start()
        {
            // transform.LookAt(ArcadeGameModeManager.instance.transform.position);
            // transform.Rotate(-90, 0, 0);
            // //transform.rotation = Quaternion.Euler(-90,0,transform.rotation.eulerAngles.z);
            // startScale = transform.localScale;
        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnCollisionEnter(Collision collision)
        {
            //check how far from center

            if (collision.gameObject.tag == "AxeTip")
            {
                // other.GetComponent<Axe>().scored = true;
                StartCoroutine(OnTargetHit(collision.gameObject));
            }

        }

        float punchScaleTime = 0.2f;


        IEnumerator OnTargetHit(GameObject ballThatHit)
        {

            // ArcadeGameModeManager.instance.Score(Vector3.Distance(ballThatHit.transform.position, transform.position), transform);
            //theres a oncomplete function I can use
            transform.parent.DOPunchScale(Vector3.one / 2, punchScaleTime, 1, 0);
            ballThatHit.GetComponentInParent<Rigidbody>().isKinematic = true;

            yield return null;

            // yield return new WaitForSeconds(punchScaleTime);

            // transform.localScale = startScale;



        }
    }
}
