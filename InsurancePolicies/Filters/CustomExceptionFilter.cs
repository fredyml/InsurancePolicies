﻿using InsurancePolicies.Domain.Exceptions;
using InsurancePolicies.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MongoDB.Driver;

namespace InsurancePolicies.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        private readonly Dictionary<Type, IExceptionHandler> _exceptionHandlers;

        public CustomExceptionFilter()
        {
            _exceptionHandlers = new Dictionary<Type, IExceptionHandler>
            {
                { typeof(MongoException), new MongoExceptionHandler() },
                { typeof(InvalidOperationException), new InternalServerErrorExceptionHandler() },
                { typeof(ArgumentException), new BadRequestExceptionHandler() },
                { typeof(NotFoundException), new NotFoundExceptionHandler() }
            };
        }

        public void OnException(ExceptionContext context)
        {
            Type exceptionType = context.Exception.GetType();
            if (_exceptionHandlers.ContainsKey(exceptionType))
            {
                context.Result = _exceptionHandlers[exceptionType].Handle(context.Exception);
            }
            else
            {
                context.Result = new ObjectResult("An unexpected error occurred.")
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                };
            }
        }
    }
}
