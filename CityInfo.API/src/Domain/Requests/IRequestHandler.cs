﻿namespace CityInfo.API.Domain.Requests
{
    public interface IRequestHandler<TRequest, TResult> where TRequest : IRequest<TResult>
    {
        Task<TResult> HandleAsync(TRequest request, CancellationToken ct);
    }
}
