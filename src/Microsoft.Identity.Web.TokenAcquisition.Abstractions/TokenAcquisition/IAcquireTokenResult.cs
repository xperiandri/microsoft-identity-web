﻿using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Microsoft.Identity.Web
{
    /// <summary>
    /// Result of a token acquisition
    /// </summary>
    public interface IAcquireTokenResult
    {
        /// <summary>
        /// Access Token that can be used to build an authorization header 
        /// to access protected web APIs. 
        /// </summary>
        /// <seealso cref="IAuthorizationHeaderProvider"/> which creates the authorization
        /// header directly, whatever the protocol.
        public string AccessToken { get; }

        /// <summary>
        /// Gets the point in time in which the Access Token returned in the <see cref="AccessToken"/>
        /// property ceases to be valid. This value is calculated based on current UTC time
        /// measured locally and the value expiresIn received from the service.
        /// </summary>
        public DateTimeOffset ExpiresOn { get; }

        /// <summary>
        ///  In the case of Azure AD, gets an identifier for the tenant from which the token was acquired.
        ///  This property will be null if tenant information is not returned by the service or the service
        ///  is not Azure AD.
        /// </summary>
        public string TenantId { get; }

        /// <summary>
        /// Gets the Id Token if returned by the service or null if no Id Token is returned.
        /// </summary>
        public string IdToken { get; }

        /// <summary>
        /// Gets the scope values effectively granted by the IdP.
        /// </summary>
        public IEnumerable<string> Scopes { get; }

        /// <summary>
        /// Gets the correlation id used for the request.
        /// </summary>
        public Guid CorrelationId { get; }
    }
}