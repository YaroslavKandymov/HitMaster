using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] private PlayerMover _player;

    private void OnEnable()
    {
        _player.PathEnded += OnPathEnded;
    }

    private void OnDisable()
    {
        _player.PathEnded -= OnPathEnded;
    }

    private void OnPathEnded()
    {
        Restart();
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
