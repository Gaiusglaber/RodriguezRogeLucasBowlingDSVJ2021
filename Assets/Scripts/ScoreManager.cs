using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public CameraMovement cameracomp;
    public GameObject uigameover;
    public bool isfinished = false;
    public Instantiator instance;
    public List<TMPro.TMP_Text> scores;
    public int it=0;
    private bool numberthrow = true;
    public List<int> score;
    public int totalscore = 0;
    void anotateScore()
    {
        if (instance.pinesup == 0&&numberthrow)
        {
            instance.pinetext02.text = "STRIKE!";
            instance.pinetext01.text = " ";
        }else if(instance.pinesup == 0 && !numberthrow)
        {
            instance.pinetext02.text = "SPARE!";
            instance.pinetext01.text = " ";
        }
        else
        {
            instance.pinetext02.text = "Pines\n Left";

            instance.pinetext01.text = instance.pinesup.ToString();
        }
        if (cameracomp.reseteable)
        {
            if (!numberthrow)
            {
                score[it] = instance.pinesdown- score[it - 1];
            }
            else
            {
                score[it] = instance.pinesdown;
            }
            if (instance.pinesup == 0 && numberthrow)
            {
                scores[it].text = "X";
            }
            else if (instance.pinesup == 0 && !numberthrow)
            {
                scores[it].text = "/";
            }
            else if (numberthrow)
            {
                scores[it].text = score[it].ToString();
            }
            else
            {
                scores[it].text = score[it].ToString();
                if (scores[it-1].text == "X")
                {
                    score[it + 1] = 30;
                }
                else if (scores[it].text == "/")
                {
                    score[it + 1] = 20;
                }
                else
                {
                    score[it + 1]= (score[it - 1] + score[it]);
                }
                scores[it + 1].text = score[it + 1].ToString();
            }
        }
    }
    void updateIt()
    {
        if (cameracomp.resets)
        {
            if (scores[it].text == "X")
            {
                it += 2;
                numberthrow = false;
            }
            else
            {
                it++;
            }
            if (numberthrow)
            {
                numberthrow = false;
            }
            else
            {
                if (scores[it - 2].text == "X")
                {
                    scores[it].text = "30";
                    score[it] = 30;
                }
                else if (scores[it - 1].text == "/")
                {
                    scores[it].text = "20";
                    score[it] = 20;
                }
                else
                {
                    scores[it].text = "" + (score[it - 2] + score[it - 1]);
                }
                instance.deinit();
                instance.init();
                numberthrow = true;
                it++;
            }
            cameracomp.instantiate();
        }
    }
    void Start()
    {
        score.Capacity=scores.Count;
    }
    // Update is called once per frame
    void Update()
    {
        if (!isfinished) {
            if (it < 30)
            {
                anotateScore();
                updateIt();
            }
            else
            {
                for (short i = 0; i < 31; i++)
                {
                    if (i % 3 == 2||i==2)
                    {
                        totalscore += score[i];
                    }
                }
                isfinished = true;
                score[30] = totalscore;
                scores[30].text = "" + score[30];
            }
        }
        else
        {
            uigameover.SetActive(true);
        }
    }
}
