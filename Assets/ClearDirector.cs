using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearDirector : MonoBehaviour
{
    private AudioSource click;
    [SerializeField] private AudioClip clip;

    void Start()
    {
        click = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("GameScene");
            click.Play();
        }
    }
}
