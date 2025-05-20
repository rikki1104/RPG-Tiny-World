using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Control
{
    public class ObjectFader : MonoBehaviour
    {
        public float fadeSpeed;
        public float fadeAmount;

        float originalOpacity;
        public bool DoFade = false;

        Material material;

        void Start()
        {
            material = GetComponent<Renderer>().material;
            originalOpacity = material.color.a;
        }

        void Update()
        {
            if (DoFade)
            {
                FadeNow();
            }
            else
            {
                ResetFade();
            }
        }

        public void FadeNow()
        {
            Color currentColor = material.color;
            Color smoothColor = new Color(currentColor.r, currentColor.g, currentColor.b, Mathf.Lerp(currentColor.a, fadeAmount, fadeSpeed * Time.deltaTime));
            material.color = smoothColor;
        }

        public void ResetFade()
        {
            Color currentColor = material.color;
            Color smoothColor = new Color(currentColor.r, currentColor.g, currentColor.b, Mathf.Lerp(currentColor.a, originalOpacity, fadeSpeed));
            material.color = smoothColor;
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                DoFade = true;
            }
        }

        void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {                
                DoFade = false;               
            }
        }
    }
}

