using FluentValidation;
using JournalEntry.Core.Features.Journal.Commands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JournalEntry.Core.Features.Journal.Commands.Validatiors
{
    public class JournalDetailValidator : AbstractValidator<JournalDetailDto>
    {
        public JournalDetailValidator()
        {
            RuleFor(x => x.AccountID)
                .NotEmpty().WithMessage("Account ID is required.");

            RuleFor(x => x.AccountNumber)
                .NotEmpty().WithMessage("Account Number is required.")
                .MaximumLength(50);

            RuleFor(x => x.AccountName)
                .NotEmpty().WithMessage("Account Name is required.")
                .MaximumLength(150);

            RuleFor(x => x.Debit)
                .GreaterThanOrEqualTo(0).WithMessage("Debit must be >= 0");

            RuleFor(x => x.Credit)
                .GreaterThanOrEqualTo(0).WithMessage("Credit must be >= 0");

            RuleFor(x => x)
                .Must(d => (d.Debit == 0 && d.Credit > 0) || (d.Credit == 0 && d.Debit > 0))
                .WithMessage("Each line must have either Debit or Credit, not both.");
        }
    }
}
