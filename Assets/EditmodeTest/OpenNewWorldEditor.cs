using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class OpenNewWorldEditor
    {
        // A Test behaves as an ordinary method
        [Test]
        public void Player_Exists_by_name()
        {
            // Use the Assert class to test conditions
            var player = GameObject.Find("Player");
            Assert.IsTrue(player != null);
        }

        [Test]
        public void Player_Exists_by_type()
        {
            // Use the Assert class to test conditions


        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator OpenNewWorldEditorWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
    }
}
