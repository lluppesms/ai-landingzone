// Copyright (c) Microsoft. All rights reserved.

using Azure.Identity;

namespace chatui.Extensions;

public static class CredentialsHelper
{
    public static DefaultAzureCredential GetCredentials(IConfiguration configuration)
    {
        return GetCredentials(configuration["VisualStudioTenantId"], configuration["UserAssignedManagedIdentityClientId"]);
    }

    public static DefaultAzureCredential GetCredentials(ChatApiOptions configuration)
    {
        return GetCredentials(configuration.VisualStudioTenantId, configuration.UserAssignedManagedIdentityClientId);
    }

    public static DefaultAzureCredential GetCredentials(string visualStudioTenantId, string userAssignedManagedIdentityClientId)
    {
        if (!string.IsNullOrEmpty(visualStudioTenantId))
        {
            var azureCredential = new DefaultAzureCredential(new DefaultAzureCredentialOptions
            {
                VisualStudioTenantId = visualStudioTenantId,
                Diagnostics = { IsLoggingContentEnabled = true }
            });
            return azureCredential;
        }
        else
        {
            if (!string.IsNullOrEmpty(userAssignedManagedIdentityClientId))
            {
                var azureCredential = new DefaultAzureCredential(new DefaultAzureCredentialOptions
                {
                    ManagedIdentityClientId = userAssignedManagedIdentityClientId,
                    Diagnostics = { IsLoggingContentEnabled = true }
                });
                return azureCredential;
            }
            else
            {
                var azureCredential = new DefaultAzureCredential(new DefaultAzureCredentialOptions
                {
                    Diagnostics = { IsLoggingContentEnabled = true }
                });
                return azureCredential;
            }
        }
    }
}
