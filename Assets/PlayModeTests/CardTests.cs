using System.Collections;
using System.Collections.Generic;
using Fight;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class CardTests
    {
        readonly string Player1 = "Ryu";
        readonly string Player2 = "Blanka";

        [SetUp]
        public void init()
        {
            Card.SetPlayer1Fighter(Player1);
        }

        [Test, Order(1)]
        public void CardShouldCreateRounds()
        {
            Card.CreateRounds();

            Assert.IsNotNull(Card.FightRounds);
        }

        [Test, Order(2)]
        public void CardShouldInitTheCurrentRound()
        {
            Card.CreateRounds();
            Card.InitCurrentRound();

            Assert.IsNotNull(Card.FightRounds[Card.CurrentRound]);
        }

        [Test, Order(3)]
        public void CardShouldReturnFightIsOpenIfFirstRound()
        {
            Card.CreateRounds();
            Card.InitCurrentRound();

            bool fightIsOpen = Card.FightIsOpen();

            Assert.AreEqual(true, fightIsOpen);
        }

        [Test, Order(4)]
        public void CardShouldHasWinnerAfterClosed()
        {
            Card.CreateRounds();

            Card.InitCurrentRound();
            Card.SetCurrentRoundWinner(Player1);
            Card.AddCurrentRoundNumber();

            Card.InitCurrentRound();
            string lastRoundWinner = Card.GetLastRoundWinner();

            Assert.AreEqual(Player1, lastRoundWinner);
        }

        [Test, Order(5)]
        public void CardShouldReturnFightIsOpenIfPlayerNotWinTwoRounds()
        {
            Card.SetCurrentRoundWinner(Player2);

            Card.AddCurrentRoundNumber();
            Card.InitCurrentRound();

            Assert.AreEqual(true, Card.FightIsOpen());
        }
    }
}