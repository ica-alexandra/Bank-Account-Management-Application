﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AEAEBank.App_Start
{
    public class ModelClientValidationNumericLessThanRule : ModelClientValidationRule
    {
        public ModelClientValidationNumericLessThanRule(string errorMessage, object other, bool allowEquality)
        {
            ErrorMessage = errorMessage;
            ValidationType = "numericlessthan";
            ValidationParameters["other"] = other;
            ValidationParameters["allowequality"] = allowEquality;
        }
    }
}