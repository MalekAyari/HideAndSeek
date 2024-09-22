using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class Navigation : MonoBehaviour
{
    private Animator animator;

    [SerializeField] private float speed;

    private bool Patrolling = true;
    public Transform player;
    private NavMeshAgent agent;
    public bool playerVisible;
    public LayerMask targetMask;
    public LayerMask obstructionMask;
    public float radius;
    [Range(30, 160)]
    public float angle;

    public float patrolRange;
    public Transform centrePoint;

    private AudioSource src;
    public GameObject EmojiAngry;
    private bool angry = false;

    [Header("Events")]
    public GameEvent OnLose;
    
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        animator = GetComponent<Animator>();
        src = GetComponent<AudioSource>();
        StartCoroutine(FOVRoutine());
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }

        if (Patrolling)
        {
            if (playerVisible)
            {
                agent.SetDestination(player.transform.position);
                if (!angry)
                {
                    angry = true;
                    src.Play();
                    GameObject emoji = Instantiate(EmojiAngry, transform);
                    emoji.transform.Translate(new Vector3(0, 0, 3.5f));
                }
            }
            else if (!playerVisible)
            {
                if (agent.remainingDistance <= agent.stoppingDistance)
                {
                    if (angry)
                    {
                        angry = false;
                    }
                    Patrol();
                }
            }

            if (agent.velocity.magnitude <= 2f)
            {
                animator.Play("Idle");
            }
            else
            {
                animator.Play("Run");
            }
        }
        
    }

    private IEnumerator FOVRoutine(){
        WaitForSeconds wait = new WaitForSeconds(0.2f);
        
        while (true){
            yield return wait;
            FieldOfViewCheck();
        }
    
    }

    private void FieldOfViewCheck(){
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);
        if (rangeChecks.Length != 0){

            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2){

                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask)){
                    playerVisible = true;
                }
                else {
                    playerVisible = false;
                }

            }
            else {
                playerVisible = false;
            }
            
        }
        else if (playerVisible) {
            playerVisible = false;
        }
    }

    private void Patrol(){
        
        if (agent.remainingDistance <= agent.stoppingDistance){
            Vector3 point;

            if (RandomPoint(centrePoint.position, patrolRange, out point)){
                Debug.DrawRay(point, Vector3.up, Color.blue, 1.0F);
                agent.SetDestination(point);
                animator.Play("Run");
            }
        }

    }

    bool RandomPoint(Vector3 center, float range, out Vector3 result){
        
        Vector3 randomPoint = center + Random.insideUnitSphere * range;
        NavMeshHit hit;
        
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas)){
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;

    }

    

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player"){
            OnLose.Raise();
            Debug.Log("catching");
            agent.destination = transform.position;
        }
    }

    public void GameOver()
    {
        agent.destination = transform.position;
        Patrolling = false;
    }
}