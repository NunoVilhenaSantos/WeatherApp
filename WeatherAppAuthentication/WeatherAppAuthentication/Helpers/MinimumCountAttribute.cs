﻿// ---------------------------------------------------
// Demo 1: https://quickapp-pro.azurewebsites.net
// Demo 2: https://quickapp-standard.azurewebsites.net
//
// --> Gun4Hire: contact@ebenmonney.com
// ---------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace WeatherAppAuthentication.Helpers;

[AttributeUsage(AttributeTargets.Property)]
public sealed class MinimumCountAttribute : ValidationAttribute
{
    private const string _defaultError = "'{0}' must have at least {1} item.";
    private readonly bool _allowEmptyStringValues;
    private readonly int _minCount;
    private readonly bool _required;

    public MinimumCountAttribute() : this(1)
    {
    }

    public MinimumCountAttribute(int minCount, bool required = true,
        bool allowEmptyStringValues = false) : base(_defaultError)
    {
        _minCount = minCount;
        _required = required;
        _allowEmptyStringValues = allowEmptyStringValues;
    }

    public override bool IsValid(object value)
    {
        if (value == null)
            return !_required;

        if (!_allowEmptyStringValues && value is ICollection<string> stringList)
            return stringList.Count(s => !string.IsNullOrWhiteSpace(s)) >=
                   _minCount;

        if (value is ICollection list)
            return list.Count >= _minCount;

        return false;
    }

    public override string FormatErrorMessage(string name)
    {
        return string.Format(ErrorMessageString, name, _minCount);
    }
}