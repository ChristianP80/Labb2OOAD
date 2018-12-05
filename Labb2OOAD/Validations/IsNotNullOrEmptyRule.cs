﻿using System;
namespace Labb2OOAD.Validations
{
    public class IsNotNullOrEmptyRule<T> : IValidationRule<T>
    {
        public IsNotNullOrEmptyRule()
        {
        }

        public string ValidationMessage { get; set; }

        public bool Check(T value)
        {
            if (value == null)
            {
                return false;
            }

            var str = value as string;
            return !string.IsNullOrWhiteSpace(str);
        }
    }
}