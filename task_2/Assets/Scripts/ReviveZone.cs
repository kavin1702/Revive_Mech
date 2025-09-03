using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ReviveZone : MonoBehaviour
{
    private HitAndReviveNPC npcScript;

    [Header("UI References")]
    public GameObject Revive;               // "Press E to Revive" text panel
    public Image reviveFillImage;           // The fill bar UI Image
    public GameObject revivingText;         // "Reviving..." text panel

    [Header("Revive Settings")]
    public float reviveDuration = 2f;       // Total time to revive in seconds

    private float reviveTimer;
    private bool isReviving;

    void Start()
    {
        npcScript = GetComponentInParent<HitAndReviveNPC>();

        Revive.SetActive(false);
        reviveFillImage.fillAmount = 0f;
        reviveFillImage.transform.parent.gameObject.SetActive(false);
        if (revivingText != null)
            revivingText.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Revive.SetActive(true);
            Debug.Log("Player Entered Revive Zone");
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E) && !isReviving)
            {
                StartReviving();
            }

            if (isReviving)
            {
                reviveTimer += Time.deltaTime;
                reviveFillImage.fillAmount = reviveTimer / reviveDuration;

                if (reviveTimer >= reviveDuration)
                {
                    CompleteRevive();
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CancelRevive();
            Revive.SetActive(false);
            Debug.Log("Player Left Revive Zone");
        }
    }

    void StartReviving()
    {
        isReviving = true;
        reviveTimer = 0f;
        reviveFillImage.fillAmount = 0f;
        reviveFillImage.transform.parent.gameObject.SetActive(true);

        if (revivingText != null)
            revivingText.SetActive(true);
    }

    void CancelRevive()
    {
        isReviving = false;
        reviveTimer = 0f;
        reviveFillImage.fillAmount = 0f;
        reviveFillImage.transform.parent.gameObject.SetActive(false);

        if (revivingText != null)
            revivingText.SetActive(false);

        npcScript.StopRevive();
    }

    void CompleteRevive()
    {
        isReviving = false;
        reviveFillImage.fillAmount = 1f;
        reviveFillImage.transform.parent.gameObject.SetActive(false);

        if (revivingText != null)
            revivingText.SetActive(false);

        npcScript.StartRevive();
        Debug.Log("NPC Revived!");
    }
}
