using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Kingdom.BuildingObject;

namespace Kingdom
{
    public static class Loader
    {
        public enum Scence
        {
            MainMenu,
            LoadingScence,
            Game
        }

        public static Scence targetScene;

        public static void LoadScene(Scence target)
        {
            targetScene = target;
            SceneManager.LoadScene(Scence.LoadingScence.ToString());

            Building.ResetStaticData();
            Barrack.ResetStaticData();
        }

        public static void LoadTargetScene() => SceneManager.LoadScene(targetScene.ToString());

    }
}