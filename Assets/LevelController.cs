using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public int currentLevel = 0;

    public FlagController[] level0Flags;
    public FlagController[] level1Flags;
    public FlagController[] level2Flags;

    private FlagController[][] levelFlags;
    // Start is called before the first frame update
    void Start()
    {
        levelFlags = new FlagController[][] { level0Flags, level1Flags, level2Flags };
    }

    // Update is called once per frame
    void Update()
    {
        if (levelFlags[currentLevel].Length > 0 && Array.TrueForAll(levelFlags[currentLevel], flag => flag.hasPlayer))
        {
            currentLevel += 1;

            GetComponent<AudioSource>().Play();

            switch (currentLevel)
            {
                case 1:
                    OnLevel0Complete();
                    break;
                case 2:
                    onLevel1Complete();
                    break;
                case 3:
                    onLevel2Complete();
                    break;
            }
        }
    }

    [Serializable]
    public class triggerLevel0Complete : UnityEvent { }
    [Serializable]
    public class triggerLevel1Complete : UnityEvent { }
    [Serializable]
    public class triggerLevel2Complete : UnityEvent { }

    [SerializeField]
    private triggerLevel0Complete m_onLevel0Complete = new triggerLevel0Complete();
    [SerializeField]
    private triggerLevel1Complete m_onLevel1Complete = new triggerLevel1Complete();
    [SerializeField]
    private triggerLevel2Complete m_onLevel2Complete = new triggerLevel2Complete();

    void OnLevel0Complete()
    {
        m_onLevel0Complete.Invoke();
    }

    void onLevel1Complete()
    {
        m_onLevel1Complete.Invoke();
    }

    void onLevel2Complete()
    {
        m_onLevel2Complete.Invoke();
    }

    public void restartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
