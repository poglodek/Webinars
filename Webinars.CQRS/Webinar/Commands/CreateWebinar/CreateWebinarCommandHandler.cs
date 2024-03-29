﻿using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Webinars.Common;
using Webinars.Contracts.Persistence;
using Webinars.Domain.Exception;

namespace Webinars.CQRS.Webinar.Commands.CreateWebinar
{
    public class CreateWebinarCommandHandler : IRequestHandler<CreateWebinarCommand, OperationStatusCode>
    {
        private readonly IMapper _mapper;
        private readonly IWebinarRepository _repository;

        public CreateWebinarCommandHandler(IWebinarRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OperationStatusCode> Handle(CreateWebinarCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateWebinarCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                throw new ValidatorException(validationResult.Errors.Select(x=>x.ErrorMessage).Aggregate((x,z)=>x+","+z));

            //TODO: GET SPEAKER by rabbitmq

            var webinar = _mapper.Map<Domain.Entities.Webinar>(request);

            var result = await _repository.Create(webinar);
            if (result != OperationStatusCode.CREATED)
                throw new RepositoryException("Webinar creation failed: " + result);

            return result;
        }
    }
}