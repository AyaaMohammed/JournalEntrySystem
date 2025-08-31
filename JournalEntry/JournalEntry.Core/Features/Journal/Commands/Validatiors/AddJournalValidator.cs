using FluentValidation;
using JournalEntry.Core.Bases;
using JournalEntry.Core.Features.Journal.Commands.Models;
using JournalEntry.Core.Rescources;
using JournalEntry.Data.Helpers;
using MediatR;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JournalEntry.Core.Features.Journal.Commands.Validatiors
{
    public class AddJournalValidator:AbstractValidator<AddJournalCommand>
    {
        public AddJournalValidator()
        {
            ApplyValidationsRule();
            ApplyCustomValidationsRules();
        }
        private void ApplyValidationsRule()
        {
            RuleFor(x => x.SystemNo)
                .NotEmpty().WithMessage("System Number is required.")
                .MaximumLength(50).WithMessage("System Number cannot exceed 50 characters.");

            RuleFor(x => x.EntryDate)
                .NotEmpty().WithMessage("Entry Date is required.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Entry Date cannot be in the future.");

            RuleFor(x => x.TransactionType)
                .MaximumLength(50).WithMessage("Invalid transaction type.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");

            RuleFor(x => x.User_ID)
                .GreaterThan(0).WithMessage("User ID must be greater than 0.");

            RuleForEach(x => x.JournalDetails).SetValidator(new JournalDetailValidator());
        }

        private void ApplyCustomValidationsRules()
        {
            RuleFor(x => x.JournalDetails)
                .Must(details => details.Sum(d => d.Debit) == details.Sum(d => d.Credit))
                .WithMessage("Total Debit must equal Total Credit.");
        }
    }

}

