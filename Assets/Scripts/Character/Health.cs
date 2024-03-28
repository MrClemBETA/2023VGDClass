using Unity.VisualScripting;
using UnityEngine;

namespace SOS.AndrewsAdventure.Character
{
    public class Health : MonoBehaviour
    {
        [Min(10)]
        [SerializeField] public int maxHealth = 10;

        private int health;
        private float invincibilityTime = 1f;
        private float flashTime = .1f;

        private MeshRenderer mRenderer;
        private float elapsedITime = 0f;
        private float elapsedFlashTime = 0f;
        private bool isInvincible = false;
        private bool isRendered = true;

        void Awake()
        {
            health = maxHealth;
            mRenderer = GetComponent<MeshRenderer>();
        }

        void Update()
        {
            // Invincibility
            if(isInvincible)
            {
                elapsedITime += Time.deltaTime;
                elapsedFlashTime += Time.deltaTime;

                if(elapsedFlashTime > flashTime)
                {
                    isRendered = !isRendered;
                    mRenderer.enabled = isRendered;
                    elapsedFlashTime = 0f;
                }

                // End invincibility
                if(elapsedITime > invincibilityTime)
                {
                    isInvincible = false;
                    elapsedITime = 0;
                    mRenderer.enabled = true;
                    isRendered = true;
                }
            }
        }

        public void Heal(int health)
        {
            this.health = Mathf.Min(maxHealth, this.health + health);
        }

        public void TakeDamage(int damage)
        {
            if (transform.tag == "Player")
            {
                if (!isInvincible)
                {
                    isInvincible = true;
                    isRendered = false;
                    mRenderer.enabled = false;

                    health = Mathf.Max(0, health - damage);
                }
            }
        }

        public void SetMaxHealth(int health)
        {
            maxHealth = this.health = health;
        }
    }
}
