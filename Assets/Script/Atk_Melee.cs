using UnityEngine;
using System.Collections;

public class Atk_Melee : MonoBehaviour {

    #region DECLARATION
    // CONST
    private const float DEFAULT_HIT_COOLDOWN = 1.0f;
    private const float DEFAULT_HIT_DURATION = 0.5f;

    // PRIVATE
    private PlayerMotor playerMotor;
    private MeshCollider MeleeTrigger;

    private float hitDurationTimer;
    private float hitCooldownTimer;

    private bool canHit;
    private bool isHitting;
    private bool isKeyboardControl;

    // PUBLIC

    #endregion

    #region UNITY METHODE
    void Awake ()
    {
        playerMotor = gameObject.GetComponent<PlayerMotor>();
        MeleeTrigger = gameObject.transform.FindChild("Melee_Trigger").GetComponent<MeshCollider>();
    }

	void Start ()
    {
        MeleeTrigger.enabled = false;
        canHit = true;
	}

	void Update ()
    {
        // Verify if listening to keyboard/mouse input or joystick input.
        isKeyboardControl = playerMotor.VerifyKeyboardUsage();

        VerifyInput();

        TryUpdateAllTimer();
	}
    #endregion


    private void VerifyInput()
    {
        if (isKeyboardControl)
        {
            // Primary mouse button
            if (Input.GetMouseButton(0))
            {
                TryHit();
            }
        }
        else
        {
            if (InControl.InputManager.ActiveDevice.LeftTrigger || 
                InControl.InputManager.ActiveDevice.RightTrigger)
            {
                TryHit();
            }
        }
    }

    private void TryHit()
    {
        if (canHit)
        {
            Hit();
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