using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour, IDataPersistance
{
    [Header("Jumping")]
    Rigidbody2D rb;
    CircleCollider2D cc;
    [SerializeField] float jumpForce;
    [SerializeField] float jumpVariance;

    [Header("Shrinking")]
    Vector3 baseScale;
    Vector3 shrinkScale = new Vector3(.2f, .2f, .2f);
    [SerializeField] float shrinkSpeed = .01f;
    [SerializeField] float shrinkSeconds = .75f;
    [SerializeField] bool isShrunk = false;
    [SerializeField] bool isGrowing = false;

    [Header("Cosmetic")]
    [SerializeField] Sprite[] images;
    public int imageIndex;
    SpriteRenderer sr;


    AudioManager audioManager;
    ScoreKeeper scoreKeeper;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cc = GetComponent<CircleCollider2D>();
        baseScale = transform.localScale;
        audioManager = AudioManager.Instance;
        scoreKeeper = ScoreKeeper.Instance;
    }


    private void OnMouseDown()
    {
        scoreKeeper.IncScore(1);
        int rng = Random.Range(1, 101);//1-100
        //Debug.Log(rng);
        if (rng >= 90)
        {
            Jump();
        }
        else if (rng < 90 && rng >= 80)
        {
            if (isShrunk)
            {
                StartCoroutine(Regrow());
            }
            else
            {
                StartCoroutine(Shrink());
            }
        }

    }

    void Jump()
    {
        if (rb.velocity.y == 0)
        {
            float rndJmpFce = Random.Range(jumpForce - jumpVariance, jumpForce + jumpVariance);
            rb.AddForce(transform.up * rndJmpFce);
            audioManager.PlaySound(0);
        }
    }

    IEnumerator Shrink()
    {
        if (isGrowing)
            yield break;
        isGrowing = true;
        audioManager.PlaySound(2);
        while (transform.localScale != shrinkScale)
        {
            transform.localScale -= new Vector3(1 * shrinkSpeed, 1 * shrinkSpeed, 1 * shrinkSpeed);
            yield return new WaitForSeconds(shrinkSeconds);
        }
        isGrowing = false;
        isShrunk = true;
    }

    IEnumerator Regrow()
    {
        if (isGrowing)
            yield break;
        isGrowing = true;
        audioManager.PlaySound(1);
        while (transform.localScale != baseScale)
        {
            transform.localScale += new Vector3(1 * shrinkSpeed, 1 * shrinkSpeed, 1 * shrinkSpeed);
            yield return new WaitForSeconds(shrinkSeconds);
        }
        isGrowing = false;
        isShrunk = false;
    }

    public void InvertCC()
    {
        cc.enabled ^= true;
    }

    public void NextSlime()
    {
        imageIndex++;
        if (imageIndex >= images.Length)
            imageIndex = 0;
        sr.sprite = images[imageIndex];
    }

    public void LoadData(GameData data)
    {
        imageIndex = data.milestoneInd;
        if (data.currentSlime != null)
            sr.sprite = data.currentSlime;
    }
    public void SaveData(ref GameData data)
    {
        data.currentSlime = sr.sprite;
    }

}
