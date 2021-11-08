using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Question[] questions;
    private static List<Question> unansweredQuestions = new List<Question>();

    [SerializeField] private Text questionText;
    [SerializeField] private Text aQuestionText;
    [SerializeField] private Text bQuestionText;
    [SerializeField] private Text cQuestionText;
    [SerializeField] private Text dQuestionText;
    [SerializeField] private Text trueA_answerText;
    [SerializeField] private Text trueB_answerText;
    [SerializeField] private Text trueC_answerText;
    [SerializeField] private Text trueD_answerText;

    [SerializeField] private float delay = 1f;

    [SerializeField] private Animator animator;

    private Question currentQuestion;

    private void Start()
    {
        if (unansweredQuestions == null || unansweredQuestions.Count==0)
        {
            unansweredQuestions = questions.ToList<Question>();                   
        }
        SetCurrentQuestion();
     
    }

    void SetCurrentQuestion()
    {
        int RandomQuestionIndex = Random.Range(0, unansweredQuestions.Count);
        currentQuestion = unansweredQuestions[RandomQuestionIndex];

        questionText.text = currentQuestion.question;
        aQuestionText.text = currentQuestion.answerA;
        bQuestionText.text = currentQuestion.answerB;
        cQuestionText.text = currentQuestion.answerC;
        dQuestionText.text = currentQuestion.answerD;

        if (currentQuestion.isA)
        {
            trueA_answerText.text = "CORRECT";
            trueB_answerText.text = "FALSE";
            trueC_answerText.text = "FALSE";
            trueD_answerText.text = "FALSE";
        }
        if (currentQuestion.isB)
        {
            trueA_answerText.text = "FALSE";
            trueB_answerText.text = "CORRECT";
            trueC_answerText.text = "FALSE";
            trueD_answerText.text = "FALSE";
        }
        if (currentQuestion.isC)
        {
            trueA_answerText.text = "FALSE";
            trueB_answerText.text = "FALSE";
            trueC_answerText.text = "CORRECT";
            trueD_answerText.text = "FALSE";
        }
        if (currentQuestion.isD)
        {
            trueA_answerText.text = "FALSE";
            trueB_answerText.text = "FALSE";
            trueC_answerText.text = "FALSE";
            trueD_answerText.text = "CORRECT";
        }


    }

    IEnumerator TransitionToNext()
    {
        unansweredQuestions.Remove(currentQuestion);
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void UserSelectA()
    {
        animator.SetBool("SelectedA",true);
        if (currentQuestion.isA)
        {
            Debug.Log("Correct");
        }
        else
        {
            Debug.Log("Wrong");
        }
        StartCoroutine(TransitionToNext());
    }
    public void UserSelectB()
    {
        animator.SetBool("SelectedB",true);
        if (currentQuestion.isB)
        {
            Debug.Log("Correct");
        }
        else
        {
            Debug.Log("Wrong");
        }
        StartCoroutine(TransitionToNext());
    }
    public void UserSelectC()
    {
        animator.SetBool("SelectedC",true);
        if (currentQuestion.isC)
        {
            Debug.Log("Correct");
        }
        else
        {
            Debug.Log("Wrong");
        }
        StartCoroutine(TransitionToNext());
    }
    public void UserSelectD()
    {
        animator.SetBool("SelectedD",true);
        if (currentQuestion.isA)
        {
            Debug.Log("Correct");
        }
        else
        {
            Debug.Log("Wrong");
        }
        StartCoroutine(TransitionToNext());
    }
}
