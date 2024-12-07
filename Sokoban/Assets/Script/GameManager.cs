using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Box[] _boxes;

    public bool _isOver = false;
    public GameObject _winUI;

    private void Update()
    {
        int count = 0;

        if (_isOver)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(0);
        }

        foreach(var box in _boxes)
        {
            if (box._isGoal)
            {
                count++;
            }
        }
        if (count == _boxes.Length)
        {
            _isOver = true;
            _winUI.SetActive(true);
        }
    }
}
