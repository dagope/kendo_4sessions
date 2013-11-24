using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using Demo1.Extensions;

namespace Demo1.KendoHelper
{
    public class KendoGridQueryModel
    {
        public const string tagTop = "$top";
        public const string tagSkip = "$skip";
        public const string tagOrder = "$orderby";
        public const string tagFilter = "$filter";     
        public const string tagExport = "export";

        public int? Skip { get; set; }
        public int? Take { get; set; }
        public string SortOrd { get; set; }
        public string SortOn { get; set; }

        public string Export { get; set; }

        private bool _enableOrder = true;
        public bool EnableOrder
        {
            get { return _enableOrder; }
            set { _enableOrder = value; }
        }
        private bool _enablePagination = true;
        public bool EnablePagination
        {
            get { return _enablePagination; }
            set { _enablePagination = value; }
        }

        /// <summary>
        /// Cadena de texto en formato OData
        /// <example>$filter=Name eq 'David'</example>
        /// </summary>
        public string FilterUri { get; set; }


        public KendoGridQueryModel()
        {   
            if (HttpContext.Current != null)
            {
                HttpRequest curRequest = HttpContext.Current.Request;
                if (curRequest.HttpMethod == "GET")
                {
                    if (curRequest[tagSkip].IsNotEmpty())
                        this.Skip = curRequest[tagSkip].Parse<int>();
                    else
                        this.Skip = null;

                    if (curRequest[tagTop].IsNotEmpty())
                        this.Take = curRequest[tagTop].Parse<int>();
                    else
                        this.Take = null;


                    if (curRequest[tagOrder].IsNotEmpty())
                    {
                        var fields = curRequest[tagOrder].Split(' ');
                        this.SortOrd = fields.ElementAtOrDefault(1); //curRequest["sort[0][dir]"];
                        this.SortOn = fields.ElementAtOrDefault(0);
                    }
                    this.Export = curRequest[tagExport];

                    if (curRequest[tagFilter].IsNotEmpty())
                        this.FilterUri = string.Format("{0}={1}", tagFilter, curRequest[tagFilter]);
                }
                else
                {
                    curRequest.InputStream.Position = 0;
                    var reqMemStream = new MemoryStream(curRequest.BinaryRead(curRequest.ContentLength));
                    string json = Encoding.ASCII.GetString(reqMemStream.ToArray());
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    var dic = serializer.DeserializeObject(json) as Dictionary<string, object>;

                    if(dic != null)
                    {   
                        object obj = null;
                        this.Take = dic.TryGetValue(tagTop, out obj) ? (int?)obj : null;
                        
                        obj = null;
                        this.Skip = dic.TryGetValue(tagSkip, out obj) ? (int?)obj : null;

                        if (dic.TryGetValue(tagOrder, out obj))
                        {
                            var fields = obj.ToString().Split(' ');
                            this.SortOrd = fields.ElementAtOrDefault(1);
                            this.SortOn = fields.ElementAtOrDefault(0);
                        }
                        
                        obj = null;
                        this.Export = dic.TryGetValue(tagExport, out obj) ? (string)obj : null;

                        obj = null;
                        this.FilterUri = dic.TryGetValue(tagFilter, out obj) ? string.Format("{0}={1}", tagFilter , (string)obj) : null;
                    }
                }
            }
        }
    }
}