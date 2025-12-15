using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    static public bool isActivated = true;

    //스피드 조정 변수
    [SerializeField]
    private float walkSpeed;
    [SerializeField]
    public float runSpeed;
    [SerializeField]
    private float crouchSpeed;
    [SerializeField]
    private float swimSpeed;
    [SerializeField]
    private float swimFastSpeed;
    [SerializeField]
    private float upSwimSpeed;


    private float applySpeed;

    float currentVelocity = 0;

    //점프 조정 변수
    [SerializeField]
    public float jumpForce;

    //상태 변수
    public bool isRun = false;
    private bool isCrouch = false;
    private bool isGround = true;
    public bool isJump = false;
    public bool isMoving = false;

    //얼마나 앉을지 결정하는 변수
    [SerializeField]
    private float crouchPosY;
    private float originPosY;
    private float applyCrouchPosY;

    //땅 착지 여부
    private CapsuleCollider capsuleCollider;

    //민감도
    [SerializeField]
    private float lookSensitivity;

    //카메라 한계
    [SerializeField]
    private float cameraRotationLimit;
    private float currentCameraRotationX = 0;

    [SerializeField]
    private Camera theCamera;
    private Rigidbody myRigid;

    private int jumpCount = 0; // hy : 점프 횟수

    public AudioSource audioSrc;
    public AudioSource audioSrc2;
    public AudioSource d1;
    public AudioSource d2;
    public AudioSource d3;

    //public Animator animator;

    void Start()
    {
        //animator = GetComponent<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        myRigid = GetComponent<Rigidbody>();
        applySpeed = walkSpeed;
        originPosY = theCamera.transform.localPosition.y;
        applyCrouchPosY = originPosY;

    }


    void Update()
    {
        if (isActivated && GameManager.canPlayerMove)
        {
            WaterCheck();
            IsGround();
            TryJump();
            if (!GameManager.isWater)//물에 있으면 뛰지 못하게 설정.
            {
                TryRun();
            }
            TryCrouch();
            Move();
            if (!Inventory.inventoryActivated)
            {
                CameraRotation();
                CharacterRotation();
            }
            if (GameManager.isWater == true)
            {
                //Debug.Log("물속임");
            }
            else
            {
                //Debug.Log("물속아님");
            }
        }

        if (isGround && !GameManager.isWater)
        {
            if (currentVelocity <= -40)
            {
                Debug.Log("데미지 3칸");
                GameObject.Find("HealthController").GetComponent<HealthController>().TakeDamageThird(); //플레이어의 공중 속력를 업데이트로 계속 받아온 다음에 그 속도가 -18보다 작으면 땅에 닿았을 때 낙하 데미지를 입게 함. 아직은 피 반칸 닳게 했는데 나중에 거리에 따라 닳는 개수 다르게 받을 예정.
                d3.Play();
            }


            else if (currentVelocity > -40 && currentVelocity <= -30)
            {
                Debug.Log("데미지 2칸");
                GameObject.Find("HealthController").GetComponent<HealthController>().TakeDamageSecond();
                d2.Play();
            }

            else if (currentVelocity > -30 && currentVelocity <= -20)
            {
                Debug.Log("데미지 1칸");
                GameObject.Find("HealthController").GetComponent<HealthController>().TakeDamage();
                d1.Play();
            }


            currentVelocity = 0;
            
        }

        else 
        {
            //Debug.Log("데미지 없어");
            currentVelocity = myRigid.velocity.y;//플레이어가 공중에 떠 있을 경우의 속력의 y값을 변수에 넣어줌.
        }
        if (!isGround && !GameManager.isWater)
        {
            //Debug.Log("현재 속도" + currentVelocity);
            if (currentVelocity <= -100) // hy : 밖으로 탈출하면 죽음
            {
                Debug.Log("죽는 화면으로 이동");
                SceneManager.LoadScene("GameOver");
            }
        }

    }

    private void WaterCheck()
    {
        if (GameManager.isWater)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                applySpeed = swimFastSpeed;
            }
            else
            {
                applySpeed = swimSpeed;
            }
        }
    }

    private void TryCrouch()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Crouch();
        }
    }

    private void Crouch()
    {
        isCrouch = !isCrouch;

        if (isCrouch)
        {
            applySpeed = crouchSpeed;
            applyCrouchPosY = crouchPosY;
        }
        else
        {
            applySpeed = walkSpeed;
            applyCrouchPosY = originPosY;
        }

        StartCoroutine(CrouchCoroutine());
    }
    IEnumerator CrouchCoroutine()
    {
        float _posY = theCamera.transform.localPosition.y;
        int count = 0;

        while (_posY != applyCrouchPosY)
        {
            _posY = Mathf.Lerp(_posY, applyCrouchPosY, 0.3f);
            theCamera.transform.localPosition = new Vector3(0, _posY, 0.375f);
            if (count > 15)
                break;
            yield return null;
        }
        theCamera.transform.localPosition = new Vector3(0, applyCrouchPosY, 0.375f);
    }

    private void IsGround()
    {
        isGround = Physics.Raycast(transform.position, Vector3.down, capsuleCollider.bounds.extents.y + 0.1f);
        isJump = false;
    }


    private void TryJump() // hy : 이단 점프
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount == 0 && isGround && !GameManager.isWater)
        {
            Jump();
            
            //GameObject.FindWithTag("NPC").GetComponent<NPCFollow>().NPCJump();
            isJump = true;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 1 && !GameManager.isWater) // hy : 1->2로하면 삼단점프되는 이유를 모르겠음..
        {
            Jump();
            //GameObject.FindWithTag("NPC").GetComponent<NPCFollow>().NPCJump();
            isJump = true;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && GameManager.isWater)
        {
            UpSwim();
            isJump = true;
        }
        if (isGround)
        {
            jumpCount = 0;
            isJump = false;
            
        }
    }

    private void UpSwim()
    {
        myRigid.velocity = transform.up * upSwimSpeed;
    }

    public void Jump()
    {
        if (isCrouch)
            Crouch();
        jumpCount += 1;
        myRigid.velocity = transform.up * jumpForce;
        isJump = true;
        Debug.Log("점프했다");
    }

    private void TryRun()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Running();
            if (!audioSrc2.isPlaying && isGround)
                audioSrc2.Play();
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            RunningCancel();
            audioSrc2.Stop();
        }
    }

    //달리기 실행
    private void Running()
    {
        if (isCrouch)
            Crouch();
        isRun = true;
        applySpeed = runSpeed;

    }

    private void RunningCancel()
    {
        isRun = false;
        applySpeed = walkSpeed;
    }

    private void Move()
    {
        float _moveDirX = Input.GetAxisRaw("Horizontal");//입력 이뤄지면 키보드 방향키 ad로 입력한 값이 들어감.
        float _moveDirZ = Input.GetAxisRaw("Vertical");

        Vector3 _moveHorizontal = transform.right * _moveDirX;
        Vector3 _moveVertical = transform.forward * _moveDirZ;

        Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * applySpeed;
       

        if (_velocity.x != 0)
            isMoving = true;
        else
            isMoving = false;

        if (isMoving && !isRun && isGround && !GameManager.isWater)
        {
            //animator.SetBool("walk", true);
            if (!audioSrc.isPlaying)
                audioSrc.Play();
        }
        else
        {
            audioSrc.Stop();
            //animator.SetBool("walk", false);
        }
        //myRigid.MovePosition(transform.position + _velocity * Time.deltaTime);
        transform.Translate(_velocity * Time.deltaTime, Space.World); // hy : 이 함수 쓰면 속도 느려졌다 빨라졌다 하지 않음

        if(myRigid.velocity.magnitude > 1)
            //Debug.Log("캐릭터 속도 " + myRigid.velocity.magnitude);
        if (myRigid.velocity.y < 0)
        {
            myRigid.velocity -= new Vector3(0, myRigid.mass * Time.deltaTime, 0); // hy : 땅에서 떨어질 때 중력 가속
        }
    }

    private void CharacterRotation()
    {
        float _yRotation = Input.GetAxisRaw("Mouse X");
        Vector3 _characterRotationY = new Vector3(0f, _yRotation, 0f) * lookSensitivity;
        myRigid.MoveRotation(myRigid.rotation * Quaternion.Euler(_characterRotationY));
    }

    private void CameraRotation()
    {
        float _xRotation = Input.GetAxisRaw("Mouse Y");
        float _cameraRotationX = _xRotation * lookSensitivity;
        currentCameraRotationX -= _cameraRotationX;
        currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);

        theCamera.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f);
    }

}

