using UnityEngine;

public class HitAndReviveNPC : MonoBehaviour
{
    public Animator animator;
    public GameObject reviveTriggerZone;
    public float reviveDuration = 3f;

    private bool isDown = false;
    private bool isBeingRevived = false;
    private float reviveTimer = 0f;

    void Start()
    {
        if (reviveTriggerZone != null)
            reviveTriggerZone.SetActive(false);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!isDown && collision.gameObject.CompareTag("Car"))
        {
            Debug.Log("NPC Hit by Car!");
            isDown = true;

            if (animator != null)
                animator.SetTrigger("Stunned");

            if (reviveTriggerZone != null)
                reviveTriggerZone.SetActive(true);
        }
    }

    public void StartRevive()
    {
        isBeingRevived = true;
        reviveTimer = 0f;
    }

    public void StopRevive()
    {
        isBeingRevived = false;
        reviveTimer = 0f;
    }

    void Update()
    {
        if (isBeingRevived && isDown)
        {
            reviveTimer += Time.deltaTime;

            if (reviveTimer >= reviveDuration)
            {
                isDown = false;

                if (animator != null)
                    animator.Play("Idle"); // Go back to Idle state

                Debug.Log("NPC Revived!");

                if (reviveTriggerZone != null)
                    reviveTriggerZone.SetActive(false);

                isBeingRevived = false;
            }
        }
    }
}
