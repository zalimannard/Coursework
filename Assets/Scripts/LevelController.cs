using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

enum PlayerDirection
{
    NORTH,
    EAST,
    SOUTH,
    WEST
}

[Serializable]
public class LevelController : MonoBehaviour
{
    [SerializeField] private string _levelId;
    [SerializeField] private ObjectStorage _objectStorage;
    [SerializeField] private Camera _camera;
    private int _finishCount = 0;
    private GameObject _player;
    private int playerI;
    private int playerJ;
    private double toRotate;
    private double toMove;
    private PlayerDirection _playerDirection = PlayerDirection.NORTH;
    private int[][] levelField;
    [SerializeField] private TMP_InputField codeField;
    private string[] programLines = new []{""};
    [SerializeField] private GameObject _playButton;
    private int currentLine = 0;
    [SerializeField] private GameObject win;
    [SerializeField] private GameObject task;
    [SerializeField] private GameObject pause;
    [SerializeField] private GameObject help;
    private bool taskFlag = false;


    [SerializeField] private GameObject[] _programersUi;

    private void Awake()
    {
        SetId(DataHolder.getLoadedLevel().ToString());
    }

    void Start()
    {
        codeField.text = DataHolder.getProgram();
        HidePanel();
        int[][] _levelField = LevelLoader.GetField(GetId());
        levelField = _levelField;
        for (int i = 0; i < _levelField.Length; ++i)
        {
            for (int j = 0; j < _levelField[0].Length; ++j)
            {
                if (_levelField[i][j] == 0)
                {

                }
                else if ((_levelField[i][j] > 49) && (_levelField[i][j] != 99))
                {
                    Instantiate(_objectStorage.GetGrass(), new Vector3(
                        i - _levelField.Length / 2,
                        0,
                        j - _levelField[0].Length / 2), Quaternion.identity);
                }
                else if (_levelField[i][j] > 0)
                {
                    Instantiate(_objectStorage.GetGround(), new Vector3(
                        i - _levelField.Length / 2,
                        0,
                        j - _levelField[0].Length / 2), Quaternion.identity);
                }
                else if (_levelField[i][j] < 0)
                {
                    Instantiate(_objectStorage.GetGameObject(_levelField[i][j]), new Vector3(
                        i - _levelField.Length / 2,
                        0,
                        j - _levelField[0].Length / 2), Quaternion.identity);
                }
            }
        }

        for (int i = 0; i < _levelField.Length; ++i)
        {
            for (int j = 0; j < _levelField[0].Length; ++j)
            {
                if (_levelField[i][j] == 4)
                {
                    ++_finishCount;
                }

                if (_levelField[i][j] == 99)
                {
                    _player = Instantiate(_objectStorage.GetGameObject(_levelField[i][j]), new Vector3(
                        i - _levelField.Length / 2,
                        1,
                        j - _levelField[0].Length / 2), Quaternion.identity);
                    playerI = i;
                    playerJ = j;
                    _levelField[i][j] = 99;
                }
                else if (_levelField[i][j] > 0)
                {
                    Instantiate(_objectStorage.GetGameObject(_levelField[i][j]), new Vector3(
                        i - _levelField.Length / 2,
                        1,
                        j - _levelField[0].Length / 2), Quaternion.identity);
                }
            }
        }

        _camera.transform.position = new Vector3((float) (_player.transform.position.x + 11.535),
            (float) (_player.transform.position.y + 14.02756),
            (float) (_player.transform.position.z - 11.465));
        _camera.transform.localPosition += _camera.transform.forward * 30;

        StartCoroutine(ExampleCoroutine());
    }


    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(5);
        ShowPanel();
    }

    public void StartProgram()
    {
        _playButton.SetActive(false);
        string program = codeField.text;
        programLines = program.Split("\n");
    }

    public void StopProgram()
    {
        DataHolder.setProgram(codeField.text);
        SceneManager.LoadScene("SampleScene");
    }

    public void returnToMenu()
    {
        DataHolder.setProgram(codeField.text);
        SceneManager.LoadScene("Levels");
    }

    public void showTask()
    {
        task.SetActive(true);
    }

    public void showPause()
    {
        pause.SetActive(true);
    }

    public void hideTask()
    {
        task.SetActive(false);
    }

    public void hidePause()
    {
        pause.SetActive(false);
    }

    public void Documentation()
    {
        rotRight();
    }

    public void HidePanel()
    {
        foreach (GameObject uiItem in _programersUi)
        {
            uiItem.SetActive(false);
        }
    }

    public void ShowPanel()
    {
        foreach (GameObject uiItem in _programersUi)
        {
            uiItem.SetActive(true);
        }
    }
    
    public void HideHelp()
    {
        help.SetActive(false);
    }

    public void ShowHelp()
    {
        help.SetActive(true);
    }
    
    public void Exit()
    {
        Application.Quit();
    }
    
    void Update()
    {
        if (levelField[playerI][playerJ] == 4)
        {
            levelField[playerI][playerJ] = -2;
            --_finishCount;
        }
        
        if ((isPlayerStand()) && (programLines.Length > 1))
        {
            if (currentLine < programLines.Length)
            {
                if (programLines[currentLine].Length == 0)
                {
                    ++currentLine;
                }
                else if (programLines[currentLine].StartsWith("//"))
                {
                    ++currentLine;
                }
                else if (programLines[currentLine].Equals("left()"))
                {
                    rotLeft();
                    ++currentLine;
                }
                else if (programLines[currentLine].Equals("right()"))
                {
                    rotRight();
                    ++currentLine;
                }
                else if (programLines[currentLine].Equals("moveForward()"))
                {
                    if (isForwardEmpty())
                    {
                        moveForward();
                        ++currentLine;
                    }
                    else
                    {
                        DataHolder.setProgram(codeField.text);
                        SceneManager.LoadScene("SampleScene");
                    }
                }
                else if (programLines[currentLine].Equals("moveBackward()"))
                {
                    if (isBackwardEmpty())
                    {
                        moveBackward();
                        ++currentLine;
                    }
                    else
                    {
                        DataHolder.setProgram(codeField.text);
                        SceneManager.LoadScene("SampleScene");
                    }
                }
                else if (programLines[currentLine].StartsWith("if"))
                {
                    string[] commands = programLines[currentLine].Split(" ");
                    if (commands[2].Equals("then"))
                    {
                        if (commands[1].Equals("isLeftEmpty()"))
                        {
                            if (isLeftEmpty())
                            {
                                if (commands[3].Equals("left()"))
                                {
                                    rotLeft();
                                }
                                else if (commands[3].Equals("right()"))
                                {
                                    rotRight();
                                }
                                else if (commands[3].Equals("moveForward()"))
                                {
                                    if (isForwardEmpty())
                                    {
                                        moveForward();
                                    }
                                    else
                                    {
                                        DataHolder.setProgram(codeField.text);
                                        SceneManager.LoadScene("SampleScene");
                                    }
                                }
                                else if (commands[3].Equals("moveBackward()"))
                                {
                                    if (isBackwardEmpty())
                                    {
                                        moveBackward();
                                    }
                                    else
                                    {
                                        DataHolder.setProgram(codeField.text);
                                        SceneManager.LoadScene("SampleScene");
                                    }
                                }
                            }
                        }
                        else if (commands[1].Equals("isRightEmpty()"))
                        {
                            if (isRightEmpty())
                            {
                                if (commands[3].Equals("left()"))
                                {
                                    rotLeft();
                                }
                                else if (commands[3].Equals("right()"))
                                {
                                    rotRight();
                                }
                                else if (commands[3].Equals("moveForward()"))
                                {
                                    if (isForwardEmpty())
                                    {
                                        moveForward();
                                    }
                                    else
                                    {
                                        DataHolder.setProgram(codeField.text);
                                        SceneManager.LoadScene("SampleScene");
                                    }
                                }
                                else if (commands[3].Equals("moveBackward()"))
                                {
                                    if (isBackwardEmpty())
                                    {
                                        moveBackward();
                                    }
                                    else
                                    {
                                        DataHolder.setProgram(codeField.text);
                                        SceneManager.LoadScene("SampleScene");
                                    }
                                }
                            }
                        }
                        else if (commands[1].Equals("isForwardEmpty()"))
                        {
                            if (isForwardEmpty())
                            {
                                if (commands[3].Equals("left()"))
                                {
                                    rotLeft();
                                }
                                else if (commands[3].Equals("right()"))
                                {
                                    rotRight();
                                }
                                else if (commands[3].Equals("moveForward()"))
                                {
                                    if (isForwardEmpty())
                                    {
                                        moveForward();
                                    }
                                    else
                                    {
                                        DataHolder.setProgram(codeField.text);
                                        SceneManager.LoadScene("SampleScene");
                                    }
                                }
                                else if (commands[3].Equals("moveBackward()"))
                                {
                                    if (isBackwardEmpty())
                                    {
                                        moveBackward();
                                    }
                                    else
                                    {
                                        DataHolder.setProgram(codeField.text);
                                        SceneManager.LoadScene("SampleScene");
                                    }
                                }
                            }
                        }
                        else if (commands[1].Equals("isBackwardEmpty()"))
                        {
                            if (isBackwardEmpty())
                            {
                                if (commands[3].Equals("left()"))
                                {
                                    rotLeft();
                                }
                                else if (commands[3].Equals("right()"))
                                {
                                    rotRight();
                                }
                                else if (commands[3].Equals("moveForward()"))
                                {
                                    if (isForwardEmpty())
                                    {
                                        moveForward();
                                    }
                                    else
                                    {
                                        DataHolder.setProgram(codeField.text);
                                        SceneManager.LoadScene("SampleScene");
                                    }
                                }
                                else if (commands[3].Equals("moveBackward()"))
                                {
                                    if (isBackwardEmpty())
                                    {
                                        moveBackward();
                                    }
                                    else
                                    {
                                        DataHolder.setProgram(codeField.text);
                                        SceneManager.LoadScene("SampleScene");
                                    }
                                }
                            }
                        }
                        else if (commands[1].Equals("!isLeftEmpty()"))
                        {
                            if (!isLeftEmpty())
                            {
                                if (commands[3].Equals("left()"))
                                {
                                    rotLeft();
                                }
                                else if (commands[3].Equals("right()"))
                                {
                                    rotRight();
                                }
                                else if (commands[3].Equals("moveForward()"))
                                {
                                    if (isForwardEmpty())
                                    {
                                        moveForward();
                                    }
                                    else
                                    {
                                        DataHolder.setProgram(codeField.text);
                                        SceneManager.LoadScene("SampleScene");
                                    }
                                }
                                else if (commands[3].Equals("moveBackward()"))
                                {
                                    if (isBackwardEmpty())
                                    {
                                        moveBackward();
                                    }
                                    else
                                    {
                                        DataHolder.setProgram(codeField.text);
                                        SceneManager.LoadScene("SampleScene");
                                    }
                                }
                            }
                        }
                        else if (commands[1].Equals("!isRightEmpty()"))
                        {
                            if (!isRightEmpty())
                            {
                                if (commands[3].Equals("left()"))
                                {
                                    rotLeft();
                                }
                                else if (commands[3].Equals("right()"))
                                {
                                    rotRight();
                                }
                                else if (commands[3].Equals("moveForward()"))
                                {
                                    if (isForwardEmpty())
                                    {
                                        moveForward();
                                    }
                                    else
                                    {
                                        DataHolder.setProgram(codeField.text);
                                        SceneManager.LoadScene("SampleScene");
                                    }
                                }
                                else if (commands[3].Equals("moveBackward()"))
                                {
                                    if (isBackwardEmpty())
                                    {
                                        moveBackward();
                                    }
                                    else
                                    {
                                        DataHolder.setProgram(codeField.text);
                                        SceneManager.LoadScene("SampleScene");
                                    }
                                }
                            }
                        }
                        else if (commands[1].Equals("!isForwardEmpty()"))
                        {
                            if (!isForwardEmpty())
                            {
                                if (commands[3].Equals("left()"))
                                {
                                    rotLeft();
                                }
                                else if (commands[3].Equals("right()"))
                                {
                                    rotRight();
                                }
                                else if (commands[3].Equals("moveForward()"))
                                {
                                    if (isForwardEmpty())
                                    {
                                        moveForward();
                                    }
                                    else
                                    {
                                        DataHolder.setProgram(codeField.text);
                                        SceneManager.LoadScene("SampleScene");
                                    }
                                }
                                else if (commands[3].Equals("moveBackward()"))
                                {
                                    if (isBackwardEmpty())
                                    {
                                        moveBackward();
                                    }
                                    else
                                    {
                                        DataHolder.setProgram(codeField.text);
                                        SceneManager.LoadScene("SampleScene");
                                    }
                                }
                            }
                        }
                        else if (commands[1].Equals("!isBackwardEmpty()"))
                        {
                            if (!isBackwardEmpty())
                            {
                                if (commands[3].Equals("left()"))
                                {
                                    rotLeft();
                                }
                                else if (commands[3].Equals("right()"))
                                {
                                    rotRight();
                                }
                                else if (commands[3].Equals("moveForward()"))
                                {
                                    if (isForwardEmpty())
                                    {
                                        moveForward();
                                    }
                                    else
                                    {
                                        DataHolder.setProgram(codeField.text);
                                        SceneManager.LoadScene("SampleScene");
                                    }
                                }
                                else if (commands[3].Equals("moveBackward()"))
                                {
                                    if (isBackwardEmpty())
                                    {
                                        moveBackward();
                                    }
                                    else
                                    {
                                        DataHolder.setProgram(codeField.text);
                                        SceneManager.LoadScene("SampleScene");
                                    }
                                }
                            }
                        }
                    }
                    ++currentLine;
                }
                else if (programLines[currentLine].StartsWith("while"))
                {
                    string[] commands = programLines[currentLine].Split(" ");
                    if (commands.Length == 4)
                    {
                        if (commands[2].Equals("repeat"))
                        {
                            
                            if (commands[1].Equals("isForwardEmpty()"))
                            {
                                if (isForwardEmpty())
                                {
                                    if (commands[3].Equals("left()"))
                                    {
                                        rotLeft();
                                    }
                                    else if (commands[3].Equals("right()"))
                                    {
                                        rotRight();
                                    }
                                    else if (commands[3].Equals("moveForward()"))
                                    {
                                        if (isForwardEmpty())
                                        {
                                            moveForward();
                                        }
                                        else
                                        {
                                            DataHolder.setProgram(codeField.text);
                                            SceneManager.LoadScene("SampleScene");
                                        }
                                    }
                                    else if (commands[3].Equals("moveBackward()"))
                                    {
                                        if (isBackwardEmpty())
                                        {
                                            moveBackward();
                                        }
                                        else
                                        {
                                            DataHolder.setProgram(codeField.text);
                                            SceneManager.LoadScene("SampleScene");
                                        }
                                    }
                                }
                                else
                                {
                                    ++currentLine;
                                }
                            }
                            else if (commands[1].Equals("isBackwardEmpty()"))
                            {
                                if (isBackwardEmpty())
                                {
                                    if (commands[3].Equals("left()"))
                                    {
                                        rotLeft();
                                    }
                                    else if (commands[3].Equals("right()"))
                                    {
                                        rotRight();
                                    }
                                    else if (commands[3].Equals("moveForward()"))
                                    {
                                        if (isForwardEmpty())
                                        {
                                            moveForward();
                                        }
                                        else
                                        {
                                            DataHolder.setProgram(codeField.text);
                                            SceneManager.LoadScene("SampleScene");
                                        }
                                    }
                                    else if (commands[3].Equals("moveBackward()"))
                                    {
                                        if (isBackwardEmpty())
                                        {
                                            moveBackward();
                                        }
                                        else
                                        {
                                            DataHolder.setProgram(codeField.text);
                                            SceneManager.LoadScene("SampleScene");
                                        }
                                    }
                                }
                                else
                                {
                                    ++currentLine;
                                }
                            }
                            else if (commands[1].Equals("isLeftEmpty()"))
                            {
                                if (isLeftEmpty())
                                {
                                    if (commands[3].Equals("left()"))
                                    {
                                        rotLeft();
                                    }
                                    else if (commands[3].Equals("right()"))
                                    {
                                        rotRight();
                                    }
                                    else if (commands[3].Equals("moveForward()"))
                                    {
                                        if (isForwardEmpty())
                                        {
                                            moveForward();
                                        }
                                        else
                                        {
                                            DataHolder.setProgram(codeField.text);
                                            SceneManager.LoadScene("SampleScene");
                                        }
                                    }
                                    else if (commands[3].Equals("moveBackward()"))
                                    {
                                        if (isBackwardEmpty())
                                        {
                                            moveBackward();
                                        }
                                        else
                                        {
                                            DataHolder.setProgram(codeField.text);
                                            SceneManager.LoadScene("SampleScene");
                                        }
                                    }
                                }
                                else
                                {
                                    ++currentLine;
                                }
                            }
                            else if (commands[1].Equals("isRightEmpty()"))
                            {
                                if (isRightEmpty())
                                {
                                    if (commands[3].Equals("left()"))
                                    {
                                        rotLeft();
                                    }
                                    else if (commands[3].Equals("right()"))
                                    {
                                        rotRight();
                                    }
                                    else if (commands[3].Equals("moveForward()"))
                                    {
                                        if (isForwardEmpty())
                                        {
                                            moveForward();
                                        }
                                        else
                                        {
                                            DataHolder.setProgram(codeField.text);
                                            SceneManager.LoadScene("SampleScene");
                                        }
                                    }
                                    else if (commands[3].Equals("moveBackward()"))
                                    {
                                        if (isBackwardEmpty())
                                        {
                                            moveBackward();
                                        }
                                        else
                                        {
                                            DataHolder.setProgram(codeField.text);
                                            SceneManager.LoadScene("SampleScene");
                                        }
                                    }
                                }
                                else
                                {
                                    ++currentLine;
                                }
                            }
                            else if (commands[1].Equals("!isForwardEmpty()"))
                            {
                                if (!isForwardEmpty())
                                {
                                    if (commands[3].Equals("left()"))
                                    {
                                        rotLeft();
                                    }
                                    else if (commands[3].Equals("right()"))
                                    {
                                        rotRight();
                                    }
                                    else if (commands[3].Equals("moveForward()"))
                                    {
                                        if (isForwardEmpty())
                                        {
                                            moveForward();
                                        }
                                        else
                                        {
                                            DataHolder.setProgram(codeField.text);
                                            SceneManager.LoadScene("SampleScene");
                                        }
                                    }
                                    else if (commands[3].Equals("moveBackward()"))
                                    {
                                        if (isBackwardEmpty())
                                        {
                                            moveBackward();
                                        }
                                        else
                                        {
                                            DataHolder.setProgram(codeField.text);
                                            SceneManager.LoadScene("SampleScene");
                                        }
                                    }
                                }
                                else
                                {
                                    ++currentLine;
                                }
                            }
                            else if (commands[1].Equals("!isBackwardEmpty()"))
                            {
                                if (!isBackwardEmpty())
                                {
                                    if (commands[3].Equals("left()"))
                                    {
                                        rotLeft();
                                    }
                                    else if (commands[3].Equals("right()"))
                                    {
                                        rotRight();
                                    }
                                    else if (commands[3].Equals("moveForward()"))
                                    {
                                        if (isForwardEmpty())
                                        {
                                            moveForward();
                                        }
                                        else
                                        {
                                            DataHolder.setProgram(codeField.text);
                                            SceneManager.LoadScene("SampleScene");
                                        }
                                    }
                                    else if (commands[3].Equals("moveBackward()"))
                                    {
                                        if (isBackwardEmpty())
                                        {
                                            moveBackward();
                                        }
                                        else
                                        {
                                            DataHolder.setProgram(codeField.text);
                                            SceneManager.LoadScene("SampleScene");
                                        }
                                    }
                                }
                                else
                                {
                                    ++currentLine;
                                }
                            }
                            else if (commands[1].Equals("!isLeftEmpty()"))
                            {
                                if (!isLeftEmpty())
                                {
                                    if (commands[3].Equals("left()"))
                                    {
                                        rotLeft();
                                    }
                                    else if (commands[3].Equals("right()"))
                                    {
                                        rotRight();
                                    }
                                    else if (commands[3].Equals("moveForward()"))
                                    {
                                        if (isForwardEmpty())
                                        {
                                            moveForward();
                                        }
                                        else
                                        {
                                            DataHolder.setProgram(codeField.text);
                                            SceneManager.LoadScene("SampleScene");
                                        }
                                    }
                                    else if (commands[3].Equals("moveBackward()"))
                                    {
                                        if (isBackwardEmpty())
                                        {
                                            moveBackward();
                                        }
                                        else
                                        {
                                            DataHolder.setProgram(codeField.text);
                                            SceneManager.LoadScene("SampleScene");
                                        }
                                    }
                                }
                                else
                                {
                                    ++currentLine;
                                }
                            }
                            else if (commands[1].Equals("!isRightEmpty()"))
                            {
                                if (!isRightEmpty())
                                {
                                    if (commands[3].Equals("left()"))
                                    {
                                        rotLeft();
                                    }
                                    else if (commands[3].Equals("right()"))
                                    {
                                        rotRight();
                                    }
                                    else if (commands[3].Equals("moveForward()"))
                                    {
                                        if (isForwardEmpty())
                                        {
                                            moveForward();
                                        }
                                        else
                                        {
                                            DataHolder.setProgram(codeField.text);
                                            SceneManager.LoadScene("SampleScene");
                                        }
                                    }
                                    else if (commands[3].Equals("moveBackward()"))
                                    {
                                        if (isBackwardEmpty())
                                        {
                                            moveBackward();
                                        }
                                        else
                                        {
                                            DataHolder.setProgram(codeField.text);
                                            SceneManager.LoadScene("SampleScene");
                                        }
                                    }
                                }
                                else
                                {
                                    ++currentLine;
                                }
                            }
                        }
                    }
                }
                else
                {
                    ++currentLine;
                }
            }
            else
            {
                if (_finishCount == 0)
                {
                    win.SetActive(true);
                }
                else
                {
                    DataHolder.setProgram(codeField.text);
                    SceneManager.LoadScene("SampleScene");
                }
            }
        }
        

        
        float zoom = Input.GetAxis("Mouse ScrollWheel");
        if ((zoom > 0) && (_camera.orthographicSize < 1))
        {

        }
        else if ((zoom < 0) && (_camera.orthographicSize > 20))
        {

        }
        else
        {
            _camera.orthographicSize -= zoom * 3;
        }

        if (isCameraMoved())
        {
            _camera.transform.position = new Vector3((float) (_player.transform.position.x + 11.535),
                _camera.transform.position.y,
                (float) (_player.transform.position.z - 11.463));
            if (!taskFlag)
            {
                taskFlag = true;
                showTask();
            }
        }
    }

    public void FixedUpdate()
    {
        if (toRotate > 1.1)
        {
            toRotate -= 2;
            _player.transform.rotation = Quaternion.Euler(_player.transform.eulerAngles.x,
                _player.transform.eulerAngles.y + 2, _player.transform.eulerAngles.z);
        }
        else if (toRotate < -1.1)
        {
            toRotate += 2;
            _player.transform.rotation = Quaternion.Euler(_player.transform.eulerAngles.x,
                _player.transform.eulerAngles.y - 2, _player.transform.eulerAngles.z);
        }


        if (_playerDirection == PlayerDirection.NORTH)
        {
            if (toMove > 0.012)
            {
                toMove -= 0.02f;
                _player.transform.position = new Vector3(_player.transform.position.x,
                    _player.transform.position.y, _player.transform.position.z + 0.02f);
            }
            else if (toMove < -0.012)
            {
                toMove += 0.02f;
                _player.transform.position = new Vector3(_player.transform.position.x,
                    _player.transform.position.y, _player.transform.position.z - 0.02f);
            }
        }
        else if (_playerDirection == PlayerDirection.WEST)
        {
            if (toMove > 0.012)
            {
                toMove -= 0.02f;
                _player.transform.position = new Vector3(_player.transform.position.x - 0.02f,
                    _player.transform.position.y, _player.transform.position.z);
            }
            else if (toMove < -0.012)
            {
                toMove += 0.02f;
                _player.transform.position = new Vector3(_player.transform.position.x + 0.02f,
                    _player.transform.position.y, _player.transform.position.z);
            }
        }
        else if (_playerDirection == PlayerDirection.SOUTH)
        {
            if (toMove > 0.012)
            {
                toMove -= 0.02;
                _player.transform.position = new Vector3(_player.transform.position.x,
                    _player.transform.position.y, _player.transform.position.z - 0.02f);
            }
            else if (toMove < -0.012)
            {
                toMove += 0.02;
                _player.transform.position = new Vector3(_player.transform.position.x,
                    _player.transform.position.y, _player.transform.position.z + 0.02f);
            }
        }
        else if (_playerDirection == PlayerDirection.EAST)
        {
            if (toMove > 0.012)
            {
                toMove -= 0.02;
                _player.transform.position = new Vector3(_player.transform.position.x + 0.02f,
                    _player.transform.position.y, _player.transform.position.z);
            }
            else if (toMove < -0.012)
            {
                toMove += 0.02;
                _player.transform.position = new Vector3(_player.transform.position.x - 0.02f,
                    _player.transform.position.y, _player.transform.position.z);
            }
        }

    }

    public string GetId()
    {
        return _levelId;
    }

    private void SetId(string value)
    {
        _levelId = value;
    }

    bool isCameraMoved()
    {
        return _camera.transform.position.y > 15;
    }

    bool isPlayerStand()
    {
        return ((isPlayerMoved()) && (isPlayerRotated()));
    }
    
    bool isPlayerRotated()
    {
        return ((toRotate > -0.5) && (toRotate < 0.5));
    }

    bool isPlayerMoved()
    {
        return ((toMove > -0.012) && (toMove < 0.012));
    }

    void rotLeft()
    {
        if (_playerDirection == PlayerDirection.NORTH)
        {
            _playerDirection = PlayerDirection.WEST;
        }
        else if (_playerDirection == PlayerDirection.WEST)
        {
            _playerDirection = PlayerDirection.SOUTH;
        }
        else if (_playerDirection == PlayerDirection.SOUTH)
        {
            _playerDirection = PlayerDirection.EAST;
        }
        else if (_playerDirection == PlayerDirection.EAST)
        {
            _playerDirection = PlayerDirection.NORTH;
        }

        toRotate -= 90;
    }

    void rotRight()
    {
        if (_playerDirection == PlayerDirection.NORTH)
        {
            _playerDirection = PlayerDirection.EAST;
        }
        else if (_playerDirection == PlayerDirection.EAST)
        {
            _playerDirection = PlayerDirection.SOUTH;
        }
        else if (_playerDirection == PlayerDirection.SOUTH)
        {
            _playerDirection = PlayerDirection.WEST;
        }
        else if (_playerDirection == PlayerDirection.WEST)
        {
            _playerDirection = PlayerDirection.NORTH;
        }

        toRotate += 90;
    }

    void moveForward()
    {
        if (_playerDirection == PlayerDirection.NORTH)
        {
            ++playerJ;
        }
        else if (_playerDirection == PlayerDirection.EAST)
        {
            ++playerI;
        }
        else if (_playerDirection == PlayerDirection.SOUTH)
        {
            --playerJ;
        }
        else if (_playerDirection == PlayerDirection.WEST)
        {
            --playerI;
        }

        toMove += 1;
    }

    void moveBackward()
    {
        if (_playerDirection == PlayerDirection.NORTH)
        {
            --playerJ;
        }
        else if (_playerDirection == PlayerDirection.EAST)
        {
            --playerI;
        }
        else if (_playerDirection == PlayerDirection.SOUTH)
        {
            ++playerJ;
        }
        else if (_playerDirection == PlayerDirection.WEST)
        {
            ++playerI;
        }

        toMove -= 1;
    }

    bool isLeftEmpty()
    {
        if (_playerDirection == PlayerDirection.NORTH)
        {
            return isEmptyType(playerI - 1, playerJ);
        }
        else if (_playerDirection == PlayerDirection.EAST)
        {
            return isEmptyType(playerI, playerJ + 1);
        }
        else if (_playerDirection == PlayerDirection.SOUTH)
        {
            return isEmptyType(playerI + 1, playerJ);
        }
        else if (_playerDirection == PlayerDirection.WEST)
        {
            return isEmptyType(playerI, playerJ - 1);
        }

        return false;
    }

    bool isRightEmpty()
    {
        if (_playerDirection == PlayerDirection.NORTH)
        {
            return isEmptyType(playerI + 1, playerJ);
        }
        else if (_playerDirection == PlayerDirection.EAST)
        {
            return isEmptyType(playerI, playerJ - 1);
        }
        else if (_playerDirection == PlayerDirection.SOUTH)
        {
            return isEmptyType(playerI - 1, playerJ);
        }
        else if (_playerDirection == PlayerDirection.WEST)
        {
            return isEmptyType(playerI, playerJ + 1);
        }

        return false;
    }

    bool isForwardEmpty()
    {
        if (_playerDirection == PlayerDirection.NORTH)
        {
            return isEmptyType(playerI, playerJ + 1);
        }
        else if (_playerDirection == PlayerDirection.EAST)
        {
            return isEmptyType(playerI + 1, playerJ);
        }
        else if (_playerDirection == PlayerDirection.SOUTH)
        {
            return isEmptyType(playerI, playerJ - 1);
        }
        else if (_playerDirection == PlayerDirection.WEST)
        {
            return isEmptyType(playerI - 1, playerJ);
        }

        return false;
    }

    bool isBackwardEmpty()
    {
        if (_playerDirection == PlayerDirection.NORTH)
        {
            return isEmptyType(playerI, playerJ - 1);
        }
        else if (_playerDirection == PlayerDirection.EAST)
        {
            return isEmptyType(playerI - 1, playerJ);
        }
        else if (_playerDirection == PlayerDirection.SOUTH)
        {
            return isEmptyType(playerI, playerJ + 1);
        }
        else if (_playerDirection == PlayerDirection.WEST)
        {
            return isEmptyType(playerI + 1, playerJ);
        }

        return false;
    }

    bool isEmptyType(int i, int j)
    {
        return ((levelField[i][j] == -2) || (levelField[i][j] == -3) || (levelField[i][j] == -4) || (levelField[i][j] == 4));
    }

}
