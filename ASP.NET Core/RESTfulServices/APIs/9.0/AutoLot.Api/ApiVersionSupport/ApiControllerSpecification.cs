// Copyright Information
// ==================================
// AutoLot9 - AutoLot.Api - ApiControllerSpecification.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/11/20
// ==================================

namespace AutoLot.Api.ApiVersionSupport;

public class ApiControllerSpecification : IApiControllerSpecification
{
    public bool IsSatisfiedBy(ControllerModel controller)
    {
        return controller.Attributes.OfType<ApiControllerAttribute>().Any();
    }
}