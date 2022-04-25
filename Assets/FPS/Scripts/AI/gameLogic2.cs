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
    public class gameLogic2 : MonoBehaviour
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
        private Health e3Health;
        private Health bossHealth;


        //word bank for boss fight
        string[] wrongWords = { "Quick", "Giant", "Frugal", "Massive", "Serendipitous" };
        string[] correctWords = { "Miniature", "Microscopic", "Brief", "Petite", "Diminutive" };

        //want the Boss' words to change every 5 seconds
        float timePassed = 0f;





        // Start is called before the first frame update
        void Start()
        {
            enemyManager = GameManager.GetComponent<EnemyManager>();
            e2Controller = enemy2.GetComponent<EnemyController>();
            bossHealth = Boss.GetComponent<Health>();
            e3Health = enemy3.GetComponent<Health>();


        }

        // Update is called once per frame
        void Update()
        {

            //when enemy2 dies, enemy3 becomes shootable
            if (!enemyManager.Enemies.Contains(e2Controller))
            {
                e3Health.setInvincible(false);
                e3Text.SetText("Puny");
            }

            //updates boss every 5 seconds
            timePassed += Time.deltaTime;
            if (timePassed > 5f)
            {
                updateBoss();
                timePassed = 0f;
            }

        }

        //function to switch boss states
        public void updateBoss()
        {

            //switch from incorrect word to correct word
            if (bossHealth.Invincible)
            {
                System.Random random = new System.Random();
                int i = random.Next(0, correctWords.Length);
                BossText.SetText(correctWords[i]);
                bossHealth.setInvincible(false);

            }
            else //switch from correct word to incorrect word
            {
                System.Random random = new System.Random();
                int i = random.Next(0, wrongWords.Length);
                BossText.SetText(wrongWords[i]);
                bossHealth.setInvincible(true);
            }
        }

    }
}


