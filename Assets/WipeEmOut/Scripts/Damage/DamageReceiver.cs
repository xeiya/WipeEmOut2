using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DamageReceiver : MonoBehaviour
{
    [Tooltip("The maximum health this damage receiver can have")]
    public float healthMax;
    [Tooltip("What type of damage to ignore")]
    public Damage.Source immunity;
    //How much health this damage receiver has currently
    private float healthCurrent;
    [Tooltip("What to do after this damage receiver takes damage")]
    public UnityEvent onTakeDamage;
    [Tooltip("What to do after this damage receiver runs out of health")]
    public UnityEvent onHealthZero;

    [SerializeField] private Image healthBar;

    private void Start()
    {
        healthCurrent = healthMax;
    }

    /// <summary>
    /// Deal direct damage against the receiver, reducing current health by the given amount. If health is already at 0, this function does nothing.
    /// </summary>
    /// <param name="amount"></param>
    public void TakeDamage(float amount)
    {
        healthBar.fillAmount = GetHealthPercentage();

        //If we're already out of health, do nothing.
        if (healthCurrent <= 0)
            return;

        //Reduce health current by the given amount, never going below 0.
        healthCurrent = Mathf.Clamp(healthCurrent - amount, 0, healthMax);

        //Trigger the relevant listeners
        onTakeDamage.Invoke();

        //If we're completely out of health...
        if (healthCurrent <= 0)
        {
            //Trigger the relevant listeners
            onHealthZero.Invoke();
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        //If the thing we're overlapping is a damage source...
        if (collision.TryGetComponent<Damage>(out Damage source))
        {
            //If we're immune to this source,  do nothing
            if (source.source == immunity)
                return;

            //Take source's damage amount per second (damage over time)
            TakeDamage(source.amount * Time.fixedDeltaTime);    //We use fixedDeltaTime here because Trigger and Collision events only happen in the Physics loop
        }
    }

    private void OnParticleCollision(GameObject obj)
    {
        //If the particle that hit us is a damage source...
        if (obj.TryGetComponent<Damage>(out Damage source))
        {
            //If we're immune to this source,  do nothing
            if (source.source == immunity)
                return;

            //Take flat damage based on the source's damage amount 
            TakeDamage(source.amount);
        }
    }

    private float GetHealthPercentage() 
    { 
        return healthCurrent / healthMax;
    }
}
