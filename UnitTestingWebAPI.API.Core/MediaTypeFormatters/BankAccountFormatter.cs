#region Using
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using UnitTestingWebAPI.Domain;
#endregion

namespace UnitTestingWebAPI.API.Core.MediaTypeFormatters
{
    public class BankAccountFormatter : BufferedMediaTypeFormatter
    {
        public BankAccountFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/BankAccount"));
        }

        public override bool CanReadType(Type type)
        {
            return false;
        }

        public override bool CanWriteType(Type type)
        {
            //for single BankAccount object
            if (type == typeof(BankAccount))
                return true;
            else
            {
                // for multiple BankAccount objects
                Type _type = typeof(IEnumerable<BankAccount>);
                return _type.IsAssignableFrom(type);
            }
        }

        public override void WriteToStream(Type type,
                                           object value,
                                           Stream writeStream,
                                           HttpContent content)
        {
            using (StreamWriter writer = new StreamWriter(writeStream))
            {
                var BankAccounts = value as IEnumerable<BankAccount>;
                if (BankAccounts != null)
                {
                    foreach (var BankAccount in BankAccounts)
                    {
                        writer.Write(String.Format("[{0},\"{1}\",\"{2}\"]",
                                                    BankAccount.ID,
                                                    BankAccount.Number,
                                                    BankAccount.Owner));
                    }
                }
                else
                {
                    var _BankAccount = value as BankAccount;
                    if (_BankAccount == null)
                    {
                        throw new InvalidOperationException("Cannot serialize type");
                    }
                    writer.Write(String.Format("[{0},\"{1}\",\"{2}\"]",
                                                    _BankAccount.ID,
                                                    _BankAccount.Number,
                                                    _BankAccount.Owner));
                }
            }
        }
    }
}
