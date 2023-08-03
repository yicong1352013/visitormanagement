// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace CleanArchitecture.Blazor.Application.Features.MessageTemplates.Caching;

public static class MessageTemplateCacheKey
{
    public const string GetAllCacheKey = "all-MessageTemplates";
    public static string GetPagtionCacheKey(string parameters) {
        return $"MessageTemplatesWithPaginationQuery,{parameters}";
    }
        static MessageTemplateCacheKey()
    {
        _tokensource = new CancellationTokenSource(new TimeSpan(3,0,0));
    }
    private static CancellationTokenSource _tokensource;
    public static CancellationTokenSource SharedExpiryTokenSource()
    {
        if (_tokensource.IsCancellationRequested)
        {
            _tokensource = new CancellationTokenSource(new TimeSpan(3, 0, 0));
        }
        return _tokensource;
    }
    public static void Refresh()
    {
        SharedExpiryTokenSource().Cancel();
    }
    public static MemoryCacheEntryOptions MemoryCacheEntryOptions => new MemoryCacheEntryOptions().AddExpirationToken(new CancellationChangeToken(SharedExpiryTokenSource().Token));
}

