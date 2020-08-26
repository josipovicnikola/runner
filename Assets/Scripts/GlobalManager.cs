using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GM
{
    public static class GlobalManager 
    {
        private static PlayerController playerController;
        public static PlayerController PlayerController
        {
            get
            {
                if(playerController == null)
                {
                    Debug.LogError("PlayerController does not exist in the scene.");
                }
                return playerController;
            }
            set
            {
                playerController = value;
            }
        }

        private static CameraController cameraController;
        public static CameraController CameraController
        {
            get
            {
                if(cameraController == null)
                {
                    Debug.LogError("CameraController does not exist in the scene.");
                }
                return cameraController;
            }
            set
            {
                cameraController = value;
            }
        }

        private static PlatformManager platformManager;
        public static PlatformManager PlatformManager
        {
            get
            {
                if (platformManager == null)
                {
                    Debug.LogError("PlatformManager does not exist in the scene.");
                }
                return platformManager;
            }
            set
            {
                platformManager = value;
            }
        }

        private static GameManager gameManager;
        public static GameManager GameManager
        {
            get
            {
                if (gameManager == null)
                {
                    Debug.LogError("GameManager does not exist in the scene.");
                }
                return gameManager;
            }
            set
            {
                gameManager = value;
            }
        }

        private static UIManager uIManager;
        public static UIManager UIManager
        {
            get
            {
                if (uIManager == null)
                {
                    Debug.LogError("UIManager does not exist in the scene.");
                }
                return uIManager;
            }
            set
            {
                uIManager = value;
            }
        }

        private static SwipeManager swipeManager;
        public static SwipeManager SwipeManager
        {
            get
            {
                if (swipeManager == null)
                {
                    Debug.LogError("SwipeManager does not exist in the scene.");
                }
                return swipeManager;
            }
            set
            {
                swipeManager = value;
            }
        }

        private static CoinController coinController;
        public static CoinController CoinController
        {
            get
            {
                if (coinController == null)
                {
                    Debug.LogError("CoinController does not exist in the scene.");
                }
                return coinController;
            }
            set
            {
                coinController = value;
            }
        }

        private static AudioManager audioManager;
        public static AudioManager AudioManager
        {
            get
            {
                if (audioManager == null)
                {
                    Debug.LogError("AudioManager does not exist in the scene.");
                }
                return audioManager;
            }
            set
            {
                audioManager = value;
            }
        }

        private static DataManager dataManager;
        public static DataManager DataManager
        {
            get
            {
                if (dataManager == null)
                {
                    Debug.LogError("DataManager does not exist in the scene.");
                }
                return dataManager;
            }
            set
            {
                dataManager = value;
            }
        }
    }
}

