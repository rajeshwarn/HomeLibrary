﻿using System.Linq;
using FluentValidation;
using KesselRun.HomeLibrary.EF;
using KesselRun.HomeLibrary.Model;
using KesselRun.HomeLibrary.Service.Commands;

namespace KesselRun.HomeLibrary.Service.Validation
{
    public class AddLendingValidator : AbstractValidator<AddLendingCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddLendingValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;


            RuleFor(c => c.DateDue).NotNull().WithMessage("The Due Date cannot be null.");
            RuleFor(c => c.BookId).Must(BookNotAlreadyLent).WithMessage("The book is currently on loan to another person.");
        }

        private bool BookNotAlreadyLent(int bookId)
        {
            var book = _unitOfWork.Repository<Model.Book>().GetSingleIncluding(bookId, b => b.Lendings);
            Lending loanNotReturned = null;

            if (!ReferenceEquals(null, book))
            {
                loanNotReturned = book.Lendings.FirstOrDefault(l => l.ReturnDate == null);
            }

            return ReferenceEquals(null, loanNotReturned);
        }

    }
}
