using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace Unity.FPS.AI
{
    public class gameLogic : MonoBehaviour
    {
        
        //enemy objects
        public GameObject enemy1;
        public GameObject enemy2;
        public GameObject enemy3;
        public GameObject Boss;
        //texts above the enemies
        public TextMeshProUGUI e1Text;
        public TextMeshProUGUI e2Text;
        public TextMeshProUGUI e3Text;

        public TextMeshProUGUI BossText;

        //variables from other classes
        public GameObject GameManager;
        private EnemyManager enemyManager;
        private EnemyController e2Controller;

        

        

        // Start is called before the first frame update
        void Start()
        {
            enemyManager = GameManager.GetComponent<EnemyManager>();
            e2Controller = enemy2.GetComponent<EnemyController>();



        }

        // Update is called once per frame
        void Update()
        {

            if (!enemyManager.Enemies.Contains(e2Controller))
            {
                Debug.Log("got here");
                e3Text.SetText("Gargantuan");
            }

        }
    }
}


