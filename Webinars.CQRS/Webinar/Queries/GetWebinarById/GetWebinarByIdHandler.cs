using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Webinars.Contracts.Persistence;
using Webinars.CQRS.Webinar.ViewModel;

namespace Webinars.CQRS.Webinar.Queries.GetWebinarById
{
    public class GetWebinarByIdHandler : IRequestHandler<GetWebinarById, GetWebinarByIdHandlerResponse>
    {
        private readonly IWebinarRepository _repository;
        private readonly IMapper _mapper;

        public GetWebinarByIdHandler(IWebinarRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public async Task<GetWebinarByIdHandlerResponse> Handle(GetWebinarById request, CancellationToken cancellationToken)
        {
            var webinar = await _repository.GetById(request.Id);

            return new GetWebinarByIdHandlerResponse(_mapper.Map<WebinarViewModel>(webinar));
        }
    }
}