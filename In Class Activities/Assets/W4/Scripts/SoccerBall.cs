using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SoccerBall : MonoBehaviour
{
    [SerializeField] private TMP_Text _pointsText;
    [SerializeField] private TMP_Text _timeText;
    [SerializeField] private ParticleSystem _goalVFX;

    // STEP 5 -----------------------------------------------------------------
    // Create a new member variable to keep track of the points.
    private int _points = 0;

    // STEP 6 -----------------------------------------------------------------
    // Create a time variable to track how long it's been since the last goal.
    private float _timeSinceLastGoal = 0f;

    // STEP 1 -----------------------------------------------------------------
    // The OnTriggerEnter method is a collision method called by Unity that
    //      tells our object when it's hit a collider with Is Trigger checked.
    private void OnTriggerEnter(Collider other)
    {
        // STEP 2 -------------------------------------------------------------
        // Write an IF STATEMENT to check if the game object we collided with
        //      has the tag "Goal".
        if (other.CompareTag("Goal"))
        {
            // When we hit a Goal, call MadeGoal method
            MadeGoal();
        }
        // STEP 2 -------------------------------------------------------------
    }
    // STEP 1 -----------------------------------------------------------------

    // STEP 3 -----------------------------------------------------------------
    // Next, we're going to make a method named MadeGoal to call if the
    //      SoccerBall collided with an object tagged "Goal".
    // MadeGoal RETURNS NOTHING, and has NO INPUT.
    private void MadeGoal()
    {
        // STEP 4 -------------------------------------------------------------
        // _goalVFX is a ParticleSystem, a Component for creating VFX.
        // ParticleSystem has a method named Play() that displays the VFX.
        if (_goalVFX != null)
        {
            _goalVFX.Play();
        }
        // STEP 4 -------------------------------------------------------------

        // STEP 5 -------------------------------------------------------------
        // Update points and show the new score on the screen.
        _points++;
        if (_pointsText != null)
        {
            _pointsText.text = "Points: " + _points.ToString();
        }
        // STEP 5 -------------------------------------------------------------

        // STEP 6 -------------------------------------------------------------
        // Reset the time counter when we make a goal.
        _timeSinceLastGoal = 0f;
        // STEP 6 -------------------------------------------------------------
    }
    // STEP 3 -----------------------------------------------------------------

    // STEP 6 -----------------------------------------------------------------
    // Keep track of time every frame and update the text.
    private void Update()
    {
        _timeSinceLastGoal += Time.deltaTime;
        if (_timeText != null)
        {
            _timeText.text = "Time Since Last Goal: " + _timeSinceLastGoal.ToString("F2") + "s";
        }
    }
    // STEP 6 -----------------------------------------------------------------
}
