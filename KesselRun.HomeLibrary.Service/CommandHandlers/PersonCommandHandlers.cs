﻿using System;
using KesselRun.HomeLibrary.Model;
using KesselRun.HomeLibrary.Service.Commands;
using KesselRun.HomeLibrary.Service.Infrastructure;
using KesselRun.HomeLibrary.Service.ObjectResolution;
using Repository.Pattern.Infrastructure;
using Repository.Pattern.UnitOfWork;

namespace KesselRun.HomeLibrary.Service.CommandHandlers
{
    public class PersonCommandHandlers : ICommandHandler<AddPersonCommand>
    {
        private readonly IUnitOfWorkAsync _unitOfWork;
        private bool _disposed = false;

        public PersonCommandHandlers(IUnitOfWorkAsync unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [TransactionAspect]
        public virtual void Handle(AddPersonCommand command)
        {
            var newPerson = new Person
            {
                Email = command.Email,
                FirstName = command.FirstName,
                LastName = command.LastName,
                IsAuthor = command.IsAuthor,
                Sobriquet = command.Sobriquet,
                ObjectState = ObjectState.Added
            };

            _unitOfWork.Repository<Person>().InsertGraph(newPerson);

            //_unitOfWork.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                //_unitOfWork.Dispose();
            }

            _disposed = true;
        }
    }
}
