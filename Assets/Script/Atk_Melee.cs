using UnityEngine;
using System.Collections;

public class Atk_Melee : MonoBehaviour {

    #region DECLARATION
    // CONST
    private const float DEFAULT_HIT_COOLDOWN = 1.0f;
    private const float DEFAULT_HIT_DURATION = 0.5f;

    // PRIVATE
    private MeshCollider MeleeTrigger;

    private float hitDurationTimer;
    private float hitCooldownTimer;

    private bool canHit;
    private bool isHitting;

    // PUBLIC

    #endregion

    #region UNITY METHODE
    void Awake ()
    {
        MeleeTrigger = gameObject.transform.FindChild("Melee_Trigger").GetComponent<MeshCollider>();
    }

	void Start ()
    {
        MeleeTrigger.enabled = false;
        canHit = true;
	}

	void Update ()
    {
        VerifyInput();

        TryUpdateAllTimer();
	}
    #endregion


    private void VerifyInput()
    {
        // Primary mouse button
        if (Input.GetMouseButton(0))
        {
            if (canHit)
            {
                Hit();
            }
        }
    }

    private void Hit()
    {
        MeleeTrigger.enabled = true;
        isHitting = true;
        canHit = false;

        hitCooldownTimer = DEFAULT_HIT_COOLDOWN;
    }

    #region TIMER METHODE
    private void TryUpdateAllTimer()
    {
        if (!canHit)
        {
            if (isHitting)
            {
                UpdateHitDurationTimer();
            }

            UpdateHitCooldownTimer();
        }
    }


    private void UpdateHitDurationTimer()
    {
        hitDurationTimer += Time.deltaTime;

        if (hitDurationTimer >= DEFAULT_HIT_DURATION)
        {
            hitDurationTimer = 0;
            MeleeTrigger.enabled = false;
            isHitting = false;
        }
    }

    private void UpdateHitCooldownTimer()
    {
        hitCooldownTimer -= Time.deltaTime;

        if (hitCooldownTimer <= 0)
        {
            hitCooldownTimer = 0;
            canHit = true;
        }
    }
    #endregion
}