using Microsoft.AspNetCore.Mvc;

namespace InsurancePolicies.Infrastructure.Exceptions
{
    public interface IExceptionHandler
    {
        IActionResult Handle(Exception exception);
    }
}
