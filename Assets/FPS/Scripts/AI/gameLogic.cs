using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Timers;
using Unity.FPS.Game;
using UnityEngine.AI;
using UnityEngine.Events;

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
        private EnemyController e3Controller;
        private EnemyController bossController;
        private Health bossHealth;

        //word bank for boss fight
        string[] wrongWords = { "Miniscule", "Diminutive", "Frugal", "Brief", "Serendipitous"};
        string[] correctWords = { "Vast", "Colossol", "Immense", "Massive", "Behemothic" };
        //want the Boss' words to change every 5 seconds
        private Timer timer1;





        // Start is called before the first frame update
        void Start()
        {
            enemyManager = GameManager.GetComponent<EnemyManager>();
            e2Controller = enemy2.GetComponent<EnemyController>();
            e3Controller = enemy3.GetComponent<EnemyController>();
            bossController = Boss.GetComponent<EnemyController>();
            bossHealth = Boss.GetComponent<Health>();

            timer1 = new Timer(); //new Timer(1000);
            timer1.Elapsed += (sender, e) =>
            {
                updateBoss();
            };
            timer1.Interval = 5000;//miliseconds
            timer1.Start();


        }

        // Update is called once per frame
        void Update()
        {

            //when enemy2 dies, enemy3 becomes shootable
            if (!enemyManager.Enemies.Contains(e2Controller))
            {
                e3Controller.setInvincible(false);
                e3Text.SetText("Gargantuan");
            }
            //stops timer when Boss dies
            if (!enemyManager.Enemies.Contains(bossController))
            {
                timer1.Stop();
            }

        }

        //function to switch boss states
        public void updateBoss()
        {
            Debug.Log("called update boss");
            Debug.Log(bossHealth.Invincible);
            //switch from incorrect word to correct word
            if (bossHealth.Invincible)
            {
                System.Random random = new System.Random();
                int i = random.Next(0, correctWords.Length);
                BossText.SetText(correctWords[i]);
                Debug.Log(correctWords[i]);
                bossController.setInvincible(false);

            }
            else //switch from correct word to incorrect word
            {
                System.Random random = new System.Random();
                int i = random.Next(0, wrongWords.Length);
                BossText.SetText(wrongWords[i]);
                bossController.setInvincible(true);
                Debug.Log(wrongWords[i]);
            }
        }

    }
}


