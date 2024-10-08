﻿using Microsoft.AspNetCore.Authentication;

namespace FeatureFlagDemo.Authentication
{
    static class QueryStringAuthenticationExtensions
    {
        public static AuthenticationBuilder AddQueryString(this AuthenticationBuilder builder)
        {
            return builder.AddScheme<QueryStringAuthenticationOptions, QueryStringAuthenticationHandler>(Schemes.QueryString, null);
        }
    }
}
