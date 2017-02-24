using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//namespace Gapura.Models.GlobalVar
namespace Gapura.Models
{
    public partial class RequestHeader
    {
        public string SeqRequestNo
        {
            get
            {   // 001/RF/GA/I/17
                var seq = RequestID.ToString() + "/RF/GA/";

                return seq;
            }
        }
    }
}