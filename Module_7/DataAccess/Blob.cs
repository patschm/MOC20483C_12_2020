using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    // Entity
    class Blob
    {
        public string AccountName { get; set; }
        public string ContainerName { get; set; }
        public string BlobName { get; set; }
        public int BlobType { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
