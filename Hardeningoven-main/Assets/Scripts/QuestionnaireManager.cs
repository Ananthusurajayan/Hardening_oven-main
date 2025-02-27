using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class KeyenceQuestionnaireManager : MonoBehaviour
{
    // Public references to UI elements in Unity Editor
    public Text questionText;
    public Button trueButton;
    public Button falseButton;
    public GameObject feedbackPanel;
    public Text feedbackText;
    public GameObject certificatePanel;
    public Text certificateText;
    public GameObject congratulationPanel;
    public Text congratulationText;
    public GameObject questionnairePanel;
    public Button goToQuestionnaireButton;
    public Button retryButton;

    // Array to hold questions
    private Question[] questions;
    private int currentQuestionIndex = 0;

    void Start()
    {
        // Define your questions and answers specific to Keyence laser scanning machine
        questions = new Question[] {
            new Question("Is it necessary to calibrate the Keyence laser scanner before use?", true),
            new Question("Can the Keyence laser scanner operate safely without proper grounding?", false),
            new Question("Is it important to clean the lens of the laser scanner regularly?", true),
            new Question("Should the laser scanner be operated without a safety enclosure?", false),
            new Question("Can the laser scanner measure objects with reflective surfaces without any issues?", false),
            new Question("Is training required before using the Keyence laser scanning machine?", true),
            new Question("Should the power supply be turned off before performing maintenance on the laser scanner?", true)
        };

        // Initialize UI elements
        questionnairePanel.SetActive(false);
        feedbackPanel.SetActive(false);
        certificatePanel.SetActive(false);
        congratulationPanel.SetActive(false);
        retryButton.gameObject.SetActive(false);

        // Assign button click events
        goToQuestionnaireButton.onClick.AddListener(StartQuestionnaire);
        retryButton.onClick.AddListener(RetryQuestion);
        trueButton.onClick.AddListener(SubmitTrue);
        falseButton.onClick.AddListener(SubmitFalse);
    }

    void StartQuestionnaire()
    {
        currentQuestionIndex = 0;
        DisplayQuestion(questions[currentQuestionIndex]);
        questionnairePanel.SetActive(true);
        goToQuestionnaireButton.gameObject.SetActive(false);
        feedbackPanel.SetActive(false);
        retryButton.gameObject.SetActive(false);
    }

    public void SubmitTrue()
    {
        SubmitAnswer(true);
    }

    public void SubmitFalse()
    {
        SubmitAnswer(false);
    }

    public void SubmitAnswer(bool playerAnswer)
    {
        bool correctAnswer = questions[currentQuestionIndex].correctAnswer;

        if (playerAnswer == correctAnswer)
        {
            ShowFeedback("Correct!", Color.green);
            StartCoroutine(HideFeedbackAfterDelay(true));
        }
        else
        {
            ShowFeedback("Incorrect!", Color.red);
            StartCoroutine(HideFeedbackAfterDelay(false));
        }
    }

    IEnumerator HideFeedbackAfterDelay(bool isCorrect)
    {
        yield return new WaitForSeconds(2f);
        feedbackPanel.SetActive(false);

        if (isCorrect)
        {
            NextQuestion();
        }
        else
        {
            retryButton.gameObject.SetActive(true);
        }
    }

    void NextQuestion()
    {
        currentQuestionIndex++;
        if (currentQuestionIndex < questions.Length)
        {
            DisplayQuestion(questions[currentQuestionIndex]);
        }
        else
        {
            ShowCertificate();
            ShowCongratulation();
        }
    }

    void DisplayQuestion(Question question)
    {
        questionText.text = question.questionText;
        questionText.gameObject.SetActive(true);
        feedbackPanel.SetActive(false);
        retryButton.gameObject.SetActive(false);
    }

    void ShowFeedback(string message, Color color)
    {
        feedbackText.text = message;
        feedbackText.color = color;
        feedbackPanel.SetActive(true);
        questionText.gameObject.SetActive(false);
        retryButton.gameObject.SetActive(false);
    }

    void ShowCertificate()
    {
        certificateText.text = "Congratulations! You answered all questions correctly.";
        certificatePanel.SetActive(true);
        questionnairePanel.SetActive(false);
    }

    void ShowCongratulation()
    {
        congratulationText.text = "Great job! You have completed the Keyence laser scanning machine questionnaire.";
        congratulationPanel.SetActive(true);
    }

    void RetryQuestion()
    {
        DisplayQuestion(questions[currentQuestionIndex]);
        feedbackPanel.SetActive(false);
        retryButton.gameObject.SetActive(false);
    }

    // Definition of the Question class
    private class Question
    {
        public string questionText;
        public bool correctAnswer;

        public Question(string questionText, bool correctAnswer)
        {
            this.questionText = questionText;
            this.correctAnswer = correctAnswer;
        }
    }
}