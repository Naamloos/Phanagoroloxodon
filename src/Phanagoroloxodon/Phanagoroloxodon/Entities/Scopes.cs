using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Phanagoroloxodon.Entities
{
    public static class ScopesConversion
    {
        /// <summary>
        /// Converts the given Scopes flags to an oauth-useable string
        /// Could probably be optimized significantly but if it works... it works.
        /// </summary>
        /// <param name="scopes">Scopes to convert</param>
        /// <returns>OAuth-ready scopes string</returns>
        public static string ToScopesString(this Scopes scopes)
        {
            // Get all separate scopes
            var separateScopes = Enum.GetValues<Scopes>().Where(x => scopes.HasFlag(x));
            // Get those that are considered "parents" to other scopes
            var parentScopes = separateScopes.Where(x => IsParentScope(x));
            // collect all names
            var names = separateScopes.Select(x => getDisplayName(x));

            // Filter out those that are considered "child" scopes
            foreach(var parentScope in parentScopes)
            {
                var name = getDisplayName(parentScope);
                names = names.Where(x => !x.StartsWith(name) || x == name);
            }

            // join to scopes string
            return string.Join("+", names.Distinct());
        }

        private static string getDisplayName(Scopes value)
        {
            var name = Enum.GetName(value);
            Type type = value.GetType();
            var member = type.GetMember(name).FirstOrDefault();
            var attr = member.GetCustomAttribute<ScopeNameAttribute>();

            if(attr != default)
            {
                return attr.Name;
            }

            return name;
        }

        private static bool IsParentScope(Scopes value)
        {
            var name = Enum.GetName(value);
            Type type = value.GetType();
            var member = type.GetMember(name).FirstOrDefault();
            var attr = member.GetCustomAttribute<ParentScopeAttribute>();

            return attr != default;
        }
    }

    public class ScopeNameAttribute : Attribute
    {
        public string Name { get; set; }
    }

    public class ParentScopeAttribute : Attribute
    {
    }

    [Flags]
    public enum Scopes
    {
        [ScopeName(Name = "read:accounts")]
        ReadAccounts,

        [ScopeName(Name = "read:blocks")]
        ReadBlocks,

        [ScopeName(Name = "read:bookmarks")]
        ReadBookmarks,

        [ScopeName(Name = "read:favourites")]
        ReadFavourites,

        [ScopeName(Name = "read:filters")]
        ReadFilters,

        [ScopeName(Name = "read:follows")]
        ReadFollows,

        [ScopeName(Name = "read:lists")]
        ReadLists,

        [ScopeName(Name = "read:mutes")]
        ReadMutes,

        [ScopeName(Name = "read:notifications")]
        ReadNotifications,

        [ScopeName(Name = "read:search")]
        ReadSearch,

        [ScopeName(Name = "read:statuses")]
        ReadStatuses,

        [ParentScope]
        [ScopeName(Name = "read")]
        Read = ReadAccounts | ReadBlocks | ReadBookmarks | ReadFavourites 
            | ReadFilters | ReadFollows | ReadLists | ReadMutes | ReadNotifications | ReadSearch | ReadStatuses,


        [ScopeName(Name = "write:accounts")]
        WriteAccounts,

        [ScopeName(Name = "write:blocks")]
        WriteBlocks,

        [ScopeName(Name = "write:bookmarks")]
        WriteBookmarks,

        [ScopeName(Name = "write:conversations")]
        WriteConversations,

        [ScopeName(Name = "write:favourites")]
        WriteFavourites,

        [ScopeName(Name = "write:filters")]
        WriteFilters,

        [ScopeName(Name = "write:follows")]
        WriteFollows,

        [ScopeName(Name = "write:lists")]
        WriteLists,

        [ScopeName(Name = "write:media")]
        WriteMedia,

        [ScopeName(Name = "write:mutes")]
        WriteMutes,

        [ScopeName(Name = "write:notifications")]
        WriteNotifications,

        [ScopeName(Name = "write:reports")]
        WriteReports,

        [ScopeName(Name = "write:statuses")]
        WriteStatuses,

        [ParentScope]
        [ScopeName(Name = "write")]
        Write = WriteAccounts | WriteBlocks | WriteBookmarks | WriteConversations 
            | WriteFavourites | WriteFilters | WriteFollows | WriteLists | WriteMedia | WriteMutes | WriteNotifications
            | WriteReports | WriteStatuses,

        // Follows is deprecated and thus skipped in this library

        [ParentScope]
        [ScopeName(Name = "push")]
        Push,


        [ScopeName(Name = "admin:read:accounts")]
        AdminReadAccounts,

        [ScopeName(Name = "admin:read:reports")]
        AdminReadReports,

        [ScopeName(Name = "admin:read:domain_allows")]
        AdminReadDomainAllows,

        [ScopeName(Name = "admin:read:domain_blocks")]
        AdminReadDomainBlocks,

        [ScopeName(Name = "admin:read:ip_blocks")]
        AdminReadIpBlocks,

        [ScopeName(Name = "admin:read:email_domain_blocks")]
        AdminReadEmailDomainBlocks,

        [ScopeName(Name = "admin:read:canonical_email_blocks")]
        AdminReadCanonicalEmailBlocks,

        [ParentScope]
        [ScopeName(Name = "admin:read")]
        AdminRead = AdminReadAccounts | AdminReadReports | AdminReadDomainAllows 
            | AdminReadDomainBlocks | AdminReadIpBlocks | AdminReadEmailDomainBlocks | AdminReadCanonicalEmailBlocks,


        [ScopeName(Name = "admin:write:accounts")]
        AdminWriteAccounts,

        [ScopeName(Name = "admin:write:reports")]
        AdminWriteReports,

        [ScopeName(Name = "admin:write:domain_allows")]
        AdminWriteDomainAllows,

        [ScopeName(Name = "admin:write:domain_blocks")]
        AdminWriteDomainBlocks,

        [ScopeName(Name = "admin:write:ip_blocks")]
        AdminWriteIpBlocks,

        [ScopeName(Name = "admin:write:email_domain_blocks")]
        AdminWriteEmailDomainBlocks,

        [ScopeName(Name = "admin:write:canonical_email_blocks")]
        AdminWriteCanonicalEmailBlocks,

        [ParentScope]
        [ScopeName(Name = "admin:write")]
        AdminWrite = AdminWriteAccounts | AdminWriteReports | AdminWriteDomainAllows 
            | AdminWriteDomainBlocks | AdminWriteIpBlocks | AdminWriteEmailDomainBlocks | AdminWriteCanonicalEmailBlocks
    }
}
