using Cinemachine;
using RPG.Movement;
using UnityEngine;

namespace RPG.Control
{
    public class CameraController : MonoBehaviour
    {
        ObjectFader objectFader;

        void OnTriggerEnter(Collider other)
        {
            objectFader = GetComponent<ObjectFader>();
            if (other.gameObject.tag == "Player")
            {
                if (objectFader != null)
                {
                    objectFader.DoFade = true;
                }
            }
            else
            {
                if (objectFader != null)
                {
                    objectFader.DoFade = false;
                }
            }
        }
    }
}    

