﻿// See https://aka.ms/new-console-template for more information
using BowlingGame;

Console.WriteLine("Hello, World!");

Game game = new Game();

//int[] listOfRolledPinsInEveryThrow = new int[]{ 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
int[] listOfRolledPinsInEveryThrow = new int[] { 10, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };

game.ManyThrowsSecond(listOfRolledPinsInEveryThrow.Length, listOfRolledPinsInEveryThrow);
