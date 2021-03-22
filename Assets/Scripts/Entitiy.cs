using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entitiy : MonoBehaviour
{
    int currentHealth;
    int maxHealth;
    SpriteRenderer spriteRenderer;
    bool isInvincible;
    float durationInvincibility;

    private void Awake()
    {
        currentHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    public abstract void Interact();

    public  void ReceiveDamage()
    {
        if (!isInvincible)
        {
            currentHealth--;
            if (currentHealth > 0)
            {
                StartCoroutine(InvincibilityCoroutine(durationInvincibility));
            }
            else
            {
                Die();
            }
        }
        

    }
    private IEnumerator InvincibilityCoroutine(float duration)
    {
        // setup
        spriteRenderer.color = Color.red;
        isInvincible = true;

        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            spriteRenderer.color = Color.Lerp(Color.red, Color.white, t / duration);
            yield return null;
        }

        // reset
        spriteRenderer.color = Color.white;
        isInvincible = false;
    }

    public abstract void Die();




}
