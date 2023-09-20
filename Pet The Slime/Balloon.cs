using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    ScoreKeeper scoreKeeper;
    BalloonCounter balloonCounter;

    [SerializeField] float deathPets;
    [SerializeField] float clickPets;
    [SerializeField] float speed;

    Rigidbody2D rb;

    [SerializeField] float health;

    ParticleSystem particleSystem;

    bool isDead;

    private void Awake()
    {
        isDead = false;
        scoreKeeper = ScoreKeeper.Instance;
        balloonCounter = BalloonCounter.Instance;
        rb = GetComponent<Rigidbody2D>();
        particleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= 7)
            Destroy(gameObject);
        rb.velocity = transform.up * speed * Time.deltaTime;
    }

    private void OnMouseDown()
    {
        health -= balloonCounter.GetDmg();
        if (health < 1 && !isDead)
        {
            isDead = true;
            particleSystem.Play();
            PlayPopSound();
            scoreKeeper.IncScoreBalloons(deathPets);
            balloonCounter.BalloonPopped();
            GetComponent<SpriteRenderer>().sprite = null;
            StartCoroutine(Destroy());
        }
        else
        {
            scoreKeeper.IncScoreBalloons(clickPets);
        }
    }
    void PlayPopSound()
    {
        AudioManager.Instance.PlaySound(3);
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(.5f);
        Destroy(gameObject);
    }
}
