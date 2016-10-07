using UnityEngine;
using System.Collections;

public class PlayerMotor : MonoBehaviour {

    #region DECLARATION
    // CONST
    private const float DEFAULT_MOVE_SPEED = 0.4f;
    private const float DEFAULT_ROTATION_SPEED = 5.0f;

    private const float JOYSTICK_DEADZONE = 0.1f;
    private const string NO_JOYSTICK_CONNECTED = "NullInputDevice";

    // PRIVATE
    private CharacterController thisCharacterController;
    private Vector3 mousePosition;

    private float moveSpeed;
    private float rotationSpeed;

    private float moveX;
	private float moveZ;
    private float faceX;
    private float faceZ;
    private float rotationTransition;

    private bool isKeyboardControl;

    // PUBLIC

    #endregion

    #region UNITY METHODE
    void Awake ()
    {
        thisCharacterController = gameObject.GetComponent<CharacterController>();
    }

    void Start ()
    {
        moveSpeed = DEFAULT_MOVE_SPEED;
        rotationSpeed = DEFAULT_ROTATION_SPEED;
    }

	void Update () 
	{
        VerifyActiveDevice();
    }

    void FixedUpdate ()
    {
        bool isFacingDifferentSide;

        Move();

        // Verify if the player try to look in another way
        isFacingDifferentSide = VerifyFacingAway();

        // Set the right rotation when needed
        PlayerRotate(isFacingDifferentSide);
    }
    #endregion


    #region MOUVEMENT METHODE
    private void Move()
    {
        UpdateMovingInput();

        // Reset input value if in deadzone
        VerifyDeadZone(moveX, moveZ, true);

        // Player movement
        thisCharacterController.Move(new Vector3(moveX * moveSpeed, 0, moveZ * moveSpeed));
    }

    private void UpdateMovingInput()
    {
        if (isKeyboardControl)
        {
            moveX = Input.GetAxisRaw("Horizontal");
            moveZ = Input.GetAxisRaw("Vertical");
        }
        else
        {
            moveX = InControl.InputManager.ActiveDevice.LeftStickX.Value;
            moveZ = InControl.InputManager.ActiveDevice.LeftStickY.Value;
        }
    }
    #endregion

    #region FACING_AWAY METHODE
    private bool VerifyFacingAway()
    {
        UpdateFacingInput();

        // Reset input value if in deadzone
        VerifyDeadZone(faceX, faceZ, false);

        return ConclusionFacingAway();
    }

    private void UpdateFacingInput()
    {
        if (isKeyboardControl)
        {
            UpdateMousePos();

            faceX = mousePosition.x;
            faceZ = mousePosition.z;
        }
        else
        {
            faceX = InControl.InputManager.ActiveDevice.RightStickX.Value;
            faceZ = InControl.InputManager.ActiveDevice.RightStickY.Value;
        }
    }

    private void UpdateMousePos()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            mousePosition = hit.point - transform.position;
        }
    }

    private bool ConclusionFacingAway()
    {
        bool isFacingDifferentSide = false;

        // Verification...
        if (faceX != 0 || faceZ != 0)
        {
            isFacingDifferentSide = true;
        }
        else
        {
            isFacingDifferentSide = false;
        }

        return isFacingDifferentSide;
    }
    #endregion

    #region ROTATION METHODE
    private void PlayerRotate(bool isFacingDifferentSide)
    {
        if (isFacingDifferentSide)
        {
            Rotating(faceX, faceZ);
        }
        else
        {
            // Rotate if the player is moving
            if (moveX != 0 || moveZ != 0)
            {
                Rotating(moveX, moveZ);
            }
        }
    }

    private void Rotating(float input_x, float input_z)
    {
        // The rotation wanted.
        Quaternion newRotation = Quaternion.Euler
            (transform.eulerAngles.x, (Mathf.Atan2(input_x, input_z) * Mathf.Rad2Deg), transform.eulerAngles.z);

        // Lerping to the wanted rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * rotationSpeed);
    }
    #endregion


    #region VERIFICATION METHODE
    private void VerifyDeadZone(float input_x, float input_z, bool isTestingMove)
    {
        if (input_x > JOYSTICK_DEADZONE * -1 && input_x < JOYSTICK_DEADZONE)
        {
            if (isTestingMove)
            {
                moveX = 0;
            }
            else
            {
                faceX = 0;
            }
        }

        if (input_z > JOYSTICK_DEADZONE * -1 && input_z < JOYSTICK_DEADZONE)
        {
            if (isTestingMove)
            {
                moveZ = 0;
            }
            else
            {
                faceZ = 0;
            }
        }
    }

    private void VerifyActiveDevice()
    {
        if (InControl.InputManager.ActiveDevice.Name == NO_JOYSTICK_CONNECTED)
        {
            isKeyboardControl = true;
        }
        else
        {
            isKeyboardControl = false;
        }
    }
    #endregion
}