using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Compoment.Library.DynamoDB
{
    public class DynamoDBOption
    {
        public string AWSAccessKey { get; set; }
        public string AWSSecretKey { get; set; }
        public string AWSRegion { get; set; }
    }
}
