using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public static GameController instancia;

    
    [SerializeField] float incrementoMeta;
    [SerializeField] Text textoScore;
    float meta;
    int score;
    

    private void Awake()
    {
        if (instancia == null) instancia = this;
        else if (instancia != this) Destroy(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        AtualizaHUD();
        meta = Mathf.Log(meta + incrementoMeta, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            score += 1;
            AtualizaHUD();
        }

        if (score >= meta)
        {
            meta += Mathf.Log(meta + incrementoMeta, 2f) * 10;
            SceneManager.LoadScene("Level02");
        }
    }

    void AtualizaHUD()
    {
        textoScore.text = "Noot noot: " + score;
    }
}
