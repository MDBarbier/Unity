using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace Tests
{
    public class Tests
    {
        // A Test behaves as an ordinary method
        [Test]
        public void TestsSimplePasses()
        {
            // Use the Assert class to test conditions
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator TestsWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }

        [UnityTest]
        public IEnumerator TestCollectCoinIncrementsCoins()
        {
            LevelManager lm = new GameObject().AddComponent<LevelManager>();

            lm.coinCount = 1;
            lm.scoreText = new GameObject().AddComponent<Text>();
            lm.AddCoins(5);

            Assert.AreEqual(6, lm.coinCount);

            yield return null;
        }
    }
}
