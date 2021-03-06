﻿using SGGWSupportWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGGWSupportWeb.Extensions
{
    public static class SessionExtensions
    {
        public static void SetToken(this HttpSessionStateBase session, UserIdentity token)
        {
            if (session == null)
            {
                return;
            }
            var context = HttpContext.Current;
            var key = typeof(UserIdentity).ToString();
            session.Add(key, token);
        }

        public static UserIdentity GetToken(this HttpSessionStateBase session)
        {
            var context = HttpContext.Current;
            if (context == null || session == null)
                return default(UserIdentity);
            var filter = (UserIdentity)(session[typeof(UserIdentity).ToString()]);
            if (filter != null)
                return filter;
            return default(UserIdentity);
        }

        public static void SetCurrentUser(this HttpSessionStateBase session, CurrentUser token)
        {
            if (session == null)
            {
                return;
            }
            var context = HttpContext.Current;
            var key = typeof(CurrentUser).ToString();
            session.Add(key, token);
        }

        public static CurrentUser GetCurrentUser(this HttpSessionStateBase session)
        {
            var context = HttpContext.Current;
            if (context == null || session == null)
                return default(CurrentUser);
            var filter = (CurrentUser)(session[typeof(CurrentUser).ToString()]);
            if (filter != null)
                return filter;
            return default(CurrentUser);
        }
    }
}