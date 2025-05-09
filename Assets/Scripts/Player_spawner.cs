using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_spawner : MonoBehaviour
{
    public GameObject Snowy;
    public GameObject ShapeRobot;
    public CinemachineVirtualCamera virtualCamera;
    public Sprite[] pictures;
    public Image healthBarImage;

    // Start is called before the first frame update
    void Start()
    {
        GameObject Player = null;
        if(Storeddata.character == "Snowey")
        {
            Player = Instantiate(Snowy, transform.position, Quaternion.identity);
            SnoweysMovementscript Scriptforsnowey = Player.GetComponent<SnoweysMovementscript>();
            Scriptforsnowey.healthBarImage = healthBarImage;
            Scriptforsnowey.pictures = pictures;
        }
        if (Storeddata.character == "Shape Robot")
        {
            Player = Instantiate(ShapeRobot, transform.position, Quaternion.identity);
            RobotMovementscript ScriptforRobot = Player.GetComponent<RobotMovementscript>();
            ScriptforRobot.healthBarImage = healthBarImage;
            ScriptforRobot.pictures = pictures;
        }
        virtualCamera.Follow = Player.transform;
       FindObjectOfType<Levelwin>().Player = Player;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
