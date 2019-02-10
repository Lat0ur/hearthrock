﻿// <copyright file="RockJsonSerializerTests.cs" company="https://github.com/yangyuan">
//     Copyright (c) The Hearthrock Project. All rights reserved.
// </copyright>

namespace Hearthrock.Tests.CommunicationTests
{
    using System.Collections.Generic;
    using System.Diagnostics;

    using Hearthrock.Communication;
    using Hearthrock.Contracts;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Tests for <see cref="RockJsonSerializer" /> class.
    /// </summary>
    [TestClass]
    public class RockJsonSerializerTests
    {
        /// <summary>
        /// TestMethod for Serialize TraceInfo
        /// </summary>
        [TestMethod]
        public void TestRockJsonSerializerOnTraceInfo()
        {
            var traceMessage = new Dictionary<string, string>();
            traceMessage.Add("Level", TraceLevel.Verbose.ToString());
            traceMessage.Add("Message", "Message");

            string jsonTraceMessage = RockJsonSerializer.Serialize((object)traceMessage);
            Assert.AreEqual("{\"Level\":\"Verbose\",\"Message\":\"Message\"}", jsonTraceMessage);
        }

        /// <summary>
        /// TestMethod for Deserialize null
        /// </summary>
        [TestMethod]
        public void TestRockJsonSerializerForNull()
        {
            List<int> jsonTraceMessage = RockJsonSerializer.Deserialize<List<int>>("null");
        }

        /// <summary>
        /// TestMethod for Serialize
        /// </summary>
        [TestMethod]
        public void TestMethodForSerializeRockScene()
        {
            var rockScene = GenerateRockScene();
            var x = RockJsonSerializer.Serialize(rockScene);
        }

        /// <summary>
        /// TestMethod for Serialize
        /// </summary>
        [TestMethod]
        public void TestRockJsonSerializerOnRockConfiguration()
        {
            var config = new RockConfiguration();
            config.GameMode = RockGameMode.NormalPractice;
            var configJson = RockJsonSerializer.Serialize(config);
            var configObject = RockJsonSerializer.Deserialize<RockConfiguration>(configJson);
            Assert.AreEqual(configObject.GameMode, config.GameMode);
        }

        /// <summary>
        /// TestMethod for Serialize
        /// </summary>
        [TestMethod]
        public void TestRockJsonSerializerOnRockScene()
        {
            var rockScene = GenerateRockScene();
            var rockSceneJson = RockJsonSerializer.Serialize(rockScene);
            var rockSceneObject = RockJsonSerializer.Deserialize<RockScene>(rockSceneJson);
            Assert.AreEqual(rockScene.ActionId, rockSceneObject.ActionId);
        }

        /// <summary>
        /// Generate a sample RockScene.
        /// </summary>
        /// <returns>A RockScene.</returns>
        private static RockScene GenerateRockScene()
        {
            var rockScene = new RockScene();
            rockScene.Self = GenerateRockPlayer();
            rockScene.Opponent = GenerateRockPlayer();

            return rockScene;
        }

        /// <summary>
        /// Generate a sample RockPlayer.
        /// </summary>
        /// <returns>A RockPlayer.</returns>
        private static RockPlayer GenerateRockPlayer()
        {
            var rockPlayer = new RockPlayer();
            rockPlayer.Cards = new List<RockCard>();

            var rockCard = new RockCard();
            rockCard.CardId = "GAME_005";

            rockPlayer.Cards.Add(rockCard);

            rockPlayer.Hero = GenerateRockHero();
            return rockPlayer;
        }

        /// <summary>
        /// Generate a sample RockHero.
        /// </summary>
        /// <returns>A RockHero.</returns>
        private static RockHero GenerateRockHero()
        {
            var rockHero = new RockHero();
            return rockHero;
        }
    }
}
