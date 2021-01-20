using System;

namespace WebApiThrottle
{
    [Flags]
    public enum ThrottlingBy
    {
        IpThrottling = 1,
        ClientThrottling = 2,
        EndpointThrottling = 4
    }
}