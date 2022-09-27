using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class AmbienceController : MonoBehaviour
{
    [Header("References")]
    public Animator ratAnim;
    public Animator gemAnim;
    public CinemachineVirtualCamera VCam;
    public GameObject gemAnimObject;

    private PlayerMovement player;
    public AnimationEndAlert alert;    

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        alert = FindObjectOfType<AnimationEndAlert>();
    }

    // Update is called once per frame
    void Update()
    {
        if (alert.message == "animation ended")
        {
            gemAnim.gameObject.SetActive(false);
            VCam.m_Follow = player.transform;
            player.canMove = true;
            player.speed = 8;
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            ratAnim.Play("Base Layer.BG_RAT_1");
            StartCoroutine(GemAnimation());
        }   
    }

    IEnumerator GemAnimation()
    {
        VCam.m_Follow = gemAnimObject.transform;
        player.animator.SetFloat("Horizontal", 0);
        player.canMove = false;
        player.dir = Vector2.zero;
        player.rb2d.velocity = Vector2.zero;
        gemAnim.Play("Base Layer.LookAtGemAnim-1");
        yield return null;
    }
}
