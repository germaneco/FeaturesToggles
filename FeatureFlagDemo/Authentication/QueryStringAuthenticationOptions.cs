﻿using Microsoft.AspNetCore.Authentication;

namespace FeatureFlagDemo.Authentication
{
    class QueryStringAuthenticationOptions : AuthenticationSchemeOptions
    {
        public string UsernameParameterName { get; set; } = "username";

        public string GroupsParameterName { get; set; } = "groups";
    }
}
