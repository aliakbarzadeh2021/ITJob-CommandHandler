using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using ITJob.Message.Command.AdvertisementModule.Messages;

namespace ITJob.Message.Command.AdvertisementModule.Validators
{
    public class CreateAdvertisementCommandValidator : AbstractValidator<CreateAdvertisementCommand>
    {
    }
}
