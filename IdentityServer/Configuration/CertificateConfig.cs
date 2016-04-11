using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MapHive.Identity.IdentityServer.Configuration
{
    public class CertificateConfig
    {
        /// <summary>
        /// Type of the storage to retrieve a certificate from
        /// </summary>
        public CertificateStorageType StorageType { get; set; }

        /// <summary>
        /// Certificate file location - either a full or realtive path
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// Certificate resource fully qualified namespace
        /// </summary>
        public string NameSpace { get; set; }

        /// <summary>
        /// Subject to search for the cert in the store
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; }
    }
}