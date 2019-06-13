using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Projectiles.Effects
{

    public abstract class Effect : MonoBehaviour
    {
        public float effectRate = 1f;
        public int damage = 2;
        [Tooltip("What Visual Effect to Spawn as a child to the thing we hit")]
        public GameObject visualEffectPrefab;
        [HideInInspector] public Transform hitObject;

        private float effectTimer = 0f;

        protected virtual void Start()
        {
            GameObject clone = Instantiate(visualEffectPrefab, hitObject.transform);
            clone.transform.position = transform.position;
            clone.transform.rotation = transform.rotation;
        }

        // Update is called once per frame
        protected virtual void Update()
        {
            effectTimer += Time.deltaTime;
            if (effectTimer >= 1f / effectRate)
            {
                RunEffect();
            }
        }

        public abstract void RunEffect();
    }
}
