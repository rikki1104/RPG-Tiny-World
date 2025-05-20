using System.Collections;
using System.Collections.Generic;
using RPG.Attributes;
using UnityEngine;

namespace RPG.Combat
{
    public class DestroyOnDeath : MonoBehaviour
    {
        [SerializeField] float decayTime = 10f;
        Health health;

        // Start is called before the first frame update
        void Start()
        {
            health = GetComponent<Health>();
        }

        // Update is called once per frame
        void Update()
        {
            StartCoroutine(DeathDecayTime());
        }

        private IEnumerator DeathDecayTime()
        {
            if (health.IsDead())
            {
                yield return new WaitForSeconds(decayTime);
                Destroy(gameObject);
            }
        }
    }
}
