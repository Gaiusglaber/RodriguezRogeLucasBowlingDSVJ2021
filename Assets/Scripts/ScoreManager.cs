using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public CameraMovement cameracomp;
    public Instantiator instance;
    public List<TMPro.TMP_Text> scores;
    private int it=0;
    private bool numberthrow = true;
    public List<int> score;
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
            else
            {
                scores[it].text = score[it].ToString();
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
        anotateScore();
        updateIt();
    }
}
