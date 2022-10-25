using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using SAF.SSN.Kernel.Infrastructure.Exceptions;

namespace ITJob.Message.Command.Seedworks
{
    public static class ValidationResultExtension
    {
        /// <inheritdoc />
        public static void RaiseExceptionIfRequired(this ValidationResult validationResult)
        {
            if (!validationResult.IsValid)
                throw new CommandValidationException(validationResult.Errors.First().ErrorMessage);
            //throw new CommandException(validationResult.Errors.First().ErrorMessage);
        }

        /// <inheritdoc />
        public static void RaiseExceptionIfRequired(this ValidationResult validationResult, Action<ValidationFailure> raiseAction)
        {
            if (!validationResult.IsValid && raiseAction != null) raiseAction.Invoke(validationResult.Errors.First());
        }
    }
}
