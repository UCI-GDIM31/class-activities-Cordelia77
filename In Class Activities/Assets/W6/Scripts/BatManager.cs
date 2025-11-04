using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BatManager : MonoBehaviour
{
    [SerializeField] private float _overlapDistance = 1.5f;
    [SerializeField] private float _interactDistance = 5f;
    [SerializeField] private float _timeBetweenNewMessages = 0.5f;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private TMP_Text _reactionUiPrefab;

    // STEP 1 -----------------------------------------------------------------
    [SerializeField] private BatW6[] _bats;
    // STEP 1 -----------------------------------------------------------------

    // STEP 3 -----------------------------------------------------------------
    [SerializeField] private string[] _messages;
    // STEP 3 -----------------------------------------------------------------

    [SerializeField] private float[] _newTextTimers;

    // ------------------------------------------------------------------------
    private void Start()
    {
        // STEP 6 -------------------------------------------------------------
        _newTextTimers = new float[_bats.Length];
        // STEP 6 -------------------------------------------------------------
    }

    // ------------------------------------------------------------------------
    private void Update()
    {
        // STEP 7 -------------------------------------------------------------
        for (int i = 0; i < _newTextTimers.Length; i++)
        {
            _newTextTimers[i] += Time.deltaTime;
        }
        // STEP 7 -------------------------------------------------------------

        // STEP 2 + 4 ---------------------------------------------------------
        for (int i = 0; i < _bats.Length; i++)
        {
            BatW6 bat = _bats[i];
            float distance = Vector3.Distance(bat.transform.position, _playerTransform.position);

            if (distance < _interactDistance)
                bat.StartChasing();
            else
                bat.StopChasing();

            if (distance < _overlapDistance)
                CreateReactions(bat);
        }
        // STEP 2 + 4 ---------------------------------------------------------
    }

    // ------------------------------------------------------------------------
    private void CreateReactions(BatW6 bat)
    {
        // STEP 5 -------------------------------------------------------------
        int randomIndex = Random.Range(0, _messages.Length);
        string randomMessage = _messages[randomIndex];
        SpawnReactionUI(bat, randomMessage);
        // STEP 5 -------------------------------------------------------------
    }

    // ------------------------------------------------------------------------
    private void SpawnReactionUI(BatW6 bat, string message)
    {
        // STEP 8 -------------------------------------------------------------
        int index = System.Array.IndexOf(_bats, bat);

        GridLayoutGroup layout = bat.GetComponentInChildren<GridLayoutGroup>();
        if (layout != null && _newTextTimers[index] >= _timeBetweenNewMessages)
        {
            _newTextTimers[index] = 0.0f;
            TMP_Text textObj = Instantiate(_reactionUiPrefab, layout.transform);
            textObj.text = message;
        }
        // STEP 8 -------------------------------------------------------------
    }
}
