﻿using System.Collections.Generic;
using System.Linq;
using KesselRun.HomeLibrary.EF;
using KesselRun.HomeLibrary.Mapper.Mappers;
using KesselRun.HomeLibrary.Service.Infrastructure;
using KesselRun.HomeLibrary.Service.Queries;
using KesselRun.HomeLibrary.UiModel.Models;

namespace KesselRun.HomeLibrary.Service.QueryHandlers
{
    public class PeopleHandlers : IQueryHandler<GetPeopleSortedQuery, IList<Person>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUniversalMapper _mapper;

        public PeopleHandlers(IUnitOfWork unitOfWork, IUniversalMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IList<Person> Handle(GetPeopleSortedQuery query)
        {
            IList<Person> people = new List<Person>();

            foreach (var person in _unitOfWork.People.GetAll())
            {
                var uiPerson = new Person();
                people.Add(_mapper.Map(person, uiPerson));
            }

            return people.OrderBy(o => o.Id).ToList();
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}