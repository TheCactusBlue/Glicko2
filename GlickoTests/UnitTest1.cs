﻿using System;
using Xunit;
using Glicko2;
using System.Collections.Generic;

namespace GlickoTests
{
    public class UnitTest1
    {
        GlickoPlayer player1 = new GlickoPlayer(ratingDeviation: 200);
        GlickoPlayer player2 = new GlickoPlayer(1400, 30);
        GlickoPlayer player3 = new GlickoPlayer(1550, 100);
        GlickoPlayer player4 = new GlickoPlayer(1700, 300);

        [Fact]
        public void GlickoUpdateCorrect()
        {
            var expectedValue = 0.059995984286488495;

            var player1Opponents = new List<GlickoOpponent>
            {
                new GlickoOpponent(player2, 1),
                new GlickoOpponent(player3, 0),
                new GlickoOpponent(player4, 0)
            };

            player1 = GlickoCalculator.CalculateRanking(player1, player1Opponents);
            var actualValue = player1.Volatility;

            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void GlickoUpdateRankingCorrect()
        {
            var expectedValue = 1464.05;

            var player1Opponents = new List<GlickoOpponent>
            {
                new GlickoOpponent(player2, 1),
                new GlickoOpponent(player3, 0),
                new GlickoOpponent(player4, 0)
            };

            player1 = GlickoCalculator.CalculateRanking(player1, player1Opponents);
            var actualValue = Math.Round(player1.Rating, 2);

            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void GlickoUpdateRatingDeviationCorrect()
        {
            var expectedValue = 151.52;

            var player1Opponents = new List<GlickoOpponent>
            {
                new GlickoOpponent(player2, 1),
                new GlickoOpponent(player3, 0),
                new GlickoOpponent(player4, 0)
            };

            player1 = GlickoCalculator.CalculateRanking(player1, player1Opponents);
            var actualValue = Math.Round(player1.RatingDeviation, 2);

            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void GlickoUpdateNoOpponents()
        {
            var expectedValue = 0.06;

            var player1Opponents = new List<GlickoOpponent>();

            player1 = GlickoCalculator.CalculateRanking(player1, player1Opponents);
            var actualValue = player1.Volatility;

            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void GlickoUpdateRankingNoOpponents()
        {
            var expectedValue = 1500;

            var player1Opponents = new List<GlickoOpponent>();

            player1 = GlickoCalculator.CalculateRanking(player1, player1Opponents);
            var actualValue = Math.Round(player1.Rating, 2);

            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void GlickoUpdateRatingDeviationNoOpponents()
        {
            var expectedValue = 200.27;

            var player1Opponents = new List<GlickoOpponent>();

            player1 = GlickoCalculator.CalculateRanking(player1, player1Opponents);
            var actualValue = Math.Round(player1.RatingDeviation, 2);

            Assert.Equal(expectedValue, actualValue);
        }
    }
}