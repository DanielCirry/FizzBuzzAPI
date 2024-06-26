﻿using FizzBuzzAPI.Models;

namespace FizzBuzzAPI.Interfaces
{
    public interface IFizzBuzzLogic
    {
        bool IsFizz(int value);
        bool IsBuzz(int value);
        bool IsFizzBuzz(int value);
        string ReturnFizz();
        string ReturnBuzz();
        string ReturnFizzBuzz();
        List<string?>? HandleFizzBuzzLogic(FizzBuzzModel model);
    }
}
