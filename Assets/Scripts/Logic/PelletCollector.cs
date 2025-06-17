using System;
using UnityEngine;
using TMPro;

public class PelletCollector : MonoBehaviour
{
    public static PelletCollector Instance;
    
    private PelletSpawner _pelletSpawner;
    private GameController _gameController;
    private AudioSource _audioSource;

    [SerializeField] private TextMeshProUGUI _counter;

    private int _numberToCollect;
    private int _numberCollected;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;            
        }

        _gameController = GetComponent<GameController>();
        _pelletSpawner = GetComponent<PelletSpawner>();
        _audioSource = GetComponent<AudioSource>();

        if (_counter == null)
        {
            _counter = GetComponentInChildren<TextMeshProUGUI>();
        }

        if (_counter == null)
        {
            Debug.LogError("PelletCollector: _counter is not assigned! Please assign it in the Inspector.");
        }
    }

    private void Start()
    {
        if (_pelletSpawner != null)
        {
            _numberToCollect = _pelletSpawner.NumberToSpawn;
        }
        else
        {
            Debug.LogError("PelletCollector: _pelletSpawner is null!");
        }
    }

    public void ResetCounter()
    {
        _numberCollected = 0;
        if (_counter != null)
        {
            _counter.text = "0";
        }
        else
        {
            Debug.LogError("PelletCollector: Cannot reset counter text because _counter is null.");
        }
    }

    public void PelletCollected()
    {
        if (_audioSource != null)
        {
            _audioSource.PlayOneShot(_audioSource.clip);
        }

        _numberCollected++;

        if (_counter != null)
        {
            _counter.text = _numberCollected.ToString();
        }

        if (_numberCollected >= _numberToCollect && _gameController != null)
        {
            _gameController.EndGame();
        }
    }
}
