using System;
using System.Web;

namespace System.Web.AuthLib
{
    public static class UriExtension
    {
        public static string GetUriString(this Uri parent)
        => !string.IsNullOrEmpty(parent.AbsoluteUri) ? 
        parent.AbsoluteUri.Replace(":80", "") : null;
    }
}
