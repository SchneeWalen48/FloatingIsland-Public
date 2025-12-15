using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCFollow : MonoBehaviour
{
    public GameObject ThePlayer;
    public float TargetDistace;
    public float AllowedDistance = 7;
    public GameObject TheNPC;
    public float followSpeed;
    public RaycastHit Shot;

    [SerializeField]
    public float jumpForce;

    private Rigidbody NPCRigid;

    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        NPCRigid = GetComponent<Rigidbody>();
    }
    void Update()
    {

        //if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot))
        {
            Vector3 playerPos = ThePlayer.transform.position;
            playerPos.y = transform.position.y; // hy : npc가 시선을 들지 않게끔 맞춰줌

            transform.LookAt(playerPos, Vector3.up);
            TargetDistace = Vector3.Distance(ThePlayer.transform.position, transform.position); // hy : 두 위치 거리 구하는 함수
            //TargetDistace = Shot.distance;

            Vector3 direction = (ThePlayer.transform.position - transform.position).normalized; // hy : 길이가 1인 노멀벡터
            //Debug.Log(NPCRigid.velocity.magnitude);
            if (TargetDistace >= AllowedDistance * 10)
            {
                transform.position = playerPos - new Vector3(0, 0, 1);
                //animator.SetBool("walk", true);
            }
            else if(TargetDistace >= AllowedDistance * 2.6)
            {
                NPCRigid.AddForce((direction) * followSpeed * 1.2f);
                animator.SetBool("walk", true);
            }
            else if (TargetDistace >= AllowedDistance)
            {
                //followSpeed = 2f;
                NPCRigid.AddForce((direction) * followSpeed); // hy : 포지션을 바꾸는 것보다 rigidbody 힘쓰는 게 자연스러운듯
                animator.SetBool("walk", true);
                //transform.position = Vector3.MoveTowards(transform.position, ThePlayer.transform.position, followSpeed);
                //Debug.Log("따라오는 중"); //만약에 플레이어와 npc와의 거리가 5보다 크면 npc가 플레이어의 위치를 계산해서 그쪽으로 이동함. 5보다 작으면 가까이 있다고 판단해서 멈춤.
                //여기에 걷는 애니메이션 추가해야 함. TheNPC.GetComponent<Animation>().Play("running");
            }
            
            else
            {
                animator.SetBool("walk", false);
                //followSpeed = 0;
                //Debug.Log("가만히 있는 중");
                //여기에 가만히 있는 애니메이션 추가해야 함. TheNPC.GetComponent<Animation>().Play("idle");
            }

            if (ThePlayer.GetComponent<PlayerController>().isJump == true)
            {
                //Debug.Log("뛴다");
                animator.SetBool("jump", true);
            }
            else 
            {
                //Debug.Log("안뛴다");
                animator.SetBool("jump", false);
            }
        }
        // 여기에 플레이어가 점프하면 NPC도 같이 점프하는 코드를 만들지 말지 고민중임,, 만든다면 플레이어컨트롤러에 있는 점프코드 가져와서 플레이어 뛰면 NPC도 그만큼 같이 뛰게 설정. 
    }

}
