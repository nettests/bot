﻿using System;
using System.Collections.Generic;
using bot.Models;
using System.Numerics;
using System.Text;
using Newtonsoft.Json;
using System.IO;

namespace bot.Services
{
    public class ZagadkaService
    {
		private List<Zagadka> zagadki;
		private DateTime last;
		private TimeSpan interval;
		private string answer;
		private bool guessed;
		private bool flag;

		public ZagadkaService()
		{
			zagadki = JsonConvert.DeserializeObject<List<Zagadka>>(File.ReadAllText(Directory.GetCurrentDirectory() + "/questions.json"));

			interval = new TimeSpan(0, 0, 10);
			last = DateTime.Now;
			guessed = false;
			flag = true;
		}

		public string GetZagadku()
		{
			if ((DateTime.Now - last > interval && guessed) || flag)
			{
				flag = false;
				guessed = false;
				Random rnd = new Random();
				int i = rnd.Next(zagadki.Count - 1);
				answer = zagadki[i].otvet;
				return zagadki[i].zagadka;
			}
			return "время не прошло";
		}

		public AnswerResult CheckAnswer(string ans)
		{
			if(guessed)
				return AnswerResult.Guessed;
			if(ans.ToLower() != answer.ToLower())
				return AnswerResult.WrongAnswer;
			last = DateTime.Now;
			guessed = true;
			return AnswerResult.CurrectAnswer;
		}
    }
}
