using System.Collections;
using System.Collections.Generic;
using Fight;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class FightTests
    {
        readonly string Player1 = "Ryu";

        [SetUp]
        public void init()
        {
            Card.SetPlayer1Fighter(Player1);
            Card.InitRounds();
        }

        [Test]
        public void CardShouldCreateRounds()
        {
            Assert.IsNotNull(Card.FightRounds);
        }
    }
}